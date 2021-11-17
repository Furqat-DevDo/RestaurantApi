namespace RestaurantApi.Enteties
{
    public class Burger
    {
        
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id{get;set;}
        [Required,MaxLength(255)]
        public string Title { get; set; }
        [Required,MaxLength(3),MinLength(3)]
        public string ShortName { get; set; }
        [Required,  MaxLength(1024)]
        public string Ingridients { get; set; }
        [Range(1,Double.MaxValue)]
        public  double Price{get;set;}
        public DateTimeOffset CreatedAt{get;set;}
        public DateTimeOffset ModifiedAt{get;set;}
        public EstockStatus Status {get;set;}
        [Obsolete("Used only for entity binding.", true)]
        public Burger(){}
        public Burger(string title, string shortName, string ingridients, double price, DateTimeOffset createdAt, DateTimeOffset modifiedAt, EstockStatus status)
        {  
            Id=Guid.NewGuid();
            Title = title;
            ShortName = shortName;
            Ingridients = ingridients;
            Price = price;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            Status = status;
        }
    }
}