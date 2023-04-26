namespace HelpDeskClean.Models;

public class Local
{
    int id;
    string descricao;
    string endereco;
    string cep;
    string estado;
    string cidade;

    public int Id { get => id; set => id = value; }
    public string Descricao { get => descricao; set => descricao = value; }
    public string Endereco { get => endereco; set => endereco = value; }
    public string Cep { get => cep; set => cep = value; }
    public string Estado { get => estado; set => estado = value; }
    public string Cidade { get => cidade; set => cidade = value; }
}
