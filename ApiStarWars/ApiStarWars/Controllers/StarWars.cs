using Microsoft.AspNetCore.Mvc;

namespace ApiStarWars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StarWarsController : ControllerBase
    {


        private readonly ILogger<StarWarsController> _logger;

        public StarWarsController(ILogger<StarWarsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCannons")]
        public int Get()
        {

            var heights = new uint[] { 1, 6, 4, 5, 4, 5, 1, 2, 3, 4, 7, 2 };
            
            return new CannonLoader().GetCannonCount(heights);
        }
    }
}