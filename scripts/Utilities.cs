using Godot;
using System;

public partial class Utilities : Node
{
    public const float TwoPi = (float)Math.PI * 2f;

    public static Vector2 RandOnUnitcircle()
    {
        return (new Vector2((float)GD.RandRange(-1d, 1d), (float)GD.RandRange(-1d, 1d))).Normalized();
    }
}