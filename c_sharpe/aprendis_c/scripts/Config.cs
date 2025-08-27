using Godot;
using System;

public partial class Config : Control
{
    //var's:
    public bool is_voltar = false;
    public int id_resolucao = 0;

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

        video();
        base._Ready();
    }
    //config video:
    int video(){
        //resolução
            //defalte resolução / criação de vector2I
        Vector2I reso = new Vector2I(1152,648);
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
        return 0;
    }

    private void voltar()
    {
        GD.Print("voltar");
        //não posso usar is_voltar como paremtro pq o sinal Pressed da godot não aceita
        is_voltar = true;
        aplicar_btn();
    }
    private void aplicar_btn()
    {   
        if (is_voltar == true)
        {
            GD.Print("aplicar");
            video();
            //mudar cena
            GetTree().ChangeSceneToFile(Cenes);
        }
        else
        {
            video();
            GD.Print("aplicar");
        }
    }

    //Conexão do index selecionado pelo user
    private void reslocao_indexe(long index)
    {
        id_resolucao = (int)index;
        //contenção tipo f string no python
        GD.Print($"Index: {id_resolucao}");
    }
}