using System;
using System.Collections.Generic;
using System.Linq;
using FlappyBird;
using UnityEngine;

public class EventBusSpy<T> : IEventBus where T : class
{
	private List<T> _firedEvents = new();
	private List<Action<T>> _subscriptions = new();

	public void Fire<TEvent>(TEvent @event)
	{
		Debug.Log($"Spy Event Bus fired event:{@event}");
		var firedEvent = @event as T;
		if (firedEvent == null)
			return;


		_firedEvents.Add(firedEvent);
		foreach (var subscripton in _subscriptions)
			subscripton(firedEvent);

	}

	public void Subscribe<TEvent>(Action<TEvent> callback)
	{
		if (typeof(TEvent) != typeof(T))
			return;
		_subscriptions.Add(callback as Action<T>);
	}

	public void Unsubscribe<TEvent>(Action<TEvent> callback)
	{
		if (typeof(TEvent) != typeof(T))
			return;
		_subscriptions.Remove(callback as Action<T>);
	}

	public bool IsExpectedEventFired()
	{
		return _firedEvents.Any(firedEvent => firedEvent is T);
	}
}
