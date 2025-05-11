using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladorInvestimentos.Core.Models;
using SimuladorInvestimentos.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimuladorInvestimentos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvestimentosController : ControllerBase
{
    private readonly AppDbContext _context;

    public InvestimentosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Investimento>>> Get()
    {
        return Ok(await _context.Investimentos.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Investimento>> GetById(int id)
    {
        var investimento = await _context.Investimentos.FindAsync(id);
        if (investimento == null)
            return NotFound();

        return Ok(investimento);
    }

    [HttpPost]
    public async Task<ActionResult<Investimento>> Post(Investimento investimento)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Investimentos.Add(investimento);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = investimento.Id }, investimento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Investimento investimento)
    {
        if (id != investimento.Id)
            return BadRequest();

        var existe = await _context.Investimentos.AnyAsync(i => i.Id == id);
        if (!existe)
            return NotFound();

        _context.Entry(investimento).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var investimento = await _context.Investimentos.FindAsync(id);
        if (investimento == null)
            return NotFound();

        _context.Investimentos.Remove(investimento);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
