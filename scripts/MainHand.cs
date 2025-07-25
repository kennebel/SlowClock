using Godot;
using System;

public partial class MainHand : Node2D
{
    private const float TwoPi = (float)Math.PI * 2f;

    public override void _Process(double delta)
    {
        //this.SetRotation(((float)DateTime.Now.Second / 60f) * TwoPi);
        this.SetRotation(((float)DateTime.Now.TimeOfDay.TotalSeconds / 86400f) * TwoPi);
    }
}
