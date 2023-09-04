using Microsoft.EntityFrameworkCore;

namespace ArmazemDoMago.Models {
    public class ItemContext : DbContext {
        // Herda do entity framework 
        public ItemContext(DbContextOptions<ItemContext> options) 
            : base(options) {
        
        }
        // São criadas as entidades para items mágicos
        public DbSet<MagicItem> MagicItems { get; set; } = null!;
    }
}
