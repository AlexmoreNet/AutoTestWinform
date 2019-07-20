using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using WebApplication3.Models;

namespace WebApplication4.Models
{
    public class DapperHelper
    {
        public int insert<T>( T Music)
        {
            IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=NFineBase;User ID=sa;Password=abc.123");
            //Insert
            string insetSql = string.Format("INSERT " +
                "dbo.Musics([Title],[SingerId],[GenreId])VALUES(@Title, @SingerId, @GenreId)");
             
            var result = conn.Execute(insetSql, Music);
            return result;
        }
    }
}
