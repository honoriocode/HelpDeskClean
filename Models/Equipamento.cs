namespace HelpDeskClean.Models;

public class Equipamento
{
    int id;
    string numeroSerie;
    DateTime dataEmissao;
    string fornecedor;
    string cnpj;
    DateTime data;
    string marca;
    string memoria;
    string hd;
    string processador;

    public int Id { get => id; set => id = value; }
    public string NumeroSerie { get => numeroSerie; set => numeroSerie = value; }
    public DateTime DataEmissao { get => dataEmissao; set => dataEmissao = value; }
    public string Fornecedor { get => fornecedor; set => fornecedor = value; }
    public string Cnpj { get => cnpj; set => cnpj = value; }
    public DateTime Data { get => data; set => data = value; }
    public string Marca { get => marca; set => marca = value; }
    public string Memoria { get => memoria; set => memoria = value; }
    public string Hd { get => hd; set => hd = value; }
    public string Processador { get => processador; set => processador = value; }
}
