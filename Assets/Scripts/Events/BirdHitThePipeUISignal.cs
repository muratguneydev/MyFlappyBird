using UnityEngine;

namespace FlappyBird.Events
{
	public class BirdHitThePipeUISignal
	{

		public BirdHitThePipeUISignal(GameObject gameOverScreen)
		{
			GameOverScreen = gameOverScreen;
		}

		public GameObject GameOverScreen { get; }
	}
}