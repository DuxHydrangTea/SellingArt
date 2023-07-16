using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ArtSocial.Models
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? AvatarPath { get; set; }
        public int? Wallet { get; set; }
        public string? MoTa { get; set; }
        public bool? isAdmin { get; set; }
    }
}
