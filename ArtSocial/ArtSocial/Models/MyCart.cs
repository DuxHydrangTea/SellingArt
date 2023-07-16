using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ArtSocial.Models
{
    [Table("tblMyCart")]
    public class MyCart
    {
        [Key]
        public int CartID { get; set; }
        public int UserBuyID { get; set; }
        public int ArtID { get; set; }
        public string? Description { get; set; }
    }
}
