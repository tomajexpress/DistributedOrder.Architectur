using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // 1. Grundschutz: Man MUSS angemeldet sein
public class OrdersController : ControllerBase
{
    [HttpGet("GetAllOrders")]
    public IActionResult GetAllOrders()
    {
        // Jeder authentifizierte User darf das sehen (z. B. unser TestUser "Bob")
        return Ok(new[] { "Bestellung 1", "Bestellung 2" });
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "SeniorDeveloperOnly")] // 2. Spezifischer Schutz
    public IActionResult DeleteOrder(int id)
    {
        // Nur User mit dem Claim "role" = "SeniorDeveloper" dürfen hier rein (z. B. "Alice")
        return Ok($"Bestellung {id} gelöscht. Gut gemacht, Senior!");
    }
}