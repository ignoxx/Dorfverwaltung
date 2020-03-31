using Godot;
using System.Collections.Generic;
using Dorfverwaltung;


public class UI : Control
{
	private Label IncomeValue;
	private PackedScene TribeItem = GD.Load<PackedScene>("res://TribeItem.tscn");

	public override void _Ready()
	{
		IncomeValue = GetNode<Label>("PanelContainer/VBoxContainer/TabContainer/Overview/VBoxContainer/IncomeOverview/IncomeValue");

		//Tribes
		Tribe t1 = new Tribe() { Name = "Altobarden", ExistingSince = "1247 ndK" };
		Tribe t2 = new Tribe() { Name = "Elbknechte", ExistingSince = "1023 ndK" };

		// Weapons
		var w1 = new Weapon() { Type = "Axt", MagicValue = 12 };
		var w2 = new Weapon() { Type = "Schwert", MagicValue = 15 };
		var w3 = new Weapon() { Type = "Axt", MagicValue = 17 };
		var w4 = new Weapon() { Type = "Zauberstab", MagicValue = 45 };
		var w5 = new Weapon() { Type = "Streithammer", MagicValue = 15 };

		//Dwarfs
		var d1 = new Dwarf() { Name = "Gimli", Age = 140, Tribe = t1, Weapons = new List<Weapon>() { w1, w2 } };
		var d2 = new Dwarf() { Name = "Zwingli", Age = 70, Tribe = t1, Weapons = new List<Weapon>() { w3 } };
		var d3 = new Dwarf() { Name = "Gumli", Age = 163, Tribe = t2, Weapons = new List<Weapon>() { w4, w5 } };

		t1.Leader = d1;
		t1.LeaderSince = "25 years";

		t2.Leader = d3;
		t2.LeaderSince = "? years";


		AddTribe(t1);
		AddTribe(t2);
		AddTribe(t2);
		AddTribe(t2);
	}

	public void AddIncome(double value)
	{
		IncomeValue.Text += value.ToString();
	}
	public void SetTotalIncome(double value)
	{
		IncomeValue.Text = value.ToString();
	}

	public void AddTribe(Tribe tribe)
	{
		var t = TribeItem.Instance();
		t.Name = tribe.Name;

		foreach (var member in tribe.Members)
			t.Call("AddMember", member.Name);
		

		var node = GetNode<VBoxContainer>("PanelContainer/VBoxContainer/TabContainer/Overview/VBoxContainer/ScrollContainer/SubIncome");
		node.AddChild(t);

		AddIncome(tribe.Force);
		tribe.CalculateForce();
		SetTotalIncome(tribe.Tax);
	}
}
