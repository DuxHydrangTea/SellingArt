using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtSocial.Models
{
    [Table("View_DetailProduct")]
    public class DetailProduct
    {
        [Key]
        public int ArtID { get; set; }
        public string? ArtName { get; set; }
        public int? CategoryID { get; set; }
        public string? Abstract { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UserID { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int? Prices { get; set; }
        public string? FullName { get; set; }
        public string? AvatarPath { get; set; }
        public bool? isAdmin { get; set; }
        public string? CategoryName { get; set; }

        public bool? Accept { get; set; }

    }
}
