using System.ComponentModel.DataAnnotations;

namespace Projeto_CRUD.Model
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [MaxLength(150, ErrorMessage = "Apenas 150 caracteres")]
        public string Nome { get; set; } = string.Empty;

        public string Imagem { get; set; } = string.Empty;

        [MaxLength(2000,ErrorMessage ="Apenas 2000 caracteres")]

        public string Descricao { get; set; } =string.Empty;

        public int  Estoque { get; set; } 

        public bool Status { get; set; }

        public decimal Preco { get; set; }






    }
}
