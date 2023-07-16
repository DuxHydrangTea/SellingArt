using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ArtSocial.Models
{
    [Table("tblComment")]
    public class BaseComment
    {
        [Key]
        public int CommentID { get; set; }
        public int? UserID { get; set; }
        public int? ArtID { get; set; }
        public string? CommentText { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
