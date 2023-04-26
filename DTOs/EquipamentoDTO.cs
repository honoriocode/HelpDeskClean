using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using System;

namespace HelpDeskClean.DTOs
{
    public class EquipamentoDTO
    {
        public string NumeroSerie { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Fornecedor { get; set; }
        public string Cnpj { get; set; }
        public DateTime Data { get; set; }
        public string Marca { get; set; }
        public string Memoria { get; set; }
        public string Hd { get; set; }
        public string Processador { get; set; }
    }
}
