namespace Api.Entities
{
    public class Contatos
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }

        public ClientApp ClientApp { get; set; }
    }
}