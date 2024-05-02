using APICatalogo.Model;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public interface IProdutoRepository : IRepository<Produto>
{
    Task<PagedList<Produto>> GetProdutosAsync(ProdutosParameters produtosParameters);
    Task<IEnumerable<Produto>> GetProdutosPorCategoriaAsync(int id);
}