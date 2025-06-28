using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private StateMachine stateMachine;

    public override void _Ready()
    {
        stateMachine = new StateMachine();
        stateMachine.Owner = this;

        stateMachine.AddState("idle", new IdleState());
        stateMachine.AddState("walk", new WalkState());
        stateMachine.AddState("jump", new JumpState());

        stateMachine.SetInitialState("jump");
    }

    public override void _Process(double delta)
    {
        stateMachine.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        stateMachine.PhysicsUpdate(delta);
    }

    public override void _Input(InputEvent @event)
    {
        stateMachine.HandleInput(@event);
    }
}
