namespace RestaurantApi.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class BurgerController:ControllerBase
    {
     private readonly ILogger<BurgerController> _Anotherlogger;
     private readonly IStoreService2 _BurgerService;
      public BurgerController(ILogger <BurgerController> Logger,IStoreService2 burgerservice)
      {
         _Anotherlogger = Logger; 
         _BurgerService = burgerservice;
      }
      
     [HttpPost]
     public async Task<IActionResult> PostBurger(Models.BurgerModel burger)
     {
         return CreatedAtAction(nameof(PostBurger), await _BurgerService.CreateBurgerAsync(burger.ToBurgerEntity()));
     }

     [HttpGet]
     public async Task<IActionResult> GetAsync()
     {
        try
        {
        var burgers = await _BurgerService.QueryBurgersAsync();      
        return Ok(burgers);
        }
        catch(Exception e)
        {
         return BadRequest(e.Message); 
        }
     }

     [HttpGet]
     [Route("{id}")]
     public async Task<IActionResult> GetAsync([FromRoute] Guid id)
     {
        try
        {
          var Burger= await _BurgerService. QueryBurgerAsync(id);
          return Ok(Burger);
        } 
        catch(Exception e)
        {
          return NotFound(e.Message);
        }       
     }

     [HttpDelete]
     [Route("{Id}")]
     public async Task<IActionResult> DelateTaskAsync([FromRoute]Guid Id)
     {
       try
       {
          var DelateId = await _BurgerService.RemoveBurgerAsync(Id);
           return StatusCode(204);
       } 
       catch(Exception e) 
       {
        return NotFound(e.Message);
       }         
     }

     [HttpPut]
     [Route("{id}")]
     public async Task<ActionResult> CreateAsync([FromRoute]Guid id, [FromBody]Models.BurgerModel burger) 
     {
     try
     {
     var entities =burger.ToBurgerEntity();
     entities.Id = id;
     var result = await _BurgerService.UpdateBurgerAsync(entities);
     return StatusCode(202);
     }
     catch(Exception e)
     {
      return BadRequest(e.Message);
     }
    }

    }
}