using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meus_Produtos.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        [Column("user_id")]
        public long Id { get; set; }

        [Column("user_name")]
        [Required(ErrorMessage = "The email address is required")]
        [MaxLength(20), MinLength(3)]
        public string UserName { get; set; }

        [Column("user_password")]
        [Required(ErrorMessage = "The email address is required")]
        [MaxLength(20), MinLength(8)]
        public string UserPassword { get; set; }

        [Column("user_email")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserEmail { get; set; }
    }
}
