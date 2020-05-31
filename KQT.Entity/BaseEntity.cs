using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQT.Entity
{
    public class BaseEntity
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// 1 - Hoạt động
        /// 2 - Không hoạt động
        /// </summary>
        public int Status { get; set; }
    }
}