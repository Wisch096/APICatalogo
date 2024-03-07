using APICatalogo.Context;
using APICatalogo.Model;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories;

public class CategoriasRepository : Repository<Categoria>, ICategoriaRepository
{

    public CategoriasRepository(AppDbContext context) : base(context)
    {
    }
    
}