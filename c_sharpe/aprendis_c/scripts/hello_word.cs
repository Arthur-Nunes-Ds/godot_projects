using Godot;
using System;
using System.IO;

public partial class hello_word : Sprite2D //estrutura base do node 2D
{
    /*pega a func nativa da godot 
    _Reday() --> que fala que qaundo o node estive pronto ele vai carrega o que tem nela */
    public override void _Ready()
    {//GD -> função nativa/interna da godot
        GD.Print("hello word");
    }

    //para facilidar a manibulação da var vida em outro script
    public int vida(int add_vida = 0, int sub_vida = 0)
    {
        //faz uma instanciamento para pode manibula a var
        Global_Var.Instance.vida += add_vida;
        Global_Var.Instance.vida -= sub_vida;
        return Global_Var.Instance.vida;
    }
}