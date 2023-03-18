using UnityEngine;

namespace FlappyBird.Events
{
	public class BirdHitThePipeSignal
	{

		public BirdHitThePipeSignal(GameObject gameOverScreen)
		{
			GameOverScreen = gameOverScreen;
		}

		public GameObject GameOverScreen { get; }
	}
}