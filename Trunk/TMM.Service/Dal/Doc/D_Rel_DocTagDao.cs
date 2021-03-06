﻿//==============================================================================
//	CAUTION: This file is generated by IBatisNetGen.DaoImpl.cst at 2010-11-29 15:51:35
//				By xincai.wu
//==============================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMM.Model;
using TMM.Persistence;


namespace TMM.Service.Dal.Doc {

	/// <summary>
    /// 名称：DRelDocTagDao 数据层
    /// 开发者：
    /// 创建时间：2010-11-29 19:03:15
    /// 功能描述：
    /// </summary>
    public partial class D_Rel_DocTagDal {

		/// <summary>
        /// 取得记录数
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <returns></returns>
		public int GetCount(Hashtable param) {
			if (param == null)
                param = new Hashtable();
				
			String stmtId = "D_Rel_DocTag.GetCount";
			return SqlMapper.Instance().QueryForObject<int>(stmtId, null);
		}

		/// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <param name="orderBy">排序方式:默认为“Id asc”</param>
        /// <param name="first">起始记录：从0开始</param>
        /// <param name="rows">提取的条数</param>
        /// <returns></returns>
		public IList<D_Rel_DocTag> GetList(Hashtable param,string orderBy,int first,int rows) 
		{
			if (param == null)
                param = new Hashtable();

            param.Add("Top", first+ rows);
            param.Add("StartRecord", first);

            if (string.IsNullOrEmpty(orderBy))
                param.Add("OrderBy", "Id asc");
			else
                param.Add("OrderBy", orderBy);
				
			String stmtId = "D_Rel_DocTag.GetList";
			return SqlMapper.Instance().QueryForList<D_Rel_DocTag>(stmtId, param);
		}
		
		/// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public D_Rel_DocTag Get(Int32 id) {
			String stmtId = "D_Rel_DocTag.Get";
			return SqlMapper.Instance().QueryForObject<D_Rel_DocTag>(stmtId, id);
		}

		/// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>返回：该条数据的主键Id</returns>
		public int Insert(D_Rel_DocTag obj) {
			if (obj == null) throw new ArgumentNullException("obj");
			String stmtId = "D_Rel_DocTag.Insert";
			return SqlMapper.Instance().QueryForObject<int>(stmtId, obj);
		}
		
		/// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
		public bool Update(D_Rel_DocTag obj) {
			if (obj == null) throw new ArgumentNullException("obj");
			String stmtId = "D_Rel_DocTag.Update";
			int result = SqlMapper.Instance().QueryForObject<int>(stmtId, obj);
			return result > 0 ? true : false;
		}
		
		/// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
		public bool Delete(Int32 id) {
			String stmtId = "D_Rel_DocTag.Delete";
			int result = SqlMapper.Instance().QueryForObject<int>(stmtId, id);
			return result > 0 ? true : false;
		}

        public void DeleteDoc(int docId) {
            String stmtId = "D_Rel_DocTag.DeleteDoc";
            SqlMapper.Instance().Delete(stmtId, docId);
        }
		
	}

}
