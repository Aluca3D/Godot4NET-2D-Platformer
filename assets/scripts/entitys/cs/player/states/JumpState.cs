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
        var jump_height = (int)StateMachine.GetVariable("JUMP_HEIGHT");

        velocity.Y = jump_height;
        character.Velocity = velocity;
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

        if (character.Velocity.Y > 0)
        {
            StateMachine.ChangeState("fall");
        }
    }

    public void Update(double delta) { }
}
