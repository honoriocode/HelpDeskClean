namespace HelpDeskClean.DTOs
{
    public class ChamadoDTO
    {
        public string Descricao { get; set; }
        public string Usuario { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataEncerramento { get; set; }
        public string Situacao { get; set; }
        public string SubstituidoPor { get; set; }
        public string LocalAnterior { get; set; }
        public string Equipamentos { get; set; }
        public string QualTecnico { get; set; }
        public string Solucao { get; set; }

    }
}
