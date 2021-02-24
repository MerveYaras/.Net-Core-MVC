using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_PostgreSQL.Data.Entity
{
    public class Sepet
    {
        [Key]
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int UrunAdet { get; set; }
        public int UrunId { get; set; }

        [ForeignKey("KullaniciId")]
        public virtual Kullanici Kullanici { get; set; }
        [ForeignKey("UrunId")]
        public virtual Urun Urun { get; set; }

    }
}
