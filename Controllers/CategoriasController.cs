using APICatalogo.Context;
using APICatalogo.Model;
using APICatalogo.Repositories;
using APICatalogo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly IUnitOfWork _uof;
    private readonly IConfiguration _configuration;

    public CategoriasController( IConfiguration configuration, IUnitOfWork uof)
    {
        _configuration = configuration;
        _uof = uof;
    }

    [HttpGet("LerArquivoConfiguracao")]
    public string GetValores()
    {
        var valor1 = _configuration["chave1"];
        var valor2 = _configuration["chave2"];

        return $"{valor1} + {valor2}";
    }
    

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        var categorias = _uof.CategoriaRepository.GetAll();
        return Ok(categorias);
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public  ActionResult<Categoria> Get(int id)
    {
        var categoria = _uof.CategoriaRepository.Get(c => c.CategoriaId == id);
        if (categoria is null) 
            return NotFound();
        
        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        if (categoria is null)
            return BadRequest();

        var categoriaCriada =_uof.CategoriaRepository.Create(categoria);
        _uof.Commit();

        return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoriaCriada);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId)
            return BadRequest();

        _uof.CategoriaRepository.Update(categoria);
        _uof.Commit();
        return Ok(categoria);
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _uof.CategoriaRepository.Get(c => c.CategoriaId == id);
        
        if (categoria is null)
            return NotFound();

        var categoriaExcluida = _uof.CategoriaRepository.Delete(categoria);
        _uof.Commit();
        return Ok(categoriaExcluida);
    }
}