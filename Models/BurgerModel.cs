namespace RestaurantApi.Models
{
    public class BurgerModel
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
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Models.EstockStatus Status {get;set;}

        [Required,  MaxLength(1024)]
        public List<string> Ingridients { get; set; }
        
    }
}