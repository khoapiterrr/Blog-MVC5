using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KQT.Web.Areas.Admin.Model
{
    public class ConstantCommon
    {
        /// <summary>
        /// hoạt động nhật kí hệ thống
        /// </summary>
        public enum Action
        {
            Add = 1,
            Edit = 2,
            Update = 3,
            Delete = 4,
            View = 5,
            Report = 6,
            Login = 7,
            Logout = 8,
            ChangePassword = 9
        }

        private static string _FolderData = System.Configuration.ConfigurationManager.AppSettings["FolderImages"];

        public static string FolderData
        {
            get { return _FolderData; }
        }
    }
}