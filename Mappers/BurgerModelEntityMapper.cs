namespace RestaurantApi.Mappers
{
    public static class BurgerModelEntityMapper
    {
        public static Enteties.Burger ToBurgerEntity(this Models.BurgerModel Burger)
        {
            return new Burger(
            title: Burger.Title,
            ingridients: string.Join(',', Burger.Ingridients),
            shortName: Burger.ShortName,
            price: Burger.Price,
            createdAt:DateTimeOffset.UtcNow,
            modifiedAt:DateTimeOffset.UtcNow,
            status: Burger.Status.ToEntityStockStatus2());
        }

    public static Enteties.EstockStatus ToEntityStockStatus2(this Models.EstockStatus status)
        => status switch
        {
            Models.EstockStatus.In => Enteties.EstockStatus.In,
            _ => Enteties.EstockStatus.Out
        }; 
    }
        
    
}