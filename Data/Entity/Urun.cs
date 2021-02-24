using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_PostgreSQL.Data.Entity
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string ImageUrl { get; set; }
        public int KategoriId { get; set; }
        public virtual Category Category { get; set; }
    }
}
