using Godot;
using System;

public partial class Ship : Node2D
{
	[ExportGroup("Visual")]
	[Export]
	public Texture2D[] VisualTextures { get; set; }
	[Export]
	public Sprite2D VisualItem { get; set; }

	[ExportGroup("Limits")]
	[Export]
	public float StartCircleDistance { get; set; } = 325;
	[Export]
	public Vector2 AppCenter { get; set; } = new Vector2(256, 256);

	[ExportGroup("Movement")]
	[Export]
	public float Speed { get; set; } = 15f;

	private Vector2 TargetPos { get; set; }

	public override void _Ready()
	{
		// Temp
		StartCircleDistance = 200f;

		Reset();
	}

	public override void _Process(double delta)
	{
		// Move

		// Check distance to target
		
	}

	public void Reset()
	{
		this.Position = (Extensions.RandOnUnitcircle() * StartCircleDistance) + AppCenter;
		TargetPos = (Extensions.RandOnUnitcircle() * StartCircleDistance) + AppCenter;

		VisualItem.Texture = VisualTextures[GD.RandRange(0, VisualTextures.Length)];

		this.LookAt(TargetPos);
	}
}
