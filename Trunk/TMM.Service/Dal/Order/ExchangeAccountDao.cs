﻿//==============================================================================
//	CAUTION: This file is generated by IBatisNetGen.DaoImpl.cst at 2010-12-17 22:06:26
//				By xincai.wu
//==============================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMM.Model;
using TMM.Persistence;


namespace TMM.Service.Dal.Order {

	/// <summary>
    /// 名称：ExchangeAccountDao 数据层
    /// 开发者：
    /// 创建时间：2011-1-23 16:19:00
    /// 功能描述：
    /// </summary>
    public partial class ExchangeAccountDal {

		/// <summary>
        /// 取得记录数
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <returns></returns>
		public int GetCount(Hashtable param) {
			if (param == null)
                param = new Hashtable();
				
			String stmtId = "ExchangeAccount.GetCount";
			return SqlMapper.Instance().QueryForObject<int>(stmtId, param);
		}

		/// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <param name="orderBy">排序方式:默认为“AccountId asc”</param>
        /// <param name="first">起始记录：从0开始</param>
        /// <param name="rows">提取的条数</param>
        /// <returns></returns>
		public IList<ExchangeAccount> GetList(Hashtable param,string orderBy,int first,int rows) 
		{
			if (param == null)
                param = new Hashtable();

            param.Add("Top", first+ rows);
            param.Add("StartRecord", first);

            if (string.IsNullOrEmpty(orderBy))
                param.Add("OrderBy", "AccountId desc");
			else
                param.Add("OrderBy", orderBy);
				
			String stmtId = "ExchangeAccount.GetList";
			return SqlMapper.Instance().QueryForList<ExchangeAccount>(stmtId, param);
		}
		
		/// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
		public ExchangeAccount Get(Int32 accountId) {
			String stmtId = "ExchangeAccount.Get";
			return SqlMapper.Instance().QueryForObject<ExchangeAccount>(stmtId, accountId);
		}

		/// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>返回：该条数据的主键Id</returns>
		public int Insert(ExchangeAccount obj) {
			if (obj == null) throw new ArgumentNullException("obj");
			String stmtId = "ExchangeAccount.Insert";
			return SqlMapper.Instance().QueryForObject<int>(stmtId, obj);
		}
		
		/// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
		public bool Update(ExchangeAccount obj) {
			if (obj == null) throw new ArgumentNullException("obj");
			String stmtId = "ExchangeAccount.Update";
			int result = SqlMapper.Instance().QueryForObject<int>(stmtId, obj);
			return result > 0 ? true : false;
		}
		
		/// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
		public bool Delete(Int32 accountId) {
			String stmtId = "ExchangeAccount.Delete";
			int result = SqlMapper.Instance().QueryForObject<int>(stmtId, accountId);
			return result > 0 ? true : false;
		}
		
	}

}