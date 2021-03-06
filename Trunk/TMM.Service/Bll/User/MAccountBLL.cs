﻿//==============================================================================
//	CAUTION: This file is generated by IBatisNetGen.BLL.cst at 2010-12-17 22:06:24
//				By xincai.wu
//==============================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMM.Model;

namespace TMM.Service.Bll.User {

	/// <summary>
    /// 名称：MAccountDao 逻辑层
    /// 创建者：
    /// 创建时间：2011-1-9 11:06:52
    /// 功能描述：
    /// </summary>
    public partial class MAccountBLL {

        Dal.User.MAccountDal dal = new Dal.User.MAccountDal();

		/// <summary>
        /// 取得记录数
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <returns></returns>
		public int GetCount(Hashtable param) {
			return dal.GetCount(param);
		}

		/// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <param name="orderBy">排序方式:默认为“AccountId asc”</param>
        /// <param name="first">起始记录：从0开始</param>
        /// <param name="rows">提取的条数</param>
        /// <returns></returns>
		public IList<MAccount> GetList(Hashtable param,string orderBy,int first,int rows) 
		{
			return dal.GetList(param, orderBy, first, rows);
		}
		
		/// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
		public MAccount Get(Int32 accountId) {
			return dal.Get(accountId);
		}

		/// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>返回：该条数据的主键Id</returns>
		public int Insert(MAccount obj) {
			return dal.Insert(obj);
		}
		
		/// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
		public bool Update(MAccount obj) {
			return dal.Update(obj);
		}
        /// <summary>
        /// 冻结账户金额
        /// </summary>
        /// <param name="frozenAmount"></param>
        /// <param name="userId"></param>
        public void FrozenSomeAmount(decimal frozenAmount, int userId) {
            MAccount acc = GetByUserId(userId);
            if (frozenAmount > acc.Amount)
                throw new Exception("账户处理出错，代码：50");
            acc.FrozenAmount += frozenAmount;
            acc.Amount = acc.Amount - frozenAmount;
            acc.UpdateTime = DateTime.Now;
            Update(acc);
        }
		/// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
		public bool Delete(Int32 accountId) {
			return dal.Delete(accountId);
		}
        /// <summary>
        /// 提取账户信息，如果没有则新建账户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public MAccount GetByUserId(int userId) {
            MAccount acc = dal.GetByUserId(userId);
            if (acc == null) {
                acc = new MAccount() 
                { 
                    UserId = userId,
                    CreateTime = DateTime.Now
                };
                Insert(acc);
                acc = dal.GetByUserId(userId);
            }
            return acc;
        }
        /// <summary>
        /// 账户充值 for 订单
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="amount">金额</param>
        public bool AddAmount(decimal orderId, decimal amount,string ip,int payway)
        {
            Bll.Order.TOrderBLL obll = new TMM.Service.Bll.Order.TOrderBLL();
            Bll.Order.AccountLogBLL albll = new TMM.Service.Bll.Order.AccountLogBLL();

            TOrder o = obll.Get(orderId);
            //写账户日志
            AccountLog accLog = new AccountLog() { 
                UserId = o.UserId,
                OrderId = o.OrderId,
                Amount = amount,
                AccountWay = (int)AmountWay.In,
                Ip = ip,
                PayWay = payway
            };
            albll.Insert(accLog);
            //更新账户
            MAccount acc = GetByUserId(o.UserId);
            acc.Amount = acc.Amount + amount;
            return Update(acc);
        }
        /// <summary>
        /// 账户充值 for 出售文档收入
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddAmount(int userId, decimal amount) {
            MAccount acc = GetByUserId(userId);
            acc.Amount = acc.Amount + amount;
            return Update(acc);
        }
        /// <summary>
        /// 帐户充值 for 投稿收入（包含写帐户日志）
        /// </summary>
        /// <param name="userId">投稿人</param>
        /// <param name="amount"></param>
        /// <param name="ip"></param>
        /// <param name="payway"></param>
        /// <param name="remark">将悬赏文档的名称写入备注</param>
        /// <returns></returns>
        public bool AddAmount(int userId, decimal amount, string ip,string remark)
        {
            
            Bll.Order.AccountLogBLL albll = new TMM.Service.Bll.Order.AccountLogBLL();
            
            //写账户日志
            AccountLog accLog = new AccountLog()
            {
                UserId = userId,                
                Amount = amount,
                AccountWay = (int)AmountWay.INCOME_TG,
                Ip = ip,
                PayWay = 0,
                AdminRemark = remark
            };
            albll.Insert(accLog);
            //更新账户
            MAccount acc = GetByUserId(userId);
            acc.Amount = acc.Amount + amount;
            return Update(acc);
        }
        /// <summary>
        /// 账户花销（包含写帐户日志）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool AccountExpend(decimal orderId,string ip)
        {
            Bll.Order.TOrderBLL obll = new TMM.Service.Bll.Order.TOrderBLL();
            Bll.Order.AccountLogBLL albll = new TMM.Service.Bll.Order.AccountLogBLL();

            TOrder o = obll.Get(orderId);
            MAccount acc = GetByUserId(o.UserId);
            if (acc.Amount >= o.Total)
            {
                
                AccountLog accLog = new AccountLog()
                {
                    UserId = o.UserId,
                    OrderId = o.OrderId,
                    Amount = -o.Total,
                    AccountWay = (int)AmountWay.Out,
                    Ip = ip
                };

                albll.Insert(accLog);
                acc.Amount = acc.Amount - o.Total;                
                return Update(acc);
            }
            return false;
        }

        /// <summary>
        /// 帐户花销 for 购买悬赏文档（包含写帐户日志）
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="total"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool AccountExpend(int userId, decimal total, string ip,string remark)
        {
            
            Bll.Order.AccountLogBLL albll = new TMM.Service.Bll.Order.AccountLogBLL();
            
            MAccount acc = GetByUserId(userId);
            if (acc.Amount >= total)
            {

                AccountLog accLog = new AccountLog()
                {
                    UserId = userId,
                    Amount = -total,
                    AccountWay = (int)AmountWay.ROut,
                    Ip = ip,
                    PayWay = 0,
                    AdminRemark = remark
                };

                albll.Insert(accLog);
                acc.Amount = acc.Amount - total;
                return Update(acc);
            }
            return false;
        }
	}

}
