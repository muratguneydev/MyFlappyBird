using System;

namespace FlappyBird
{
	public class GameTimer
	{
		private readonly float _triggerCounter;
		private readonly Action _onElapsed;
		private float timer = 0;

		public GameTimer(float triggerCounter, Action onElapsed)
		{
			_triggerCounter = triggerCounter;
			_onElapsed = onElapsed;
		}

		public void Tick(float deltaTime)
		{
			timer += deltaTime;

			if (timer >= _triggerCounter)
			{
				_onElapsed();
				timer = 0;
			}
			//Debug.Log(timer);
		}
	}
}