using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class UserApp
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Senha { get; set; }
        public string ChaveSenha { get; set; }
        public char Nivel { get; set; }
    }
}