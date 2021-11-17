[ApiController]
[Route("[controller]")]
public class PizzaController:ControllerBase
    {
     private readonly ILogger<PizzaController> _Anotherlogger;
     private readonly IStoreService _PizzaService;
      public PizzaController(ILogger <PizzaController> Logger,IStoreService Pizzaservice)
      {
         _Anotherlogger = Logger; 
         _PizzaService = Pizzaservice;
      }
      
    [HttpPost]
    public async Task<IActionResult> PostPizza(PizzaModel Pizza)
    {
         return CreatedAtAction(nameof(PostPizza), await _PizzaService.CreatePizzaAsync(Pizza.ToPizzaEntity()));
    }

     [HttpGet]
     public async Task<IActionResult> GetAsync()
     {
        try
        {
        var Pizzas = await _PizzaService.QueryPizzasAsync();      
        return Ok(Pizzas);
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
          var Pizza= await _PizzaService. QueryPizzaAsync(id);
          return Ok(Pizza);
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
          var DelateId = await _PizzaService.RemovePizzaAsync(Id);
           return StatusCode(204);
       } 
       catch(Exception e) 
       {
        return NotFound(e.Message);
       }         
     }

     [HttpPut]
     [Route("{id}")]
     public async Task<ActionResult> CreateAsync([FromRoute]Guid id, [FromBody]PizzaModel Pizza) 
     {
     try
     {
     var entities =Pizza.ToPizzaEntity();
     entities.Id = id;
     var result = await _PizzaService.UpdatePizzaAsync(entities);
     return StatusCode(202);
     }
     catch(Exception e)
     {
      return BadRequest(e.Message);
     }
    }
}