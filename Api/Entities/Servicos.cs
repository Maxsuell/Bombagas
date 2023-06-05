using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class Servicos
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [EnumDataType(typeof(Tecnico))] // Mapeia o enum TipoCliente para o campo correspondente no banco de dados
        public Tecnico NomeTecnico { get; set; }
        public int IdCliente { get; set; }
        public ClientApp Cliente { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int IdPeca { get; set; }
        public Peca Peca { get; set; }
        public float ValorServico { get; set; }
        public string DescPagamento { get; set; }

        public enum Tecnico
        {
            Nivaldo,
            Tarcisio,
            Eder,
            Maxsuell,
            Nelson
        }

    }
}