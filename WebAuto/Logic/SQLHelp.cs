using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ITrade.Common
{
    public class SqlHelper
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.	
        private static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["AgilityDbContext"].ConnectionString;
        private const string errMsg_InvalidConnection = "无效的数据库连接！请检查配置文件。";
        private static log4net.ILog log = log4net.LogManager.GetLogger("SqlHelper");






        private static string _errorMsg = string.Empty;
        /// <summary>
        /// 已弃用
        /// </summary>
        public SqlHelper()
        {
        }
        #region  执行简单SQL语句
        public string ErrorMessage
        {
            get { return _errorMsg; }
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        _errorMsg = e.Message;
                        throw e;

                    }
                    finally
                    {
                        if (null != connection)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        _errorMsg = e.Message;
                        throw e;

                    }
                    finally
                    {
                        if (null != connection)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParams)
        {
            if (strConnection.Trim().Length == 0)
                throw new Exception(errMsg_InvalidConnection);

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, SQLString, cmdParams);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        public static int ExecuteSql(string SQLString, string strConnection, params SqlParameter[] cmdParams)
        {
            if (strConnection.Trim().Length == 0)
                throw new Exception(errMsg_InvalidConnection);

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, SQLString, cmdParams);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 多条SQL的执行，支持事物
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="commandtype">SQL类型</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static int ExcuteTransaction(List<string> sql, List<CommandType> commandtype, List<IDataParameter[]> parameters)
        {
            if (sql == null || commandtype == null)
            {
                return 0;
            }

            if (sql.Count != commandtype.Count)
            {
                return 0;
            }

            int count = 0;
            using (IDbConnection conn = new SqlConnection(strConnection))
            {
                try
                {
                    conn.Open();
                    using (IDbTransaction trans = conn.BeginTransaction())
                    {
                        var i = 0;
                        try
                        {
                            IDbCommand cmd;
                            for (; i < sql.Count; i++)
                            {
                                cmd = PrepareCommand(conn, trans, sql[i], commandtype[i], parameters[i]);
                                count += cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                            trans.Commit();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(sql[i]);
                            trans.Rollback();
                            throw e;
                        }
                    }
                    return count;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static int ExecuteSqlTran(List<String> SQLStringList, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    //throw ex;
                    _errorMsg = ex.Message;
                    return 0;
                }
                finally
                {
                    if (null != conn)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    //throw ex;
                    _errorMsg = ex.Message;
                    return 0;
                }
                finally
                {
                    if (null != conn)
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        //public static DataSet Query(string SQLString, string connectionString)
        //{
        //    return Query(SQLString, connectionString);
        //}

        public static DataSet Query(string SQLString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //throw new Exception(ex.Message);
                    _errorMsg = ex.Message;
                }
                finally
                {
                    if (null != connection)
                    {
                        connection.Close();
                    }
                }
                return ds;
            }
        }

        public static DataSet Query(string SQLString)
        {
            return Query(SQLString, strConnection);
        }

        public static DataSet Query(string SQLString, params SqlParameter[] cmdParams)
        {
            if (strConnection.Trim().Length == 0)
                throw new Exception(errMsg_InvalidConnection);

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(strConnection))
            {

                PrepareCommand(cmd, conn, null, CommandType.Text, SQLString, cmdParams);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }
        public static DataSet ExecuteDataSet(string cmdText, params SqlParameter[] cmdParms)
        {
            return ExecuteDataSet(CommandType.Text, cmdText, cmdParms);
        }
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            return ExecuteDataSet(strConnection, cmdType, cmdText, cmdParms);
        }
        /// <summary>
        /// 读取并返回表数据。
        /// </summary>
        /// <param name="connString">数据库连接字符串</param>
        /// <param name="cmdType">查询类型：SQL语句方式/存储过程方式</param>
        /// <param name="cmdText">SQL语句/存储过程名称</param>
        /// <param name="cmdParms">查询参数</param>
        /// <returns>数据集合</returns>
        public static DataSet ExecuteDataSet(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            if (connString.Trim().Length == 0)
                throw new Exception(errMsg_InvalidConnection);

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                log.Debug("/****************  " + cmdText + "  **********************/");
                DateTime d1 = DateTime.Now;
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                DateTime d2 = DateTime.Now;
                log.Debug("excute time : " + (d2 - d1).TotalSeconds);
                return ds;
            }
        }
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }



        #endregion


        #region 内部方法
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
         /// <summary>
        /// SQL的执行命令设置
       /// </summary>
       /// <param name="iConn">连接</param>
       /// <param name="iTrans">事务</param>
       /// <param name="cmdText">sql语句</param>
       /// <param name="cmdType">sql类型</param>
       /// <param name="iParms">参数</param>
       /// <returns></returns>
        private static IDbCommand PrepareCommand(IDbConnection iConn, System.Data.IDbTransaction iTrans,
            string cmdText, CommandType cmdType, params IDataParameter[] iParms)
        {

            if (iConn.State != ConnectionState.Open)
                iConn.Open();
            IDbCommand iCmd = new SqlCommand();
            iCmd.Connection = iConn;
            iCmd.CommandText = cmdText; 
            if (iTrans != null)
                iCmd.Transaction = iTrans;
            iCmd.CommandType = cmdType;//cmdType; 
            if (iParms != null)
            {
                foreach (IDataParameter parm in iParms)
                    if (parm!=null)
                        iCmd.Parameters.Add((SqlParameter)((ICloneable)parm).Clone());
                int index = 0;
                foreach (IDataParameter item in iCmd.Parameters)
                {
                    iParms[index++] = item;
                }
            }
            return iCmd;
        }
        #endregion
    }
    public class CommonPager
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("CommonPager");
        private static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["AgilityDbContext"].ConnectionString;
        //public static DataSet GetListByPage(string strSql, int index, int pageSize, out int pcount, out int record)
        //{
        //    DataSet ds = new DataSet();
        //    record = 0;
        //    pcount = 0;

        //    try
        //    {
        //        log.Debug("/****************  " + strSql + "  **********************/");
        //        DateTime d1 = DateTime.Now;
        //        if (index == 0 || pageSize == 0)
        //        {
        //            ds = OracleHelper.ExecuteDataSet(CommandType.Text, strSql);
        //            record = ds.Tables[0].Rows.Count;
        //            return ds;
        //        }

        //        OracleParameter[] param = new OracleParameter[] {
        //    new OracleParameter("Pindex", OracleType.Number),
        //    new OracleParameter("Psql", OracleType.LongVarChar),
        //    new OracleParameter("Psize", OracleType.Number), 
        //    new OracleParameter("Pcount", OracleType.Number),
        //    new OracleParameter("Prcount", OracleType.Number),
        //    new OracleParameter("v_cur", OracleType.Cursor) };
        //        param[0].Value = index;
        //        param[1].Value = strSql;
        //        param[2].Value = pageSize;

        //        param[0].Direction = ParameterDirection.Input;
        //        param[1].Direction = ParameterDirection.Input;
        //        param[2].Direction = ParameterDirection.Input;
        //        param[3].Direction = ParameterDirection.Output;
        //        param[4].Direction = ParameterDirection.Output;
        //        param[5].Direction = ParameterDirection.Output;

        //        ds = OracleHelper.ExecuteDataSet(CommandType.StoredProcedure, "P_page.Pagination", param);

        //        if (param[3].Value == null)
        //            pcount = 0;
        //        else
        //            pcount = int.Parse(param[3].Value.ToString());

        //        if (param[4].Value == null)
        //            record = 0;
        //        else
        //            record = int.Parse(param[4].Value.ToString());

        //        DateTime d2 = DateTime.Now;
        //        log.Debug("excute time : " + (d2 - d1).TotalSeconds);


        //    }
        //    catch (Exception ex)
        //    {
        //        log.Debug("Exception : " + ex.Message);
        //    }
        //    return ds;
        //}
        /// <summary>
        /// 获取分页的数据
        /// </summary>
        /// <param name="TblName">数据表名</param>
        /// <param name="Fields">要读取的字段</param>
        /// <param name="OrderField">排序字段</param>
        /// <param name="SqlWhere">查询条件</param>
        /// <param name="PageSize">每页显示多少条数据</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="TotalPage">返回值，共有多少页</param>
        /// <returns></returns>
        public static DataSet GetListByPage2(string TblName, string Fields, string OrderField, string SqlWhere, int PageSize, int pageIndex, out int TotalPage, out int record)
        {

            TotalPage = 0;
            record = 0;
            //DbObject db = new DbObject();

            //string connString = db.ConnectionString;
            int start = (pageIndex - 1) * PageSize + 1;
            int end = (pageIndex - 1) * PageSize + PageSize;
            string page = string.Format(@"Select * FROM (select ROW_NUMBER() Over(order by {0}) as rowId,{1} from {2} where 1=1 {3}) as A where rowId between {4} and {5}", OrderField, Fields, TblName, SqlWhere, start, end);
            string count = string.Format(@" Select count(1) FROM (select {0} from {1} where 1=1 {2}) as A", Fields, TblName, SqlWhere);

            DataSet ds = new DataSet();
            ds = SqlHelper.Query(page);
            DataSet dsCount = new DataSet();
            dsCount = SqlHelper.Query(count);


            //comm.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(comm);
            //DataSet ds = new DataSet();
            //dataAdapter.Fill(ds);
            //TotalPage = (int)comm.Parameters[6].Value;           

            //conn.Close();
            //conn.Dispose();
            //comm.Dispose();
            //db.Dispose();
            if (Convert.ToInt32(dsCount.Tables[0].Rows[0][0]) % PageSize != 0)
            {
                TotalPage = Convert.ToInt32(dsCount.Tables[0].Rows[0][0]) / PageSize + 1;
            }
            else
            {
                TotalPage = Convert.ToInt32(dsCount.Tables[0].Rows[0][0]) / PageSize;
            }
            record = Convert.ToInt32(dsCount.Tables[0].Rows[0][0]);
            return ds;

        }
        public static DataSet GetListByPage2(string TblName, string Fields, string OrderField, string SqlWhere, int PageSize, int pageIndex, out int TotalPage, out int record, string strConnection)
        {

            TotalPage = 0;
            record = 0;
            //DbObject db = new DbObject();

            //string connString = db.ConnectionString;
            int start = (pageIndex - 1) * PageSize + 1;
            int end = (pageIndex - 1) * PageSize + PageSize;
            string page = string.Format(@"Select * FROM (select ROW_NUMBER() Over(order by {0}) as rowId,{1} from {2} where 1=1 {3}) as A where rowId between {4}
                            and {5}", OrderField, Fields, TblName, SqlWhere, start, end);
            string count = string.Format(@" Select count(1) FROM (select {0} from {1} where 1=1 {2}) as A", Fields, TblName, SqlWhere);

            DataSet ds = new DataSet();
            ds = SqlHelper.Query(page, strConnection);
            DataSet dsCount = new DataSet();
            dsCount = SqlHelper.Query(count, strConnection);


            //comm.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(comm);
            //DataSet ds = new DataSet();
            //dataAdapter.Fill(ds);
            //TotalPage = (int)comm.Parameters[6].Value;           

            //conn.Close();
            //conn.Dispose();
            //comm.Dispose();
            //db.Dispose();
            if (Convert.ToInt32(dsCount.Tables[0].Rows[0][0]) % PageSize != 0)
            {
                TotalPage = Convert.ToInt32(dsCount.Tables[0].Rows[0][0]) / PageSize + 1;
            }
            else
            {
                TotalPage = Convert.ToInt32(dsCount.Tables[0].Rows[0][0]) / PageSize;
            }
            record = Convert.ToInt32(dsCount.Tables[0].Rows[0][0]);
            return ds;

        }
        public static DataSet GetDataSet(string TblName, string Fields, string OrderField, string SqlWhere)
        {
            string count = string.Format(@" Select * FROM (select ROW_NUMBER() Over(order by {0}) as rowId,{1} from {2} where 1=1 {3}) as A", OrderField, Fields, TblName, SqlWhere);

            DataSet dsCount = new DataSet();
            dsCount = SqlHelper.Query(count);

            return dsCount;

        }
        public static DataSet GetDataSet(string TblName, string Fields, string OrderField, string SqlWhere, string strConnection)
        {
            string count = string.Format(@" Select * FROM (select ROW_NUMBER() Over(order by {0}) as rowId,{1} from {2} where 1=1 {3}) as A", OrderField, Fields, TblName, SqlWhere);

            DataSet dsCount = new DataSet();
            dsCount = SqlHelper.Query(count, strConnection);

            return dsCount;

        }
        /// <summary>
        /// 获取分页的数据
        /// </summary>
        /// <param name="TblName">数据表名</param>
        /// <param name="Fields">要读取的字段</param>
        /// <param name="OrderField">排序字段</param>
        /// <param name="SqlWhere">查询条件</param>
        /// <param name="PageSize">每页显示多少条数据</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="TotalPage">返回值，共有多少页</param>
        /// <returns></returns>
        public static DataSet GetListByPageProc(string TblName, string Fields, string OrderField, string SqlWhere, int PageSize, int pageIndex, out int TotalPage, out int record)
        {
            SqlParameter[] sp=new SqlParameter[10];
            int index=0;
            sp[index++] = new SqlParameter("@TableFields", Fields);
            sp[index++] = new SqlParameter("@TableName", TblName);
            sp[index++] = new SqlParameter("@SqlWhere", SqlWhere);
            sp[index++] = new SqlParameter("@OrderBy", OrderField);
            sp[index++] = new SqlParameter("@PageIndex", pageIndex);
            sp[index++] = new SqlParameter("@PageSize", PageSize);
            sp[index++] = new SqlParameter("@TotalCount", 0);
            DataSet ds = new DataSet();
            ds = SqlHelper.RunProcedure("Proc_Paging", sp, "PagerData");
            DataSet dsCount = new DataSet();
            if (Convert.ToInt32(dsCount.Tables[0].Rows[0][0]) % PageSize != 0)
            {
                TotalPage = Convert.ToInt32(dsCount.Tables[0].Rows[0][0]) / PageSize + 1;
            }
            else
            {
                TotalPage = Convert.ToInt32(dsCount.Tables[0].Rows[0][0]) / PageSize;
            }
            record = Convert.ToInt32(dsCount.Tables[0].Rows[0][0]);
            return ds;

        }
     
    }
}
