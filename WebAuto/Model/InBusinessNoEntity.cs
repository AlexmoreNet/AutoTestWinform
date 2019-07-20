using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAuto.Model
{
    public class InBusinessNoEntity
    {
        public string BusinessNo { get; set; }
        /// <summary>
        /// 申报地海关
        /// </summary>
        public string customMasterName { get; set; }
        /// <summary>
        /// 备案号
        /// </summary>
        public string manualNo { get; set; }
        /// <summary>
        /// 合同协议号
        /// </summary>
        public string contrNo { get; set; }
        /// <summary>
        /// 进口日期yyyyMMdd
        /// </summary>
        public string iEDate { get; set; }
        /// <summary>
        /// 境内收发货人信用代码
        /// </summary>
        public string rcvgdTradeScc { get; set; }
        /// <summary>
        /// 境内收发货人海关编码
        /// </summary>
        public string rcvgdTradeCode { get; set; }
        /// <summary>
        /// 境内收发货人检验检疫编码
        /// </summary>
        public string consigneeCode { get; set; }
        /// <summary>
        /// 境内收发货人公司名称
        /// </summary>
        public string consigneeCname { get; set; }
        /// <summary>
        /// 境外收发货人公司名称
        /// </summary>
        public string consignorEname  { get; set; }
        /// <summary>
        /// 境外收发货人公司代码
        /// </summary>
        public string consignorCode { get; set; }
        /// <summary>
        /// 消费使用单位社会信用代码
        /// </summary>
        public string ownerScc { get; set; }
        /// <summary>
        /// 消费使用单位海关编码
        /// </summary>
        public string ownerCode { get; set; }
        /// <summary>
        /// 消费使用单位检验检疫编码
        /// </summary>
        public string ownerCiqCode { get; set; }
        /// <summary>
        /// 消费使用单位名称
        /// </summary>
        public string ownerName { get; set; }
        /// <summary>
        /// 运输方式
        /// </summary>
        public string cusTrafModeName { get; set; }
        /// <summary>
        /// 运输工具名称
        /// </summary>
        public string trafName { get; set; }
        /// <summary>
        /// 航次号
        /// </summary>
        public string cusVoyageNo { get; set; }
        /// <summary>
        /// 提运单号
        /// </summary>
        public string billNo { get; set; }

        /// <summary>
        /// 监管方式
        /// </summary>
        public string supvModeCdde { get; set; }
        /// <summary>
        /// 征免性质
        /// </summary>
        public string cutModeName { get; set; }
        /// <summary>
        /// 许可证号
        /// </summary>
        public string licenseNo { get; set; }
        /// <summary>
        /// 启运国(地区)
        /// </summary>
        public string cusTradeCountry { get; set; }
        /// <summary>
        /// 经停港	
        /// </summary>
        public string distinatePortName { get; set; }
        /// <summary>
        /// 成交方式	
        /// </summary>
        public string transModeName { get; set; }
        /// <summary>
        /// 运费	
        /// </summary>
        public string feeRate { get; set; }
        /// <summary>
        /// 运费币制
        /// </summary>
        public string feeCurrName { get; set; }
        /// <summary>
        /// 运费计算方式
        /// </summary>
        public string feeMarkName { get; set; }
        /// <summary>
        /// 保险费	
        /// </summary>
        public string insurRate { get; set; }
        /// <summary>
        /// 保险费币制
        /// </summary>
        public string insurCurrName { get; set; }
        /// <summary>
        /// 保险费计算方式
        /// </summary>
        public string insurMarkName { get; set; }

        /// <summary>
        /// 杂费		
        /// </summary>
        public string otherRate { get; set; }
        /// <summary>
        /// 杂费币制
        /// </summary>
        public string otherCurrName { get; set; }
        /// <summary>
        /// 杂费计算方式
        /// </summary>
        public string otherMark { get; set; }
        /// <summary>
        /// 件数
        /// </summary>
        public string packNo { get; set; }

        /// <summary>
        /// 包装种类	
        /// </summary>
        public string wrapTypeName { get; set; }
        /// <summary>
        /// 毛重(KG)	
        /// </summary>
        public string grossWt { get; set; }
        /// <summary>
        /// 净重(KG)	
        /// </summary>
        public string netWt { get; set; }
        /// <summary>
        /// 贸易国别(地区)	
        /// </summary>
        public string cusTradeNationCodeName { get; set; }


        /// <summary>
        /// 入境口岸	
        /// </summary>
        public string ciqEntyPortCodeName { get; set; }
        /// <summary>
        /// 货物存放地点
        /// </summary>
        public string goodsPlace { get; set; }
        /// <summary>
        /// 启运港	
        /// </summary>
        public string despPortCodeName { get; set; }
        /// <summary>
        /// 报关单类型	
        /// </summary>
        public string entryTypeName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string noteS { get; set; }
        /// <summary>
        /// 标记唛码	
        /// </summary>
        public string markNo { get; set; }

    }
}
