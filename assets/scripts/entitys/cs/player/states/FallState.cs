using Godot;
using System;

[GlobalClass]
public partial class FallState : RefCounted, IState
{
	public StateMachine StateMachine { get; set; }
	private CharacterBody2D character;


	public void Enter(string prevState = "")
	{
		character = StateMachine.Owner;

		GD.Print("Entering Fall state");
	}

	public void Exit() { }

	public void HandleInput(InputEvent inputEvent) { }



	public void PhysicsUpdate(double delta)
	{
		float direction = Input.GetAxis("Left", "Right");
		var velocity = character.Velocity;
		var speed = (int)StateMachine.GetVariable("SPEED");
		var gravity = (int)StateMachine.GetVariable("GRAVITY");

		velocity.Y += gravity * (float)delta;

		velocity.X = direction * speed;
		character.Velocity = velocity;
		character.MoveAndSlide();

		if (character.IsOnFloor())
		{
			if (direction != 0)
			{
				StateMachine.ChangeState("walk");
			}
			else
			{
				StateMachine.ChangeState("idle");
			}
		}

	}

	public void Update(double delta) { }
}
