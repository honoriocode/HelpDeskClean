namespace HelpDeskClean.DTOs
{
    public class TipoUsuarioDTO
    {
        public string Descricao { get; set; }
        public bool PodeLer { get; set; }
        public bool PodeDescrever { get; set; }
        public bool PodeDeletar { get; set; }
        public bool PodeAtualizar { get; set; }

    }
}
