using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQT.Entity
{
    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string Avatar { get; set; }

        [StringLength(30)]
        public string HoTen { get; set; }

        [StringLength(20)]
        public string DienThoai { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        public DateTime? NgayTao { get; set; }

        public int? VaiTroId { get; set; }

        public virtual VaiTro VaiTro { get; set; }
    }
}