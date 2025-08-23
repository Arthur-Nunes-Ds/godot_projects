using Godot;

public partial class tela_inicial : Control
{
    // fala para a godot que aparti dela é um grupo
    [ExportGroup("buutons")]
    //o exporte ainda é encessario
    [Export]
    public Button satrt, exit, config;
    [ExportGroup("cenes")]
    [Export]
    //exporte de mas de um campo mas do mesmo tipo
    public string config_cenes, star_cenes;

    public override void _Ready()
    {
        //conecta o sinal nésario
        satrt.Pressed += start_pressed;
        config.Pressed += config_pressed;
        exit.Pressed += exit_pressed;
        base._Ready();
    }

    // os void's são chamdos automaticamente quando o user aperta o botão
    private void exit_pressed()
    {
        //sair do jogo
        GetTree().Quit();
    }
    private void config_pressed()
    {
        if (config_cenes == "")
        {
            GD.PushError("config_cenes: caminho não apontado");
        }
        else
        {
            //mudar de cena
            GetTree().ChangeSceneToFile(config_cenes);
        }
    }
    private void start_pressed()
    {
        if (star_cenes == "")
        {
            GD.PushError("start_cenes: caminho não apontado");
        }
        else
        {
            GetTree().ChangeSceneToFile(star_cenes);
        }
    }   
}