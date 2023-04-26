namespace HelpDeskClean.DTOs
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public bool Status { get; set; }
        public string Contato { get; set; }
    }
}
