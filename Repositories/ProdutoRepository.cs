using System.Linq.Expressions;
using APICatalogo.Context;
using APICatalogo.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APICatalogo.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{

   public ProdutoRepository(AppDbContext context) : base(context)
   {
   }

   public IEnumerable<Produto> GetProdutosPorCategoria(int id)
   {
      return GetAll().Where(c => c.CategoriaId == id);
   }
  
}