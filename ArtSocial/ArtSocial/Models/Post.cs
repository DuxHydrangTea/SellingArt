using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ArtSocial.Models
{
    [Table("tblPost")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? PostContent { get; set; }
        public byte[]? ImageContent { get; set; }
        public string?  Imagemimetype { get; set; }
        public string? ImagePath { get; set; }
    }
}
