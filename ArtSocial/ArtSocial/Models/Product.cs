using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace ArtSocial.Models
{
    [Table("tblArtProduct")]
    public class Product
    {
        [Key]
        public int ArtID { get; set; }
        public string? ArtName { get; set; }
        public int? CategoryID { get; set; }
        public string? Abstract { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UserID { get; set; } 
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? Prices { get; set; }
        public bool? Accept { get; set; }

        public bool? Selled { get; set; }
    }
}
