//==============================================================================
//	CAUTION: This file is generated by IBatisNetGen.Entity.cst at 2010-12-17 22:06:28
//				Any manual editing will be lost in re-generation.
//==============================================================================
using System;
using System.Collections.Generic;
using System.Text;

namespace TMM.Model  {
	
    /// <summary><c>DownloadLog</c> Business Object.</summary>
    [Serializable]
    public partial class DownloadLog {
        
        #region LogId

        private Int32 m_logId;
		
		/// <summary>Gets or sets LogId</summary>
        public Int32 LogId {
        	get { return m_logId; }
        	set { m_logId = value;}        
        }
		
	    #endregion
		
        #region DocId

        private Int32 m_docId;
		
		/// <summary>Gets or sets DocId</summary>
        public Int32 DocId {
        	get { return m_docId; }
        	set { m_docId = value;}        
        }
		
	    #endregion
		
        #region UserId

        private Int32 m_userId;
		
		/// <summary>Gets or sets UserId</summary>
        public Int32 UserId {
        	get { return m_userId; }
        	set { m_userId = value;}        
        }
		
	    #endregion
		
        #region CreateTime

        private DateTime? m_createTime;
		
		/// <summary>Gets or sets CreateTime</summary>
        public DateTime? CreateTime {
        	get { return m_createTime; }
        	set { m_createTime = value;}        
        }
		
	    #endregion
		

	}
	
}
