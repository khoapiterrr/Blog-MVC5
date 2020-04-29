using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQT.Entity
{
    public class ContactEntity : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        public string Message { get; set; }
    }
}