using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAuto
{
   public class DapperHelper<T>
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.	
        private static readonly  string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AgilityDbContext"].ConnectionString;
        private const string errMsg_InvalidConnection = "无效的数据库连接！请检查配置文件。";
        private static log4net.ILog log = log4net.LogManager.GetLogger("SqlHelper");

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql">查询的sql</param>
        /// <param name="param">替换参数</param>
        /// <returns></returns>
        public static List<T> Query(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                return con.Query<T>(sql, param).ToList();
            }
        }

        /// <summary>
        /// 查询第一个数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QueryFirst(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                return con.QueryFirst<T>(sql, param);
            }
        }

        /// <summary>
        /// 查询第一个数据没有返回默认值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QueryFirstOrDefault(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                return con.QueryFirstOrDefault<T>(sql, param);
            }
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QuerySingle(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                return con.QuerySingle<T>(sql, param);
            }
        }

        /// <summary>
        /// 查询单条数据没有返回默认值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QuerySingleOrDefault(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                return con.QuerySingleOrDefault<T>(sql, param);
            }
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int Execute(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                return con.Execute(sql, param);
            }
        }

        /// <summary>
        /// Reader获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                return con.ExecuteReader(sql, param);
            }
        }

        /// <summary>
        /// Scalar获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                return con.ExecuteScalar(sql, param);
            }
        }

        /// <summary>
        /// Scalar获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T ExecuteScalarForT(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                return con.ExecuteScalar<T>(sql, param);
            }
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static List<T> ExecutePro(string proc, object param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<T> list = con.Query<T>(proc,
                    param,
                    null,
                    true,
                    null,
                    CommandType.StoredProcedure).ToList();
                return list;
            }
        }


        /// <summary>
        /// 事务1 - 全SQL
        /// </summary>
        /// <param name="sqlarr">多条SQL</param>
        /// <param name="param">param</param>
        /// <returns></returns>
        public static int ExecuteTransaction(string[] sqlarr)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        int result = 0;
                        foreach (var sql in sqlarr)
                        {
                            result += con.Execute(sql, null, transaction);
                        }

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// 事务2 - 声明参数
        ///demo:
        ///dic.Add("Insert into Users values (@UserName, @Email, @Address)",
        ///        new { UserName = "jack", Email = "380234234@qq.com", Address = "上海" });
        /// </summary>
        /// <param name="Key">多条SQL</param>
        /// <param name="Value">param</param>
        /// <returns></returns>
        public static int ExecuteTransaction(Dictionary<string, object> dic)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        int result = 0;
                        foreach (var sql in dic)
                        {
                            result += con.Execute(sql.Key, sql.Value, transaction);
                        }

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }

        #region 参数拼接
        /// <summary>
        /// 获取类名字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ClassName<T>() => typeof(T).ToString().Split('.').Last();

        /// <summary>
        /// 属性名称拼接并附加连接符
        /// </summary>
        /// <param name="separator">分隔符</param>
        /// <param name="param">要拼接的动态类型</param>
        /// <param name="isParam">是否为参数,即是否增加前缀'@'</param>
        /// <returns></returns>
        public static string Joint(string separator, object param, bool isParam = false)
        {
            var prefix = isParam ? "@" : string.Empty;
            var propertys = param.GetType().GetProperties().Select(t => $"{prefix}{t.Name}").ToArray();
            var joint = new StringBuilder();
            for (var i = 0; i < propertys.Length; i++)
            {
                joint.Append(i != 0 ? $"{separator}{propertys[i]}" : propertys[i]);
            }
            return joint.ToString();
        }

        /// <summary>
        /// 以"param=@param"格式拼接属性名称并附加连接符
        /// </summary>
        /// <param name="separator">分隔符</param>
        /// <param name="param">要拼接的动态类型</param>
        /// <returns></returns>
        public static string ParamJoint(string separator, object param)
        {
            var propertys = param.GetType().GetProperties().Where(t => t.GetValue(param) != null).Select(t => t.Name).Select(t => $"{t}=@{t}").ToArray();
            var joint = new StringBuilder();
            for (var i = 0; i < propertys.Length; i++)
            {
                joint.Append(i != 0 ? $"{separator}{propertys[i]}" : propertys[i]);
            }
            return joint.ToString();
        }

        /// <summary>
        /// 将参数名和参数值拼接并附加连接符,用于where语句拼接
        /// </summary>
        /// <param name="separator"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string ValueJoint(string separator, object param)
        {
            var joint = new StringBuilder();
            var count = 0;
            foreach (var item in param.GetType().GetProperties())
            {
                var value = item.GetValue(param, null);
                if (value == null) continue;
                var slice = $"{item.Name}=\'{value}\'";
                joint.Append(count != 0 ? $"{separator}{slice}" : slice);
                count++;
            } 
            return joint.ToString();
        }
         #endregion

        #region 语句拼接
        public static string CompileInsert<T>(object param)
        {
            return $"insert into {ClassName<T>()}({Joint(",", param)}) values ({Joint(",", param, true)})";
        }

        public static string CompileDelete<T>(object param)
        {
            return $"delete from {ClassName<T>()} where {ParamJoint(" and ", param)}";
        }

        public static string CompileUpdate<T>(object setParam, object whereParam)
        {
            return $"update {ClassName<T>()} set {ValueJoint(",", setParam)} where {ValueJoint(" and ", whereParam)}";
        }

        public static string CompileSelect<T>(object param)
        {
            return $"select {Joint(",", param)} from {ClassName<T>()}";
        }
 
        #endregion

    }
}
