using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQT.Entity
{
    [Table("PhanQuyen")]
    public partial class PhanQuyen
    {
        public int Id { get; set; }

        public int? ChucNangId { get; set; }

        public int? VaiTroId { get; set; }

        public bool? Xem { get; set; }

        public bool? Them { get; set; }

        public bool? Sua { get; set; }

        public bool? Xoa { get; set; }

        public bool? BaoCao { get; set; }

        public virtual ChucNang ChucNang { get; set; }

        public virtual VaiTro VaiTro { get; set; }
    }
}