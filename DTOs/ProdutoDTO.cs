using System.ComponentModel.DataAnnotations;
using APICatalogo.Validations;

namespace APICatalogo.DTOs;

public class ProdutoDTO
{
    public int ProdutoId { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(80)]
    public string? Nome { get; set; }
    
    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }
    
    [Required]
    public string? Preco { get; set; }
    
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; }
}