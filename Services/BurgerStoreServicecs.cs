namespace RestaurantApi.Services
{
    public class BurgerStoreServicecs : IStoreService2
    {   
     private readonly RestaurantDbContext _context;
 
    public BurgerStoreServicecs(RestaurantDbContext context)
    {
        _context = context;
    }
    public async Task<(bool IsSuccess, Exception Exception, Burger burger)> CreateBurgerAsync(Burger burger)
    {
        if(await BurgerExistsAsync(burger.Id))
        {
            return (false, new ArgumentException($"There is no Burger with given ID: {burger.Id}"), null);
        }

        try
        {
         await _context.Burgers.AddAsync(burger);
         await _context.SaveChangesAsync();

         return (true, null, burger);
        }
        catch(Exception e)
        {
            return (false, e, null);
        }
    }

    public Task<bool> BurgerExistsAsync(Guid id)
        => _context.Burgers
        .AnyAsync(p => p.Id == id);

    public Task<Burger> QueryBurgerAsync(Guid id)
        => _context.Burgers
        .AsNoTracking()
        .Where(p => p.Id == id)
        .FirstOrDefaultAsync();

    public Task<List<Burger>> QueryBurgersAsync()
        => _context.Burgers
        .AsNoTracking()
        .ToListAsync();

    public async Task<(bool IsSuccess, Exception Exception)> RemoveBurgerAsync(Guid id)
    {
        if(!await BurgerExistsAsync(id))
        {
            return (false, new ArgumentException($"There is no Burger with given ID: {id}"));
        }

         _context.Burgers.Remove(await QueryBurgerAsync(id));
         await _context.SaveChangesAsync();

         return (true, null);
    }

    public async Task<(bool IsSuccess, Exception Exception, Burger burger)> UpdateBurgerAsync(Burger burger)
    {
        if(!await BurgerExistsAsync(burger.Id))
        {
            return (false, new ArgumentException($"There is no Burger with given ID: {burger.Id}"), null);
        }

        burger.ModifiedAt = DateTimeOffset.UtcNow;

        _context.Burgers.Update(burger);
        await _context.SaveChangesAsync();

        return (true, null, burger);
    }
        
    }
}