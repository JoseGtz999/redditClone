using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedditClone.Data;

[Route("api/[controller]")]
[ApiController]
public class CommunityController : ControllerBase
{
    private readonly AppDbContext _context;

    public CommunityController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Community>>> GetCommunities()
    {
        return await _context.Communities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Community>> GetCommunity(int id)
    {
        var community = await _context.Communities.FindAsync(id);

        if (community == null)
        {
            return NotFound();
        }

        return community;
    }

    [HttpPost]
    public async Task<ActionResult<Community>> PostCommunity(Community community)
    {
        _context.Communities.Add(community);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCommunity", new { id = community.CommunityID }, community);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCommunity(int id, Community community)
    {
        if (id != community.CommunityID)
        {
            return BadRequest();
        }

        _context.Entry(community).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CommunityExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommunity(int id)
    {
        var community = await _context.Communities.FindAsync(id);
        if (community == null)
        {
            return NotFound();
        }

        _context.Communities.Remove(community);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CommunityExists(int id)
    {
        return _context.Communities.Any(e => e.CommunityID == id);
    }
}
