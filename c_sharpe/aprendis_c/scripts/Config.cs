using Godot;
using System;


//necessario para acessar arquivos

using System.IO;
//necessario para o encondig
using System.Text;

//curta um comando grande 
using Dictionary = Godot.Collections.Dictionary;


public partial class Config : Control
{
    //ANCHOR - var's:
    public bool is_voltar = false;
    public int id_resolucao = 0;
    //dic
    public Dictionary user_save = new Dictionary();

    //pega o caminho onde o jogo salva ás coisa do player local(como um ".mine...")
    string USER_PATCH = ProjectSettings.GlobalizePath("user://");

    //ANCHOR - @exporte
    [Export]
    public string Cenes;

    [ExportGroup("butoons")]
    [Export]
    public OptionButton resolucao;
    [Export]
    public Button Volta, Aplcar;

    public override void _Ready()
    {
        //faz o linck de metetos
        Volta.Pressed += voltar;
        Aplcar.Pressed += aplicar_btn;
        resolucao.ItemSelected += reslocao_indexe;

        //GD.Print(USER_PATCH);

        load();

        base._Ready();
    }
    private void load()
    {
        GD.Print($"dic_antes_load: {user_save}");
        string jsl = LoadJson(USER_PATCH, "config_user.json");
        //cira um obj json
        Json jsonCaregand = new Json();
        //caso der algum erro ná ora de converte para json->dic
        Error error = jsonCaregand.Parse(jsl);
        if (error != Error.Ok) { GD.Print(error); return; }
        //se nada da errado ele passa apra o formato dic da godot
        user_save = (Dictionary)jsonCaregand.Data;

        //pega o valor dentro do dic data(json) na key[opcao_reolucao] é já converte para int 
        id_resolucao = (int)user_save["opcao_reolucao"];
        GD.Print($"dic_load: {user_save}");
        video();
    }


    //config video:
    private void video()
    {
        //defalte resolução / criação de vector2I
        Vector2I reso = new Vector2I(1152, 648);
        //resolução
        //match case
        switch (id_resolucao)
        {
            case 0:
                //edita um vector2I
                reso = new Vector2I(1152, 648);
                //conserta a opção do index
                resolucao.Select(0);
                break;
            case 1:
                reso = new Vector2I(1280, 720);
                resolucao.Select(1);
                break;
            case 2:
                reso = new Vector2I(1024, 768);
                resolucao.Select(2);
                break;
            case 3:
                reso = new Vector2I(1280, 960);
                resolucao.Select(3);
                break;
        }

        //seta a resolução
        DisplayServer.WindowSetSize(reso);
    }

    //ANCHOR - conexção de metedos da godot
    private void voltar()
    {
        GD.Print("voltar");
        //não posso usar is_voltar como paremtro pq o sinal Pressed da godot não aceita
        is_voltar = true;
        aplicar_btn();
    }
    private void aplicar_btn()
    {
        //faz o manda o para o sjon salvar certinho
        void salvar()
        {
            //supstuir no dic | dic[key] = vaule
            user_save["opcao_reolucao"] = id_resolucao;

            //converte sjon para uma espece de string
            string user_save_str = Json.Stringify(user_save);
            SaveJson(USER_PATCH, user_save_str, "config_user.json");
            return;
        }

        if (is_voltar == true)
        {
            GD.Print("aplicar -> tela scream");
            salvar();
            //mudar cena
            GetTree().ChangeSceneToFile(Cenes);
        }
        else
        {
            GD.Print("aplicar");
            salvar();
            load();
        }
    }

    //Conexão do index selecionado pelo user
    private void reslocao_indexe(long index)
    {
        id_resolucao = (int)index;
        //contenção tipo f string no python
        GD.Print($"Index: {id_resolucao}");
    }

    //ANCHOR manibulção do json atrves da GODOT
    //salva sjon
    private void SaveJson(string caminhoSjon, string dic, string nome_json)
    {
        //para ir até o caminho acima e abri o json
        caminhoSjon = Path.Join(caminhoSjon, nome_json);

        //try expect
        try
        {
            //sobre escreve o arquivo (caminho, dicinorio, encode caso aja)     
            File.WriteAllText(caminhoSjon, dic, Encoding.UTF8);
        }
        catch (System.Exception e)
        {
            GD.Print(e);
        }

        return;
    }

    //loade json
    private string LoadJson(string caminhoSjon, string nome_json)
    {
        string dados = null;

        caminhoSjon = Path.Join(caminhoSjon, nome_json);

        //ver ser o json existe
        if (!File.Exists(caminhoSjon)) return null;

        try
        {
            //ler
            dados = File.ReadAllText(caminhoSjon, Encoding.UTF8);
        }
        catch (System.Exception e)
        {
            GD.Print(e);
        }

        return dados;
    }
}