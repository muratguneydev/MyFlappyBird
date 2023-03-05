using System;

namespace FlappyBird
{
	public class GameTimer
	{
		private readonly float _requiredElapsedSecondsForTrigger;
		private readonly Action _onElapsed;
		private float _currentElapsedSeconds;

		public GameTimer(float requiredElapsedSecondsForTrigger, Action onElapsed)
		{
			_requiredElapsedSecondsForTrigger = requiredElapsedSecondsForTrigger;
			_onElapsed = onElapsed;
		}

		public void Tick(float deltaTimeInSeconds)
		{
			UpdateCurrentElapsedSeconds(deltaTimeInSeconds);
			if (_currentElapsedSeconds < _requiredElapsedSecondsForTrigger)
				return;
			
			_onElapsed();
			ResetCurrentElapsedSeconds();
		}

		private void ResetCurrentElapsedSeconds()
		{
			_currentElapsedSeconds = 0;
		}

		private void UpdateCurrentElapsedSeconds(float deltaTimeInSeconds)
		{
			_currentElapsedSeconds += deltaTimeInSeconds;
		}
	}
}