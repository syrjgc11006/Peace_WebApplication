using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peace.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

namespace Peace.Data
{
    public class PeaceObjectContext : DbContext, IDbContext
    {
        #region 属性
        /// <summary>
        /// 菜单
        /// </summary>
        public virtual DbSet<pl_navigation> pl_navigation { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public virtual DbSet<pl_article> pl_article { get; set; }

        /// <summary>
        /// 文章类别
        /// </summary>
        public virtual DbSet<pl_article_category> pl_article_category { get; set; }

        /// <summary>
        /// 文章评论
        /// </summary>
        public virtual DbSet<pl_article_comment> pl_article_comment { get; set; }

        #endregion

        #region 构造函数

        public PeaceObjectContext()
            : base("SqlConnection")
        {
            //Database.SetInitializer<PeaceObjectContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PeaceObjectContext, Configuration<PeaceObjectContext>>());
        }

        //public PeaceOb()
        //    : base("SqlConnection")
        //{
        //    //Database.SetInitializer(new MigrateDatabaseToLatestVersion<PortalDb, Configuration<PortalDb>>());
        //}


        #endregion

        #region 工具方法

        /// <summary>
        /// 通过反射向将EF的实体映射配置加入到实体模型中
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var types = Assembly.GetAssembly(typeof(PeaceEntityTypeConfiguration<>));
            //EF默认设置级联删除，先移除默认规则，需要再配置
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(PeaceEntityTypeConfiguration<>));
            var typesToRegister = types.GetTypes()
               .Where(type => !String.IsNullOrEmpty(type.Namespace))
               .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(PeaceEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity : class,new()
        {
            //little hack here until Entity Framework really supports stored procedures
            //otherwise, navigation properties of loaded entities are not loaded until an entity is attached to the context
            var alreadyAttached = Set<TEntity>().Local.FirstOrDefault();
            if (alreadyAttached == null)
            {
                //attach new entity
                Set<TEntity>().Attach(entity);
                return entity;
            }

            //entity is already loaded
            return alreadyAttached;
        }

        #endregion

        #region 接口实现方法

        /// <summary>
        /// 获取数据表实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public System.Data.Entity.IDbSet<TEntity> Set<TEntity>() where TEntity : class,new()
        {
            return base.Set<TEntity>();
        }


        /// <summary>
        /// 执行存储过程返回数据实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IList<TEntity> ExecuteStoreProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : class,new()
        {
            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i < parameters.Length - 1; i++)
                {
                    var p = parameters[i] as DbParameter;
                    if (p == null)
                    {
                        throw new Exception("Not support parameter type");
                    }
                    commandText += i == 0 ? "" : ", ";
                    commandText += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        commandText += " output";
                    }
                }
            }
            var result = this.Database.SqlQuery<TEntity>(commandText, parameters).ToList();
            bool acd = this.Configuration.AutoDetectChangesEnabled;
            try
            {
                this.Configuration.AutoDetectChangesEnabled = false;
                for (int i = 0; i < result.Count; i++)
                {
                    result[i] = AttachEntityToContext(result[i]);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                this.Configuration.AutoDetectChangesEnabled = acd;
            }
            return result;
        }

        /// <summary>
        /// 执行sql语句返回数据实体集
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters);
        }

        /// <summary>
        /// 是否启用事务执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="doNotEnsureTransaction"></param>
        /// <param name="timeout"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            int? previousTimeout = null;
            if (timeout.HasValue)
            {
                previousTimeout = ((IObjectContextAdapter)this).ObjectContext.CommandTimeout;
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
            }

            var transactionalBehavior = doNotEnsureTransaction
                            ? TransactionalBehavior.DoNotEnsureTransaction
                            : TransactionalBehavior.EnsureTransaction;
            var result = this.Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);

            if (timeout.HasValue)
            {
                //Set previous timeout back
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
            }

            //return result
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

         

        #endregion

        /// <summary>
        /// 内部类
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        internal sealed class Configuration<TContext> : DbMigrationsConfiguration<TContext> where TContext : DbContext
        {
            public Configuration()
            {
                //允许自动迁移
                AutomaticMigrationsEnabled = true;
                //自动迁移默认情况下不扔掉列在我们的数据库中的表。如果我们不希望这样的行为，我们可以告诉迁移明确允许数据丢失的配置类的AutomaticMigrationDataLossAllowed属性设置为true
                AutomaticMigrationDataLossAllowed = true;
            }
        }
    }
}
