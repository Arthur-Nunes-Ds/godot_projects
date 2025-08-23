//importa o fremeorck da godot
using Godot;

public partial class MoveBasic : Sprite2D
//MoveBasic == name do node
{
    //@exporte 
    [Export]
    float velocidade { get; set; } = 1;

    public override void _Process(double delta)//void loop
    {
        /*var newPosition = Position;
        newPosition.X = 100.0f;
        Position = newPosition;
        é a mesma coisa:
        Position = Position with { X = 100.0f };*/

        //pega os 4 inputs
        Vector2 direcao = Input.GetVector("a", "d", "w", "s");
        if (direcao == Vector2.Right)//if
        {
            Position += Position with { X = velocidade, Y = 0f };
        }
        else if (direcao == Vector2.Left)//elif
        {
            Position += Position with { X = -velocidade, Y = 0f };
        }
        else if (direcao == Vector2.Down)
        {
            Position += Position with { Y = velocidade, X = 0f };
        }
        //ná godot á utura positva o valor dela acaba sendo negativa
        else if (direcao == Vector2.Up)
        {
            Position += Position with { Y = -velocidade, X = 0f };
        }

        //faz o loop acontece direito ná godot
        base._Process(delta);
    }

}