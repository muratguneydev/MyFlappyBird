using UnityEngine;

namespace FlappyBird.Events
{
	public class OnResetButtonClickedUISignal
	{
		public OnResetButtonClickedUISignal(GameObject gameOverScreen)
		{
			GameOverScreen = gameOverScreen;
		}

		public GameObject GameOverScreen { get; }
	}
}