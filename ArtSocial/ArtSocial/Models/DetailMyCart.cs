using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ArtSocial.Models
{
    [Table("View_MyCart")]
    public class DetailMyCart
    {
        [Key]
        public int CartID { get; set; }
        public int UserBuyID { get; set; }
        public int ArtID { get; set; }
        public string? ArtName { get; set; }
        public string? Abstract { get; set; }
        public string? Image { get; set; }
        public int? Prices { get; set; }
    }
}
