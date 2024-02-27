using APICatalogo.Context;
using APICatalogo.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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
    
    
}