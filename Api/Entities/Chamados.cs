namespace Api.Entities
{
    public class Chamados
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public ClientApp Cliente { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public string Descricao { get; set; }
    }
}