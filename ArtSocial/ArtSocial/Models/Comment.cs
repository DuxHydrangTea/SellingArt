using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtSocial.Models
{
    [Table("View_ListComments")]
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int? UserID { get; set; }
        public int? ArtID { get; set; }
        public string? CommentText { get; set; }
       
        public DateTime? CreatedDate { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? AvatarPath { get; set; }
        
    }
}
