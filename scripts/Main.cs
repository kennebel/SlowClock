using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Node
{
	[ExportGroup("Asteroids")]
	[Export]
	public int AsteroidCount { get; set; } = 6;
	[Export]
	public PackedScene AsteroidTemplate { get; set; }
	[Export]
	public Node2D AsteroidHolder{ get; set; }

	[ExportGroup("Ships")]
	[Export]
	public int ShipCount { get; set; } = 4;
	[Export]
	public PackedScene ShipTemplate{ get; set; }
	[Export]
	public Node2D ShipHolder { get; set; }

	private double LastAsteroidGen { get; set; }
	private double LastShipGen { get; set; }

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

		if (ShipHolder.GetChildCount() < ShipCount)
		{
			LastShipGen += delta;
			if (LastShipGen >= 2d)
			{
				LastShipGen = 0;
				ShipHolder.AddChild(ShipTemplate.Instantiate());
			}
		}
	}
}
