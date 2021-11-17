namespace RestaurantApi.Services
{

    public interface  IStoreService 
    {
      Task<List<Pizza>> QueryPizzasAsync();
      Task<Pizza> QueryPizzaAsync(Guid id);
      Task<(bool IsSuccess, Exception Exception, Pizza Pizza)> CreatePizzaAsync(Pizza pizza);
      Task<bool> PizzaExistsAsync(Guid id);
      Task<(bool IsSuccess, Exception Exception, Pizza Pizza)> UpdatePizzaAsync(Pizza pizza);
      Task<(bool IsSuccess, Exception Exception)> RemovePizzaAsync(Guid id);
    }

     public interface  IStoreService2
    {
      Task<List<Burger>> QueryBurgersAsync();
      Task<Burger> QueryBurgerAsync(Guid id);
      Task<(bool IsSuccess, Exception Exception, Burger burger)> CreateBurgerAsync( Burger burger);
      Task<bool> BurgerExistsAsync(Guid id);
      Task<(bool IsSuccess, Exception Exception, Burger burger)> UpdateBurgerAsync( Burger burger);
      Task<(bool IsSuccess, Exception Exception)> RemoveBurgerAsync(Guid id);
    }
}