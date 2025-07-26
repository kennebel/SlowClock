using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Node
{
	[Export]
	public int AsteroidCount { get; set; } = 6;
	[Export]
	public PackedScene AsteroidTemplate { get; set; }
	[Export]
	public Node2D AsteroidHolder{ get; set; }

	private double LastAsteroidGen { get; set; }

	public override void _Ready()
	{
		GD.Randomize();
	}

	public override void _Process(double delta)
	{
		if (AsteroidHolder.GetChildCount() < AsteroidCount)
		{
			LastAsteroidGen += delta;
			if (LastAsteroidGen >= 2d)
			{
				LastAsteroidGen = 0;
				AsteroidHolder.AddChild(AsteroidTemplate.Instantiate());
			}
		}
	}
}
