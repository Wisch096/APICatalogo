using APICatalogo.Context;
using APICatalogo.Model;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _repository;

    public ProdutosController(IProdutoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _repository.GetProdutos().ToList();
        
        if (produtos is null)
            return NotFound("Produtos não encontrados"); 
        
        return produtos;
    }

    [HttpGet("{id:int}", Name="ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _repository.GetProduto(id);
        
        if (produto is null)
            return NotFound();

        return Ok(produto);
    }
    
    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if (produto is null) 
            return BadRequest();

        var novoProduto = _repository.Create(produto);
        
        return new CreatedAtRouteResult("ObterProduto", 
            new { id = produto.ProdutoId }, novoProduto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        if (id != produto.ProdutoId)
            return BadRequest();

        bool atualizado = _repository.Update(produto);

        if (atualizado)
        {
            return Ok(produto);
        }
        else
        {
            return StatusCode(500);
        }
        
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        bool deletado = _repository.Delete(id);
        
        if (deletado)
        {
            return Ok();
        }
        else
        {
            return StatusCode(500);
        }
    }
}