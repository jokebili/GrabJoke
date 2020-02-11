using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public class SugarBase
    {

        public static string ConnectionString = "Data Source=.;Initial Catalog=JokesData;Persist Security Info=True;User ID=sa;Password=56tyghbn";
        /// <summary>  
        /// 获取ORM数据库连接对象(只操作数据库一次的使用, 否则会进行多次数据库连接和关闭)  
        /// 默认超时时间为30秒  
        /// 默认为MySql数据库  
        /// 默认自动关闭数据库链接, 多次操作数据库请勿使用该属性, 可能会造成性能问题  
        /// 要自定义请使用GetIntance()方法或者直接使用Exec方法, 传委托  
        /// </summary>  
        public static SqlSugarClient Db
        {
            get
            {
                return InitDB(1000, true);
            }
        }
        /// <summary>  
        /// 获得SqlSugarClient(使用该方法, 默认请手动释放资源, 如using(var db = SugarBase.GetIntance()){你的代码}, 如果把isAutoCloseConnection参数设置为true, 则无需手动释放, 会每次操作数据库释放一次, 可能会影响性能, 请自行判断使用)  
        /// </summary>  
        /// <param name="commandTimeOut">等待超时时间, 默认为30秒 (单位: 秒)</param>  
        /// <param name="dbType">数据库类型, 默认为SQL Server</param>  
        /// <param name="isAutoCloseConnection">是否自动关闭数据库连接, 默认不是, 如果设置为true, 则会在每次操作完数据库后, 即时关闭, 如果一个方法里面多次操作了数据库, 建议保持为false, 否则可能会引发性能问题</param>  
        /// <returns></returns>  
        /// <author>刘永超</author>  
        public static SqlSugarClient GetIntance(int commandTimeOut = 1000, bool isAutoCloseConnection = false)
        {
            return SugarBase.InitDB(commandTimeOut, isAutoCloseConnection);
        }

        /// <summary>  
        /// 初始化ORM连接对象, 一般无需调用, 除非要自己写很复杂的数据库逻辑  
        /// </summary>  
        /// <param name="commandTimeOut">等待超时时间, 默认为30秒 (单位: 秒)</param>  
        /// <param name="dbType">数据库类型, 默认为SQL Server</param>  
        /// <param name="isAutoCloseConnection">是否自动关闭数据库连接, 默认不是, 如果设置为true, 则会在每次操作完数据库后, 即时关闭, 如果一个方法里面多次操作了数据库, 建议保持为false, 否则可能会引发性能问题</param>  
        /// <author>刘永超</author>  
        private static SqlSugarClient InitDB(int commandTimeOut = 1000, bool isAutoCloseConnection = false)
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString,
                DbType = SqlSugar.DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = isAutoCloseConnection
            });
            db.Ado.CommandTimeOut = commandTimeOut;
            //调式代码 用来打印SQL 
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }

        /// <summary>  
        /// 执行数据库操作  
        /// </summary>  
        /// <typeparam name="Result">返回值类型</typeparam>  
        /// <param name="func">方法体</param>  
        /// <returns></returns>  
        /// <author>刘永超</author>  
        public static Result Exec<Result>(Func<SqlSugarClient, Result> func, int commandTimeOut = 1000)
        {
            if (func == null) throw new Exception("委托为null, 事务处理无意义");
            using (var db = InitDB(commandTimeOut))
            {
                try
                {
                    return func(db);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    db.Dispose();
                }
            }
        }

        /// <summary>  
        /// 带事务处理的执行数据库操作  
        /// </summary>  
        /// <typeparam name="Result">返回值类型</typeparam>  
        /// <param name="func">方法体</param>  
        /// <returns></returns>  
        /// <author>刘永超</author>  
        public static Result ExecTran<Result>(Func<SqlSugarClient, Result> func, int commandTimeOut = 1000)
        {
            if (func == null) throw new Exception("委托为null, 事务处理无意义");
            using (var db = InitDB(commandTimeOut))
            {
                try
                {
                    db.Ado.BeginTran(IsolationLevel.Unspecified);
                    var result = func(db);
                    db.Ado.CommitTran();
                    return result;
                }
                catch (Exception ex)
                {
                    db.Ado.RollbackTran();
                    throw ex;
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}
