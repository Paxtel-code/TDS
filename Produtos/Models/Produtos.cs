using System.ComponentModel.DataAnnotations;

namespace Produtos.Api.Model
{
    public class ProdutosModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Genre { get; set; }
        public double Price { get; set; }
        public int? Amount { get; set; }
    }
}

