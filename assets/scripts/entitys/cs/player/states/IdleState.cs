using Godot;
using System;

[GlobalClass]
public partial class IdleState : RefCounted, IState
{
	public StateMachine StateMachine { get; set; }
	private CharacterBody2D character;

	public void Enter(string prevState = "")
	{
		character = StateMachine.Owner;
		GD.Print("Entering Idle state");
	}

	public void Exit() { }

	public void Update(double delta) { }

	public void PhysicsUpdate(double delta)
	{
		if (!character.IsOnFloor())
		{
			StateMachine.ChangeState("fall");
		}
	}

	public void HandleInput(InputEvent @event)
	{
		if (Input.IsActionPressed("Left") || Input.IsActionPressed("Right"))
		{
			StateMachine.ChangeState("walk");
		}
		else if (Input.IsActionPressed("Jump"))
		{
			StateMachine.ChangeState("jump");
		}
	}
}
