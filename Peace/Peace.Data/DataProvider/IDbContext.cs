using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peace.Core;
using System.Collections.Generic;
using System.Data.Entity;


namespace Peace.Data
{
    /// <summary>
    /// 该接口提供了存储过程的支持，可以说提高了项目的灵活性，如果是做产品，这一块建议不要用存储过程，不便数据库迁移
    /// </summary>
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class,new() ;

        int SaveChanges();

        /// <summary>
        /// 执行存储过程，并返回列表对象
        /// </summary>
        /// <typeparam name="TEtity"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IList<TEntity> ExecuteStoreProcedureList<TEntity>(string commandText, params object[] parameters)
            where TEntity : class , new();
        /// <summary>
        /// 查询Sql语句
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        /// <summary>
        /// 执行sql 是否启用事务
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="doNotEnsureTransaction"></param>
        /// <param name="timeout"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null,
            params object[] parameters);
    }
}
