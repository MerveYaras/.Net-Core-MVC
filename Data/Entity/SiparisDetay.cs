using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_PostgreSQL.Data.Entity
{
    public class SiparisDetay
    {
        [Key]
        public int Id { get; set; }
        public int UrunId { get; set; }
        public int SiparisId { get; set; }
        public int UrunAdet { get; set; }
        public decimal UrunFiyat { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urun Urun { get; set; }

        [ForeignKey("SiparisId")]
        public virtual Siparis Siparis { get; set; }
    }
}
