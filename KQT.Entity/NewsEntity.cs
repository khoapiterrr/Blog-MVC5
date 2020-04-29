using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQT.Entity
{
    [Table("News")]
    public class NewsEntity : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string NewTitle { get; set; }

        public string NewTitleSale { get; set; }

        [Column(TypeName = "ntext")]
        public string NewContentHead { get; set; }

        [Column(TypeName = "ntext")]
        public string NewContentBody { get; set; }

        [Column(TypeName = "ntext")]
        public string NewContentFooter { get; set; }

        [StringLength(4000)]
        public string ImageHead { get; set; }

        [StringLength(4000)]
        public string ImageBody { get; set; }

        [StringLength(4000)]
        public string ImageFooter { get; set; }

        public int ViewCount { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
    }
}