namespace HelpDeskClean.Models;

public class Chamado
{
    int id;
    string descricao;
    string usuario;
    DateTime dataAbertura;
    DateTime dataEncerramento;
    string situacao;
    string substituidoPor;
    string localAnterior;
    string equipamentos;
    string qualTecnico;
    string solucao;

    public int Id { get => id; set => id = value; }
    public string Descricao { get => descricao; set => descricao = value; }
    public string Usuario { get => usuario; set => usuario = value; }
    public DateTime DataAbertura { get => dataAbertura; set => dataAbertura = value; }
    public DateTime DataEncerramento { get => dataEncerramento; set => dataEncerramento = value; }
    public string Situacao { get => situacao; set => situacao = value; }
    public string SubstituidoPor { get => substituidoPor; set => substituidoPor = value; }
    public string LocalAnterior { get => localAnterior; set => localAnterior = value; }
    public string Equipamentos { get => equipamentos; set => equipamentos = value; }
    public string QualTecnico { get => qualTecnico; set => qualTecnico = value; }
    public string Solucao { get => solucao; set => solucao = value; }
}
