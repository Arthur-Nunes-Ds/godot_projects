using Godot;

public partial class Global_Var : Node
{
    //necessario para a manibulção em outros scripts
    public static Global_Var Instance { get; private set; }

    //var/func
    public int vida { get; set; } = 100;

    //é necessario instancia-ló para o acesso acontecer
    public override void _Ready()
    {
        Instance = this;
        base._Ready();
    }

}
