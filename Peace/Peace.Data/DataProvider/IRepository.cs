using Peace.Com;
using Peace.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Data
{
    public partial interface IRepository<T> where T : class,new()
    {
        T GetById(object id);

        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

        void Update(T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Update(IEnumerable<T> entities);

        void Delete(T entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// 查询表达式获取查询对象
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IQueryable<T> IQueryable(Expression<Func<T, bool>> condition);

        /// <summary>
        ///  Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="whereExpression">表达式</param>
        /// <param name="page">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="sortExpression">排序</param>
        /// <returns></returns>
        Pager<T> PageQuery(Expression<Func<T, bool>> whereExpression, int page, int pageSize, string sortExpression = null);
    }
}
