using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtSocial.Models
{
    [Table("tblMenu")]
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        public string? MenuName { get; set; }
        public int? MenuOrder { get; set; }
        public int? ParentID { get; set; }
        public int? Position { get; set; }
        public string? Link { get; set; }
        public bool? ofAdmin { get; set; }
    }
}
