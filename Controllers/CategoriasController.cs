using APICatalogo.Context;
using APICatalogo.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
    {
        return _context.Categoria.Include(p => p.Produtos).ToList();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        return _context.Categoria.ToList();
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _context.Categoria.FirstOrDefault(p => p.CategoriaId == id);

        if (categoria == null) 
            return NotFound();

        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        if (categoria is null)
            return BadRequest();

        _context.Categoria.Add(categoria);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId)
            return BadRequest();

        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(categoria);
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _context.Categoria.FirstOrDefault(p => p.CategoriaId == id);
        
        if (categoria is null)
            return NotFound();

        _context.Categoria.Remove(categoria);
        _context.SaveChanges();

        return Ok(categoria);
    }
}