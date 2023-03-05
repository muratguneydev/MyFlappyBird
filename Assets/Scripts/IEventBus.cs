using System;

namespace FlappyBird
{
	public interface IEventBus
	{
		void Fire<TEvent>(TEvent @event);
		void Subscribe<TEvent>(Action<TEvent> callback);
		void Unsubscribe<TEvent>(Action<TEvent> callback);
	}
}