using Godot;
using System;

[GlobalClass]
public partial class WalkState : RefCounted, IState
{
    public StateMachine StateMachine { get; set; }

    private CharacterBody2D character;

    public void Enter(string prevState = "")
    {
        character = StateMachine.Owner;
		GD.Print("Entering Walk state");
    }

    public void Exit() { }

    public void Update(double delta) { }

    public void PhysicsUpdate(double delta)
    {
        float direction = Input.GetAxis("Left", "Right");
        var velocity = character.Velocity;

        if (direction == 0)
        {
            StateMachine.ChangeState("idle");
            return;
        }

        velocity.X = direction * 200;
        character.Velocity = velocity;
        character.MoveAndSlide();
    }

    public void HandleInput(InputEvent @event)
    {
        if (Input.IsActionPressed("Jump"))
        {
            StateMachine.ChangeState("jump");
        }
    }
}
