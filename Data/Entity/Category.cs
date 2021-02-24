using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_PostgreSQL.Data.Entity
{
    [Table(name: "Kategori", Schema="public")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
    }
}
