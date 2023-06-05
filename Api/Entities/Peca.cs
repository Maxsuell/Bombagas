using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Peca
    {
        public int Id { get; set; }
        public string NamePeca { get; set; }
        public float ValorUnit { get; set; }
        public string Descricao { get; set; }
    }
}