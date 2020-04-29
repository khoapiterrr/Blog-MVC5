using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQT.Entity
{
    [Table("ChucNang")]
    public partial class ChucNang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChucNang()
        {
            PhanQuyens = new HashSet<PhanQuyen>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string TenChucNang { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(100)]
        public string TenForm { get; set; }

        [StringLength(50)]
        public string Module { get; set; }

        public int? OrderNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyen> PhanQuyens { get; set; }
    }
}