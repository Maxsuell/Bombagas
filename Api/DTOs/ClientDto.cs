namespace api.Dtos
{
    public class ClientDto
    {
        public string NameClient { get; set; }
        public string CNPJ { get; set; }
        public float Dividas { get; set; }

        public ICollection<ContatosDto> contatosDto {get; set;}
    }
}