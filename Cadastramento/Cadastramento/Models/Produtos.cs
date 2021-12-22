using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastramento.Models
{
    //NOME DA TABELA
    [Table("Produtos")]
    public class Produtos
    {
        //ATRIBUTOS
        [Column("Id")]
        [Display(Name = "Código do Produto: ")]
        public int Id { get; set; }

        [Column("Nome_Produto")]
        [Display(Name = "Nome do Produto: ")]
        public string Nome_Produto { get; set; }

        [Column("Preco_Produto")]
        [Display(Name = "Preço do Produto: ")]
        public string Preco_Produto { get; set; }
    }
}
