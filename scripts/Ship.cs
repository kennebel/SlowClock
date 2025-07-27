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
	public float StartCircleDistance { get; set; } = 350;
	[Export]
	public Vector2 AppCenter { get; set; } = new Vector2(256, 256);

	[ExportGroup("Movement")]
	[Export]
	public float Speed { get; set; } = 15f;

	private Vector2 TargetPos { get; set; }

	public override void _Ready()
	{
		Reset();
	}

	public override void _Process(double delta)
	{
		// Move
		this.Position += this.Transform.X * (Speed * (float)delta);

		// Check distance from center, when off screen reset
		if ((this.Position - AppCenter).Length() > StartCircleDistance)
		{
			Reset();
		}
	}

	public void Reset()
	{
		// Start and Target positions
		this.Position = (Utilities.RandOnUnitcircle() * StartCircleDistance) + AppCenter;
		TargetPos = (Utilities.RandOnUnitcircle() * StartCircleDistance) + AppCenter;

		// Rotate to update transform for new target
		this.LookAt(TargetPos);

		// Pick new random image
		VisualItem.Texture = VisualTextures[GD.RandRange(0, VisualTextures.Length)];
	}
}
