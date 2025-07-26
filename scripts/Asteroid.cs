using Godot;
using System;

public partial class Asteroid : Node2D
{
	[ExportGroup("Visual")]
	[Export]
	public Texture2D[] VisualTextures { get; set; }
	[Export]
	public Sprite2D VisualItem { get; set; }

	[ExportGroup("Limits")]
	[Export]
	public int StartY { get; set; } = -100;
	[Export]
	public int EndY { get; set; } = 600;

	[ExportGroup("Movement")]
	[Export]
	public double DownSpeed = 12f;
	[Export]
	public double DownVariation = 6f;
	[Export]
	public double SideSpeed = 0f;
	[Export]
	public double SideVariation = 3f;

	private float ActualDownSpeed { get; set; }
	private float ActualSideSpeed { get; set; }

	public override void _Ready()
	{
		Reset();
	}

	public override void _Process(double delta)
	{
		var OldPos = this.Position;
		this.Position = new Vector2(OldPos.X + (ActualSideSpeed * (float)delta), OldPos.Y + (ActualDownSpeed * (float)delta));

		if (this.Position.Y > EndY)
		{
			Reset();
		}
	}

	protected void Reset()
	{
		this.Position = new Vector2(GD.RandRange(0, 512), StartY);

		ActualDownSpeed = (float)(DownSpeed + (float)GD.RandRange(0d, DownVariation));
		ActualSideSpeed = (float)(SideSpeed + (float)GD.RandRange(-SideVariation, SideVariation));

		VisualItem.Texture = VisualTextures[GD.RandRange(0, VisualTextures.Length)];

		//GD.Print("New Asteroid Params: <", this.Position.X, ",", this.Position.Y, "> | Down: ", ActualDownSpeed, " | Side: ", ActualSideSpeed);
	}
}
