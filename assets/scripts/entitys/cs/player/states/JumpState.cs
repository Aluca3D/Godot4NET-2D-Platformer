using Godot;
using System;

[GlobalClass]
public partial class JumpState : RefCounted, IState
{
    public StateMachine StateMachine { get; set; }
    private CharacterBody2D character;

    public void Enter(string prevState = "")
    {
        character = StateMachine.Owner;
		GD.Print("Entering Jump state");
        var velocity = character.Velocity;
        velocity.Y = -400;
        character.Velocity = velocity;
    }

    public void Exit() { }

    public void HandleInput(InputEvent inputEvent) { }

    public void PhysicsUpdate(double delta)
    {
        float direction = Input.GetAxis("Left", "Right");
        var velocity = character.Velocity;

        velocity.Y += 980 * (float)delta;

        velocity.X = direction * 200;
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
