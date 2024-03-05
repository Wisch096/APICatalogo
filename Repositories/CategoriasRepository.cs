using APICatalogo.Context;
using APICatalogo.Model;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories;

public class CategoriasRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;

    public CategoriasRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Categoria> GetCategorias()
    {
        return _context.Categoria.ToList();
    }

    public Categoria GetCategoria(int id)
    {
        return _context.Categoria.FirstOrDefault(c => c.CategoriaId == id);
    }

    public Categoria Create(Categoria categoria)
    {
        if (categoria is null)
            throw new ArgumentNullException(nameof(categoria));

        _context.Categoria.Add(categoria);
        _context.SaveChanges();

        return categoria;
    }

    public Categoria Update(Categoria categoria)
    {
        if (categoria is null)
            throw new ArgumentNullException(nameof(categoria));

        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();

        return categoria;
    }

    public Categoria Delete(int id)
    {
        var categoria = _context.Categoria.Find(id);
        
        if (categoria is null)
            throw new ArgumentNullException(nameof(categoria));

        _context.Categoria.Remove(categoria);
        _context.SaveChanges();
        
        return categoria;
    }
}