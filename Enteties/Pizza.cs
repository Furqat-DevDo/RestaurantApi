namespace RestaurantApi.Enteties
{
    public class Pizza
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id{get;set;}   
        [Required,MaxLength(255)]     
        public string Title { get; set; }
        [Required,MinLength(3),MaxLength(3)]
        public string ShortName{get;set;}
        public DateTimeOffset CreatedAt{get;set;}
        [Range(1,Double.MaxValue)]
        public double Price{get;set;}
        public DateTimeOffset ModifiedAt{get;set;}
        public EstockStatus Status {get;set;}

        [Required,  MaxLength(1024)]
        public string Ingridients { get; set; }
        [Obsolete("Used only for entity binding.", true)]
        public Pizza() { }
         public Pizza(string title, string shortName, DateTimeOffset createdAt, double price, DateTimeOffset modifiedAt, EstockStatus status, string ingridients)
        {   
            Id=Guid.NewGuid();
            Title = title;
            ShortName = shortName;
            CreatedAt = createdAt;
            Price = price;
            ModifiedAt = modifiedAt;
            Status = status;
            Ingridients = ingridients;
        }
    }
}