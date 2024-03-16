using APICatalogo.Model;

namespace APICatalogo.DTOs;

public static class CategoriaDTOMappingExtensions
{
    public static CategoriaDTO? ToCategoriaDTO(this Categoria categoria)
    {
        if (categoria is null)
            return null;

        return new CategoriaDTO
        {
            Id = categoria.CategoriaId,
            Nome = categoria.Nome,
            ImagemUrl = categoria.imagemUrl
        };
    }

    public static Categoria? ToCategoria(this CategoriaDTO categoriaDto)
    {
        if (categoriaDto is null) 
            return null;

        return new Categoria
        {
            CategoriaId = categoriaDto.Id,
            Nome = categoriaDto.Nome,
            imagemUrl = categoriaDto.ImagemUrl
        };
    }

    public static IEnumerable<CategoriaDTO> ToCategoriaDTOList(this IEnumerable<Categoria> categorias)
    {
        if (categorias is null || !categorias.Any())
            return new List<CategoriaDTO>();

        return categorias.Select(categoria => new CategoriaDTO
        {
            Id = categoria.CategoriaId,
            Nome = categoria.Nome,
            ImagemUrl = categoria.imagemUrl,
        }).ToList();
    }
}