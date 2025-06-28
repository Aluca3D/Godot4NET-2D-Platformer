using Godot;
using System;

public interface IState
{
	public StateMachine StateMachine { get; set; }
	void Enter(String prevState = "");
	void Exit();
	void Update(double delta);
	void PhysicsUpdate(double delta);
	void HandleInput(InputEvent inputEvent);
}
