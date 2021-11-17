namespace RestaurantApi.Mappers
{
    public static class PizzaModelEntityMapper
    {
     public static Enteties.Pizza ToPizzaEntity(this Models.PizzaModel pizza)
    {
        return new Pizza(
            title: pizza.Title,
            ingridients: string.Join(',', pizza.Ingridients),
            shortName: pizza.ShortName,
            price: pizza.Price,
            createdAt:DateTimeOffset.UtcNow,
            modifiedAt:DateTimeOffset.UtcNow,
            status: pizza.Status.ToEntityStockStatus());
    }

    public static Enteties.EstockStatus ToEntityStockStatus(this Models.EstockStatus status)
        => status switch
        {
            Models.EstockStatus.In => Enteties.EstockStatus.In,
            _ => Enteties.EstockStatus.Out
        }; 
    }
}