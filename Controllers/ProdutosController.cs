using APICatalogo.Context;
using APICatalogo.DTOs;
using APICatalogo.Model;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public ProdutosController( IUnitOfWork uof)
    {
        _uof = uof;
    }

    [HttpGet("produtos/{id}")]
    public ActionResult<IEnumerable<ProdutoDTO>> GetProdutosCategoria(int id)
    {
        var produtos = _uof.ProdutoRepository.GetProdutosPorCategoria(id);
        if (produtos is null)
            return NotFound();

        return Ok(produtos);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProdutoDTO>> Get()
    {
        var produtos = _uof.ProdutoRepository.GetAll();
        
        if (produtos is null)
            return NotFound("Produtos não encontrados"); 
        
        return Ok(produtos);
    }

    [HttpGet("{id:int}", Name="ObterProduto")]
    public ActionResult<ProdutoDTO> Get(int id)
    {
        var produto = _uof.ProdutoRepository.Get(c => c.ProdutoId == id);
        
        if (produto is null)
            return NotFound();

        return Ok(produto);
    }
    
    [HttpPost]
    public ActionResult Post(ProdutoDTO produtoDto)
    {
        if (produtoDto is null) 
            return BadRequest();

        var novoProduto = _uof.ProdutoRepository.Create(produto);
        _uof.Commit();
        
        return new CreatedAtRouteResult("ObterProduto", 
            new { id = produto.ProdutoId }, novoProduto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, ProdutoDTO produtoDto)
    {
        if (id != produtoDto.ProdutoId)
            return BadRequest();
        
        var produtoAtualizado = _uof.ProdutoRepository.Update(produto);
        _uof.Commit();
        return Ok(produtoAtualizado);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<ProdutoDTO> Delete(int id)
    {
        var produto = _uof.ProdutoRepository.Get(p => p.ProdutoId == id);
        if (produto is null)
            return NotFound();

        _uof.ProdutoRepository.Delete(produto);
        _uof.Commit();
        return Ok();
       
    }
}