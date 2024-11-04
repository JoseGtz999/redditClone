using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedditClone.Data;

[Route("api/[controller]")]
[ApiController]
public class VoteController : ControllerBase
{
    private readonly AppDbContext _context;

    public VoteController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/votes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vote>>> GetVotes()
    {
        return await _context.Votes.ToListAsync();
    }

    // GET: api/votes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Vote>> GetVote(int id)
    {
        var vote = await _context.Votes.FindAsync(id);

        if (vote == null)
        {
            return NotFound();
        }

        return vote;
    }

    // POST: api/votes
    [HttpPost]
    public async Task<ActionResult<Vote>> PostVote(Vote vote)
    {
        _context.Votes.Add(vote);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVote", new { id = vote.VoteID }, vote);
    }

    // PUT: api/votes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVote(int id, Vote vote)
    {
        if (id != vote.VoteID)
        {
            return BadRequest();
        }

        _context.Entry(vote).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VoteExists(id))
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

    // DELETE: api/votes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVote(int id)
    {
        var vote = await _context.Votes.FindAsync(id);
        if (vote == null)
        {
            return NotFound();
        }

        _context.Votes.Remove(vote);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VoteExists(int id)
    {
        return _context.Votes.Any(e => e.VoteID == id);
    }
}
