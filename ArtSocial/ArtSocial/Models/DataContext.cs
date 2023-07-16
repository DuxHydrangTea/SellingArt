using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace ArtSocial.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DetailProduct> DetailProducts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BaseComment> baseComments { get; set; }
        public DbSet<MyCart> MyCarts { get; set; }
        public DbSet<DetailMyCart> detailMyCarts { get; set; }
        public DbSet<Post> posts { get; set; }
        
    }
}
