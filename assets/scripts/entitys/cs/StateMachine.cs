using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class StateMachine : RefCounted
{
	private Dictionary<string, RefCounted> states = new();
	private IState CurrentState;
	private string CurrentStateName = "";
	public CharacterBody2D Owner;

	public void AddState(string name, IState state)
	{
		states[name.ToLower()] = (RefCounted)state;
		state.StateMachine = this;
	}

	public void SetInitialState(string stateName)
	{
		ChangeState(stateName);
	}

	public void ChangeState(string newStateName)
	{
		var prevStateName = CurrentStateName;

		if (CurrentState != null)
		{
			CurrentState.Exit();
		}

		CurrentStateName = newStateName.ToLower();

		if (!states.TryGetValue(CurrentStateName, out var stateRaw))
		{
			GD.PushWarning($"State not found: {newStateName}");
			return;
		}

		if (stateRaw is IState state)
		{
			CurrentState = state;
			CurrentState.Enter(prevStateName);
		}
		else
		{
			GD.PushError($"State '{newStateName}' does not implement IState.");
		}
	}


	public void Update(double delta)
	{
		CurrentState?.Update(delta);
	}

	public void PhysicsUpdate(double delta)
	{
		CurrentState?.PhysicsUpdate(delta);
	}

	public void HandleInput(InputEvent inputEvent)
	{
		CurrentState?.HandleInput(inputEvent);
	}
}
