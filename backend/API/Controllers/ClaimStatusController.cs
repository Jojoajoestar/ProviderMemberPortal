using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers 
{
[Route("api/[controller]")]
[ApiController]
public class ClaimStatusController : ControllerBase 
{
    private readonly ClaimStatusDbContext _context;

    public ClaimStatusController(ClaimStatusDbContext context) 
    {
        _context = context;
    }

    // GET: api/ClaimStatus
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClaimStatus>>> GetAll() 
    { 
        return Ok(await _context.ClaimStatuses.ToListAsync());
    }

    // GET: api/ClaimStatus/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ClaimStatus>> GetById(int id) 
    {
        var claimStatus = await _context.ClaimStatuses.FindAsync(id);
        if (claimStatus == null) 
        {
            return NotFound(new { Message = "Claim Status not found. " });
        }
        return Ok(claimStatus);
    }

    // POST: api/ClaimStatus
    [HttpPost]
    public async Task<ActionResult<ClaimStatus>> Create([FromBody]ClaimStatus claimStatus) 
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }

        _context.ClaimStatuses.Add(claimStatus);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = claimStatus.Id }, claimStatus);
    }

    // PUT: api/ClaimStatus/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClaimStatus claimStatus) 
    {
        if (id != claimStatus.Id) 
        {
            return BadRequest(new { Message = "ID Mismatch."});
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Entry(claimStatus).State = EntityState.Modified;

        try 
        {
            await _context.SaveChangesAsync();
        } 
        catch (DbUpdateConcurrencyException) 
        {
            if (!ClaimStatusExists(id)) 
            {
                return NotFound(new {Message = "Claim Status not found."});
            } 
            else 
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/ClaimStatus/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) 
    {
        var claimStatus = await _context.ClaimStatuses.FindAsync(id);
        if (claimStatus == null) 
        {
            return NotFound( new { Message = "Claim Status not found."});
        }

        _context.ClaimStatuses.Remove(claimStatus);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ClaimStatusExists(int id) 
    {
        return _context.ClaimStatuses.Any(e => e.Id == id);
    }
    
}

}