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
   
   public PagedList<Produto> GetProdutos(ProdutosParameters produtosParams)
   {
      var produtos = GetAll()
         .OrderBy(p => p.ProdutoId)
         .AsQueryable();

      var produtosOrdenados =
         PagedList<Produto>.ToPagedList(produtos, produtosParams.PageNumber, produtosParams.PageSize);

      return produtosOrdenados;
   }

   public IEnumerable<Produto> GetProdutosPorCategoria(int id)
   {
      return GetAll().Where(c => c.CategoriaId == id);
   }
  
}