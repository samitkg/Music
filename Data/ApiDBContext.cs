using Microsoft.EntityFrameworkCore;
using MusicApi.Models;
namespace MusicApi.Data
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> option):base(option)
        {
            
        }

        public DbSet<Song> Songs { get; set; } 
        
    }
}