using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meus_Produtos.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        [Required]
        public long Id { get; set; }

        [Column("product_name")]
        [Required]
        [MaxLength(80), MinLength(3)]
        public string ProductName { get; set; }

        [Column("product_price")]
        [Required]
        [Range(0, 99999999.99)]
        public decimal ProductPrice { get; set; }

        [Column("product_is_active")]
        [Required]
        public bool isActive { get; set; }
    }
}
