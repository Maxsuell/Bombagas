using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class UserApp
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Senha { get; set; }
        public string ChaveSenha { get; set; }
        [Column(TypeName = "nvarchar(7)")]
        [EnumDataType(typeof(Nivel))] // Mapeia o enum TipoCliente para o campo correspondente no banco de dados
        public Nivel Nivel_User { get; set; }

        public enum Nivel
        {
            Normal,
            Admin
        }
    }
}