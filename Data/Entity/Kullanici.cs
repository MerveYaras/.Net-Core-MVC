using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_PostgreSQL.Data.Entity
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Sifre { get; set; }
        public bool RememberMe { get; set; }
        public string EMail { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

    }
}
