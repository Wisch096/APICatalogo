﻿using APICatalogo.Model;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public interface ICategoriaRepository : IRepository<Categoria>
{
    PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParams);
}