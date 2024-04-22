using System.Linq.Expressions;
using APICatalogo.Context;
using APICatalogo.Model;
using APICatalogo.Pagination;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APICatalogo.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{

   public ProdutoRepository(AppDbContext context) : base(context)
   {
   }

   public IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParams)
   {
      return GetAll()
         .OrderBy(p => p.Nome)
         .Skip((produtosParams.PageNumber - 1) * produtosParams.PageSize)
         .Take(produtosParams.PageSize).ToList();
   }

   public IEnumerable<Produto> GetProdutosPorCategoria(int id)
   {
       
      return GetAll().Where(c => c.CategoriaId == id);
   }
  
}