using Microsoft.AspNetCore.Mvc;

namespace MarketingLeads.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class MarketingLeadsController : ControllerBase
{
    private readonly ILogger<MarketingLeadsController> _logger;

    public MarketingLeadsController(ILogger<MarketingLeadsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get()
    {
        return Ok(new List<string>() { "Lead-1", "Lead-2" });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get(int id)
    {
        if (id <= 0)
            return BadRequest();

        if (id != 1)
            return NotFound();

        return Ok("Lead-1");        
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create(string name)
    {
        return CreatedAtAction(nameof(Get), new { id = 1 }, name);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(int id, string name)
    {
        if (id <= 0)
            return BadRequest();

        if (id != 1)
            return NotFound();

        string newName = name;

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(int id)
    {
        if (id <= 0)
            return BadRequest();

        if (id != 1)
            return NotFound();

        //LeadsService.Delete(id);

        return NoContent();
    }
}