namespace HelpDeskClean.Models;

public class TipoUsuario
{
    int id;
    string descricao;
    bool podeLer;
    bool podeDescrever;
    bool podeDeletar;
    bool podeAtualizar;

    public int Id { get => id; set => id = value; }
    public string Descricao { get => descricao; set => descricao = value; }
    public bool PodeLer { get => podeLer; set => podeLer = value; }
    public bool PodeDescrever { get => podeDescrever; set => podeDescrever = value; }
    public bool PodeDeletar { get => podeDeletar; set => podeDeletar = value; }
    public bool PodeAtualizar { get => podeAtualizar; set => podeAtualizar = value; }
}
