using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Peace.Com.Tools;

namespace Peace.Com
{
    /// <remarks>王家新, 2014-08-01, 2014-08-01</remarks>
    /// <summary>
    /// 简单分页算法类
    /// </summary>
    public class Pager
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 当前页号
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页记录条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return (RecordCount - 1) / PageSize + 1;
            }
        }


        const int SHOW_COUNT = 6; //这个常量表示两边都有省略号时，中间的分页链接的个数,如 1..4 5 6 7 8 9 .. 100
        private List<int> CalcPages()
        {
            List<int> pages = new List<int>();

            int start = (PageIndex - 1) / SHOW_COUNT * SHOW_COUNT + 1;
            int end = Math.Min(PageCount, start + SHOW_COUNT - 1);

            if (start == 1)
            {
                end = Math.Min(PageCount, end + 1);
            }
            else if (end == PageCount)
            {
                start = Math.Max(1, end - SHOW_COUNT);
            }
            pages.AddRange(Enumerable.Range(start, end - start + 1));

            if (start == PageIndex && start > 2)
            {
                pages.Insert(0, start - 1);
                pages.RemoveAt(pages.Count - 1);//保持显示页号个数统一
            }
            if (end == PageIndex && end + 1 < PageCount)
            {
                pages.Add(end + 1);
                pages.RemoveAt(0);  //保持显示页号个数统一
            }
            if (PageCount > 1)
            {
                if (pages[0] > 1)
                {
                    pages.Insert(0, 1); //如果页列表第一项不是第一页，则在队头添加第一页
                }
                if (pages[1] == 3)
                {
                    pages.Insert(1, 2); //如果是1..3这种情况，则把..换成2
                }
                else if (pages[1] > 3)
                {
                    pages.Insert(1, -1); //插入左侧省略号
                }

                if (pages.Last() == PageCount - 2)
                {
                    pages.Add(PageCount - 1); //如果是 98..100这种情况，则..换成99
                }
                else if (pages.Last() < PageCount - 2)
                {
                    pages.Add(-1); //插入右侧省略号
                }

                if (pages.Last() < PageCount)
                {
                    pages.Add(PageCount); //最后一页
                }
            }

            return pages;
        }

        /// <summary>
        /// 用于显示的页号数组，如果中间有小于0的页号，则表示是省略号
        /// </summary>
        public List<int> Pages
        {
            get
            {
                return CalcPages();
            }
        }

        /// <summary>
        /// 当前记录的绝对位置 
        /// </summary>
        public int AbsRowIndex
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 包含结果数据的分页类，可以用来枚举
    /// </summary>
    /// <typeparam name="T">结果数据集合中元素的类型</typeparam>
    public class Pager<T> : Pager, IEnumerable<T>
    {
        /// <summary>
        /// 分页得到的结果集
        /// </summary>
        private List<T> mResultSet;

        /// <summary>
        /// 分页之前的查询
        /// </summary>
        public IQueryable<T> OrignalQuery { get; set; }

        /// <summary>
        /// 根据指定的集合表达式和排序字段得出一个分页对象和分页后的数据集
        /// </summary>
        /// <param name="allList">初始的集合</param>
        /// <param name="page">页号</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        public Pager(IQueryable<T> allList,
           int page = 1,
            int pageSize = 20)
        {
            int p = Math.Max(1, page);
            OrignalQuery = allList;
            var recordCount = allList.Count();
            mResultSet = allList
                .Skip((p - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            PageIndex = p;
            PageSize = pageSize;
            RecordCount = recordCount;
        }

        /// <summary>
        /// 根据指定的集合表达式和排序的委托得出一个分页对象和分页后的数据集
        /// 这一般用于多重排序
        /// </summary>
        /// <param name="allList">数据实体列表</param>
        /// <param name="OnSorting">排序时调用的排序委托</param>
        /// <param name="page">当前页号(从1开始)</param>
        /// <param name="pageSize">每页记录数</param>
        public Pager(IQueryable<T> allList,
            Func<IQueryable<T>,
            IQueryable<T>> OnSorting,
            int page = 1,
            int pageSize = 20)
        {
            int p = Math.Max(1, page);
            var recordCount = allList.Count();

            if (OnSorting != null)
            {
                allList = OnSorting(allList);
            }

            OrignalQuery = allList;
            mResultSet = allList
                .Skip((p - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            PageIndex = p;
            PageSize = pageSize;
            RecordCount = recordCount;
        }

        /// <summary>
        /// 根据指定的集合表达式和排序的字符串表达式(类似于sql的orderby条件的写法）得出一个分页对象和分页后的数据集
        /// 可以支持多重排序
        /// </summary>
        /// <param name="allList">集合表达式</param>
        /// <param name="sortExpression">排序的字符串表达式(类似于sql的orderby条件的写法）</param>
        /// <param name="page">当前页号(从1开始)</param>
        /// <param name="pageSize">每页记录数</param>
        public Pager(IQueryable<T> allList,
            string sortExpression,
            int page = 1,
            int pageSize = 20
           )
        {
            int p = Math.Max(1, page);
            var recordCount = allList.Count();

            if (!String.IsNullOrWhiteSpace(sortExpression))
            {
                allList = allList.OrderBy(sortExpression);
            }

            OrignalQuery = allList;

            mResultSet = allList
                .Skip((p - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            PageIndex = p;
            PageSize = pageSize;
            RecordCount = recordCount;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return mResultSet.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return mResultSet.GetEnumerator();
        }
    }
}