using Godot;
using System;
using System.Collections.Generic;
using Dorfverwaltung;

public class TribeItem : Control
{
	private PackedScene TribeMember = GD.Load<PackedScene>("res://TribeMember.tscn");
	public List<PackedScene> Members;
	
	public override void _Ready()
	{
		
	}
	
	public void AddMember(string memberName)
	{
		var Member = TribeMember.Instance();
		Member.GetNode<Label>("MemberName").Text = memberName;
		//Member.GetNode<Label>("MemberTax").Text = member.Tribe.Tax.ToString();

		GetNode<VBoxContainer>("Content/ScrollContainer/Members").AddChild(Member);
	}
}
