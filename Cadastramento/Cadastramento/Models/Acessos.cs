using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cadastramento.Models
{
    //DESENVOLVIDA PARA MOSTRAR REGISTROS DE ACESSO DO CRUD.
    [Table("Acessos")]
    public class Acessos
    {
        [Column("Id")]
        [Display(Name = "Código de acesso: ")]
        public int Id { get; set; }

        //MENSAGEM DE RETORNO PARA O USUÁRIO
        [Column("Detalhamento")]
        [Display(Name = "Detalhamento")]
        public string Detalhamento { get; set; }

        [Column("Email")]
        [Display(Name = "Email do Usuário")]
        public string Email { get; set; }
    }
}
