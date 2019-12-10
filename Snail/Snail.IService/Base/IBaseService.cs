using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Snail.IService
{
    public interface IBaseService
    {
        #region Sync
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="predicate">new {ID = 1, Name="abc"}</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns>查询结果泛型序列</returns>
        T Get<T>(Expression<Func<T, bool>> lambdaWhere, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="id">id</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns>查询结果泛型序列</returns>
        T Get<T>(object id, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="lambdaWhere">x=>1==1</param>
        /// <param name="sort">new Sort{Ascending = false, PropertyName="abc"}</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns>查询结果泛型序列</returns>
        List<T> GetList<T>(Expression<Func<T, bool>> lambdaWhere, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// <para>By default queries the table matching the class name</para>
        /// <para>-Table name can be overridden by adding an attribute on your class [Table("YourTableName")]</para>
        /// <para>Returns a list of all entities</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <returns>Gets a list of all entities</returns>
        List<T> GetList<T>(IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// GetPage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        /// <param name="resultsPerPage"></param>
        /// <param name="allRowsCount"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="allRowsCountSql"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        List<T> GetPage<T>(int page, int resultsPerPage, out long allRowsCount, string sql, object param = null, string allRowsCountSql = null, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// GetPage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">x => x.Name == "abc"</param>
        /// <param name="sort"></param>
        /// <param name="page"></param>
        /// <param name="resultsPerPage"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        List<T> GetPage<T>(Expression<Func<T, bool>> lambdaWhere, IList<ISort> sort, int page, int resultsPerPage, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// <para>Inserts a row into the database, using ONLY the properties defined by T</para>
        /// <para>Returns the ID (primary key) of the newly inserted record if it is identity using the defined type, otherwise null</para>
        /// </summary>
        /// <param name="db"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>The ID (primary key) of the newly inserted record if it is identity using the defined type, otherwise null</returns>
        dynamic Insert<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// <para>Updates a record or records in the database with only the properties of T</para>
        /// <para>Returns number of rows affected</para>
        /// </summary>
        /// <param name="db"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>The number of affected records</returns>
        bool Update<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;


        /// <summary>
        /// 部分更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">new { Name = "ss" }</param>
        /// <param name="lambdaWhere">x => x.Id = 3</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        int Update<T>(object predicate, Expression<Func<T, bool>> lambdaWhere, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// <para>Deletes a record or records in the database that match the object passed in</para>
        /// <para>Returns the number of records affected</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>The number of records affected</returns>
        int Delete<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// <para>Deletes a record or records in the database that match the object passed in</para>
        /// <para>Returns the number of records affected</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>The number of records affected</returns>
        int Delete<T>(object id, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// <para>Deletes a list of records in the database</para>
        /// <para>By default deletes records in the table matching the class name</para>
        /// <para>-Table name can be overridden by adding an attribute on your class [Table("YourTableName")]</para>
        /// <para>Deletes records where that match the where clause</para>
        /// <para>conditions is an SQL where clause ex: "where name='bob'" or "where age>=@Age"</para>
        /// <para>parameters is an anonymous type to pass in named parameter values: new { Age = 15 }</para>
        /// <para>Supports transaction and command timeout</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this.Connection"></param>
        /// <param name="conditions"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>The number of records affected</returns>
        int Delete<T>(Expression<Func<T, bool>> lambdaWhere, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// <para>By default queries the table matching the class name</para>
        /// <para>-Table name can be overridden by adding an attribute on your class [Table("YourTableName")]</para>
        /// <para>Returns a number of records entity by a single id from table T</para>
        /// <para>Supports transaction and command timeout</para>
        /// <para>conditions is an SQL where clause ex: "where name='bob'" or "where age>=@Age" - not required </para>
        /// <para>parameters is an anonymous type to pass in named parameter values: new { Age = 15 }</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this.Connection"></param>
        /// <param name="conditions"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>Returns a count of records.</returns>
        int Count<T>(Expression<Func<T, bool>> lambdaWhere, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        int QueryCount(string sqlCount, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string connectionString = null);

        List<T> QueryList<T>(string sqlQuery, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string connectionString = null) where T : class;

        T QuerySingle<T>(string sqlQuery, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string connectionString = null) where T : class;

        List<T> QueryListPage<T>(int page, int resultsPerPage, out long allRowsCount, string sql, object param = null, string allRowsCountSql = null, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;


        List<T> QueryListPage<T>(out int totalCount, string sqlQuery, object param = null, string orderBy = null, int pageIndex = 1, int pageSize = 15, int? commandTimeout = null, string connectionString = null) where T : class;

        int ExecSQL(string sqlExec, object param, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string connectionString = null);
        #endregion

        #region Async
        #region Get
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="predicate">new {ID = 1, Name="abc"}</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns>查询结果泛型序列</returns>
        Task<T> GetAsync<T>(int id, IDbTransaction transaction, int? commandTimeout, string connectionString = null) where T : class;

        Task<T> GetAsync<T>(Expression<Func<T, bool>> lambdaWhere, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;
        #endregion

        #region GetList
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="predicate">new {ID = 1, Name="abc"}</param>
        /// <param name="sort">new Sort{Ascending = false, PropertyName="abc"}</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns>查询结果泛型序列</returns>
        Task<IEnumerable<T>> GetListAsync<T>(Expression<Func<T, bool>> lambdaWhere, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// <para>By default queries the table matching the class name</para>
        /// <para>-Table name can be overridden by adding an attribute on your class [Table("YourTableName")]</para>
        /// <para>Returns a list of all entities</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <returns>Gets a list of all entities</returns>
        Task<IEnumerable<T>> GetListAsync<T>(IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        Task<IEnumerable<T>> GetPageAsync<T>(int page, int resultsPerPage, out long allRowsCount, string sql, object param = null, string allRowsCountSql = null, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        Task<IEnumerable<T>> GetPageAsync<T>(Expression<Func<T, bool>> lambdaWhere, IList<ISort> sort, int page, int resultsPerPage, IDbTransaction transaction, int? commandTimeout, string connectionString = null) where T : class;

        #endregion

        #region Insert/Update/Delete
        /// <summary>
        /// InsertAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        void InsertAsync<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null) where T : class;

        /// <summary>
        /// InsertAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        void InsertAsync<T>(IEnumerable<T> entities, IDbTransaction transaction, int? commandTimeout, string connectionString = null) where T : class;

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<int> UpdateAsync<T>(T entity, IDbTransaction transaction, int? commandTimeout, string connectionString = null) where T : class;

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<int> DeleteAsync<T>(T entity, IDbTransaction transaction, int? commandTimeout, string connectionString = null) where T : class;

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<int> DeleteAsync<T>(Expression<Func<T, bool>> lambdaWhere, IDbTransaction transaction, int? commandTimeout, string connectionString = null) where T : class;

        /// <summary>
        /// <para>Deletes a record or records in the database that match the object passed in</para>
        /// <para>Returns the number of records affected</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>The number of records affected</returns>
        Task<int> DeleteAsync<T>(object id, IDbTransaction transaction = null, int? commandTimeout = null, string connectionString = null);
        #endregion

        #region Count
        /// <summary>
        /// CountAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<int> CountAsync<T>(Expression<Func<T, bool>> lambdaWhere, IDbTransaction transaction, int? commandTimeout, string connectionString = null) where T : class;

        #endregion

        #region Query
        Task<int> QueryCountAsync(string sqlCount, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string connectionString = null);

        Task<IEnumerable<T>> QueryListAsync<T>(string sqlQuery, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string connectionString = null);

        Task<T> QuerySingleAsync<T>(string sqlQuery, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string connectionString = null);

        #endregion

        #region ExecSQL
        Task<int> ExecSQLAsync(string sqlExec, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string connectionString = null);
        #endregion

        #endregion

        #region 统一赋值
        void SetNewStatus<T>(T entity, int status, string userId);

        void SetNewStatus<T>(T entity, string userId);

        void SetModifyStatus<T>(T entity, string userId);
        #endregion
    
      
        #region Transaction
        /// <summary>
        /// 【本地事务，同一数据库】但需要多个业务方法组合成的事务
        /// 备注：如果多个方法中，存在不同的连接指向，这种情况会提升为分布式事务，但.NET CORE 2.1仍未实现，在.NET FX4.5.2已经有此功能。
        /// </summary>
        /// <param name="action"></param>
        void TransactionScope(Action action);
        #endregion
    }

}
