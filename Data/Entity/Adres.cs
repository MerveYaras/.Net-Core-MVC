using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_PostgreSQL.Data.Entity
{
    public class Adres
    {
        [Key]
        public int Id { get; set; }
        public string KullaniciAd { get; set; }
        public string AdresBaslik { get; set; }
        public int KullaniciId { get; set; }
        public string EMail { get; set; }
        public string Telefon { get; set; }
        public string YeniAdres { get; set; }

        [ForeignKey("KullaniciId")]
        public virtual Kullanici Kullanici { get; set; }
    }
}
