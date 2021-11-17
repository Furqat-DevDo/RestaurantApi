namespace RestaurantApi.Data
{
    public class RestaurantDbContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Burger> Burgers{get;set;}
    
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Pizza>().HasIndex(p => p.ShortName).IsUnique();
    }
}
}