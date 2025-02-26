// Import necessary namespaces
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    // ==============================
    //    HOMECONTROLLER DEFINITION
    // ==============================
    // This is the HomeController for the Provider Member Portal API.
    // It handles HTTP requests and returns JSON responses.
    // This controller is configured with attribute routing and follows RESTful conventions.

    [ApiController] // Marks this class as an API controller
    [Route("api/[controller]")] // Routes requests to 'api/home'
    public class HomeController : ControllerBase
    {
        // ==============================
        //         GET /api/home
        // ==============================
        // This is a simple GET endpoint that returns a welcome message.
        // It demonstrates how to create a basic API endpoint in ASP.NET Core.

        /// <summary>
        /// GET api/home
        /// Returns a welcome message.
        /// </summary>
        /// <returns>A JSON object with a welcome message</returns>
        [HttpGet] // Handles HTTP GET requests
        public IActionResult Get()
        {
            // Return a JSON object with a message and status code 200 (OK)
            return Ok(new
            {
                message = "Welcome to the Provider Member Portal API!",
                version = "1.0.0"
            });
        }

        // ==============================
        //     GET /api/home/status
        // ==============================
        // This endpoint checks the status of the API.
        // It can be used for health checks or monitoring.

        /// <summary>
        /// GET api/home/status
        /// Checks the status of the API.
        /// </summary>
        /// <returns>A JSON object with API status information</returns>
        [HttpGet("status")] // Route: GET api/home/status
        public IActionResult Status()
        {
            return Ok(new
            {
                status = "API is running smoothly.",
                timestamp = DateTime.UtcNow
            });
        }
    }
}
