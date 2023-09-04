using Microsoft.EntityFrameworkCore;

namespace ArmazemDoMago.Models {
    public class ItemContext : DbContext {

        public ItemContext(DbContextOptions<ItemContext> options) 
            : base(options) {
        
        }

        public DbSet<MagicItem> MagicItems { get; set; } = null!;
    }
}
