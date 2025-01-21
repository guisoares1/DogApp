using Application.Application;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogController : ControllerBase
    {
        private readonly DogApplication _dogApplication;

        public DogController(DogApplication dogApplication)
        {
            _dogApplication = dogApplication;
        }

        [HttpGet]
        public IActionResult GetAllDogs()
        {
            try
            {

                var dogs = _dogApplication.GetAll();

                if (dogs == null || !dogs.Any())
                {
                    return NotFound(new
                    {
                        message = "No breeds found in the system.",
                        timestamp = DateTime.UtcNow
                    });
                }

                return Ok(new
                {
                    message = "Breeds retrieved successfully.",
                    data = dogs,
                    count = dogs.Count(),
                    timestamp = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while processing the request.",
                    details = ex.Message, 
                    timestamp = DateTime.UtcNow
                });
            }
        }
    }
}
