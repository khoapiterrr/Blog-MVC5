using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KQT.Web.Areas.Admin.Model
{
    public class JsonPostBack
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="message">Thông báo cần trả về</param>
        /// <param name="issuccess">có thành công hay không</param>
        public JsonPostBack(string message, bool issuccess)
        {
            this.Message = message;
            this.isSuccess = issuccess;
        }

        public string Message { get; set; }
        public bool isSuccess { get; set; }
    }
}