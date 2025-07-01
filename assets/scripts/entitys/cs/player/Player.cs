using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private StateMachine stateMachine;

    [Export] private int _SPEED = 200;
    [Export] private int _JUMP_HEIGHT = -200;
    [Export] private int _GRAVITY = 800;
    
    public override void _Ready()
    {
        stateMachine = new StateMachine();
        stateMachine.Owner = this;

        stateMachine.AddVariable("SPEED", _SPEED);
        stateMachine.AddVariable("JUMP_HEIGHT", _JUMP_HEIGHT);
        stateMachine.AddVariable("GRAVITY", _GRAVITY);

        stateMachine.AddState("idle", new IdleState());
        stateMachine.AddState("walk", new WalkState());
        stateMachine.AddState("jump", new JumpState());
        stateMachine.AddState("fall", new FallState());

        stateMachine.SetInitialState("idle");
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
