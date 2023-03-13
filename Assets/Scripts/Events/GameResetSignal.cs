using UnityEngine;

namespace FlappyBird.Events
{
	public class GameResetSignal
	{
		public GameResetSignal(GameObject gameOverScreen)
		{
			GameOverScreen = gameOverScreen;
		}

		public GameObject GameOverScreen { get; }
	}
}