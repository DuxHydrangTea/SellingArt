using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtSocial.Models
{
	[Table("tblCategory")]
	public class Category
	{
		[Key]
		public int CategoryID { get; set; }
		public string? CategoryName { get; set; }
	}
}
