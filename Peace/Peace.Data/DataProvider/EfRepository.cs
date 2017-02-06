using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peace.Core;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq.Expressions;
using Peace.Com;

namespace Peace.Data
{
    public partial class EfRepository<T> : IRepository<T> where T : class,new()
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        /// <summary>
        /// 获取表对象
        /// </summary>
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }


        /// <summary>
        /// 基于EF的数据访问实现
        /// </summary>
        /// <param name="context"></param>
        public EfRepository(IDbContext context)
        {
            this._context = context;
        }


        /// <summary>
        /// 获取表对象
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public IQueryable<T> TableNoTracking
        {
            get { return this.Entities.AsNoTracking(); }
        }

        /// <summary>
        /// 错误提醒
        /// </summary>
        /// <param name="exc">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg += string.Format("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
            return msg;
        }

        /// <summary>
        /// 通过Id获取实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// 单个新增
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        public void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }
                foreach (var entity in entities)
                {
                    this.Entities.Add(entity);
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// 单个更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Remove(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        public void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    this.Entities.Remove(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IQueryable<T> IQueryable(Expression<Func<T, bool>> condition)
        {
            return this.Entities.Where(condition);
        }


        //加入分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="whereExpression">表达式</param>
        /// <param name="page">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="sortExpression">排序</param>
        /// <returns></returns>
        public virtual Pager<T> PageQuery(Expression<Func<T, bool>> whereExpression, int page, int pageSize, string sortExpression = null)
        {
            return new Pager<T>(
               whereExpression == null ? Table : IQueryable(whereExpression),
                sortExpression,page, pageSize);
        }
    }
}
