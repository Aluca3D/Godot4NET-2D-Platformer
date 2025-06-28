using Godot;
using System;

[GlobalClass]
public partial class IdleState : RefCounted, IState
{
	public StateMachine StateMachine { get; set; }

	public void Enter(string prevState = "")
	{
		GD.Print("Entering Idle state");
	}

	public void Exit() { }

	public void Update(double delta) { }

	public void PhysicsUpdate(double delta) { }

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
