using APICatalogo.Context;
using APICatalogo.Model;
using APICatalogo.Pagination;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories;

public class CategoriasRepository : Repository<Categoria>, ICategoriaRepository
{

    public CategoriasRepository(AppDbContext context) : base(context)
    {
    }

    public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParams)
    {
        var categorias = GetAll()
            .OrderBy(p => p.CategoriaId)
            .AsQueryable();

        var categoriasOrdenadas =
            PagedList<Categoria>.ToPagedList(categorias, categoriasParams.PageNumber, categoriasParams.PageSize);

        return categoriasOrdenadas;
    }
}