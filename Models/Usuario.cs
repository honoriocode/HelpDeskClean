namespace HelpDeskClean.Models;

public class Usuario
{
    int id;
    string nome;
    string login;
    string senha;
    DateTime criadoEm;
    DateTime atualizadoEm;
    bool status;
    string contato;

    public int Id { get => id; set => id = value; }
    public string Nome { get => nome; set => nome = value; }
    public string Login { get => login; set => login = value; }
    public string Senha { get => senha; set => senha = value; }
    public DateTime CriadoEm { get => criadoEm; set => criadoEm = value; }
    public DateTime AtualizadoEm { get => atualizadoEm; set => atualizadoEm = value; }
    public bool Status { get => status; set => status = value; }
    public string Contato { get => contato; set => contato = value; }
}
