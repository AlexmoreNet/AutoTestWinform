using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAuto.Model;

namespace WebAuto
{
    public class LogicDal
    {
        public InBusinessNoEntity GetBusinessNoEntity(InBusinessNoEntity sqlparam)
        {
            //string sql = DapperHelper<InBusinessNoEntity>.CompileSelect<InBusinessNoEntity>(sqlparam);
            string sql = string.Format(@"select * FROM  Orders");
           return  DapperHelper<InBusinessNoEntity>.QuerySingle(sql,sqlparam);
        }
    }
}
