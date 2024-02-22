﻿namespace APICatalogo.Model;

public class Produto
{
    public int ProdutoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public string? Preco { get; set; }
    public string? ImagemUrl { get; }
    public float Estoque { get; set; }
    public DateTime? DataCadastro { get; set;}
}