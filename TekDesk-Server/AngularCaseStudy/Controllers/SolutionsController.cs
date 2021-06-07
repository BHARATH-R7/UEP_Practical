using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularCaseStudy.Data;
using AngularCaseStudy.Models;
using Microsoft.AspNetCore.Cors;
using System.Net.Http;
using System.IO;

namespace AngularCaseStudy.Controllers
{
    [EnableCors("TCAPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public SolutionsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Solutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solution>>> GetSolution()
        {
            return await _context.Solution.ToListAsync();
        }

        // GET: api/Solutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solution>> GetSolution(int id)
        {
            var solution = await _context.Solution.FindAsync(id);

            if (solution == null)
            {
                return NotFound();
            }

            return solution;
        }

        // PUT: api/Solutions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolution(int id, Solution solution)
        {
            if (id != solution.SolutionID)
            {
                return BadRequest();
            }

            _context.Entry(solution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolutionExists(id))
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

        // POST: api/Solutions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Solution>> PostSolution(Solution solution)
        {
            _context.Solution.Add(solution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolution", new { id = solution.SolutionID }, solution);
        }


        // DELETE: api/Solutions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolution(int id)
        {
            var solution = await _context.Solution.FindAsync(id);
            if (solution == null)
            {
                return NotFound();
            }

            _context.Solution.Remove(solution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolutionExists(int id)
        {
            return _context.Solution.Any(e => e.SolutionID == id);
        }
    }
}
