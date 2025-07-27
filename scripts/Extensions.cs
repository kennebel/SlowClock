using Godot;
using System;

public partial class Extensions : Node
{
    public static Vector2 RandOnUnitcircle()
    {
        return (new Vector2((float)GD.RandRange(-1d, 1d), (float)GD.RandRange(-1d, 1d))).Normalized();
    }
}