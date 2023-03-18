using FlappyBird.Events;
using UnityEngine.SceneManagement;

namespace FlappyBird
{
	public class GameController
	{
		public void OnReset(GameResetSignal gameResetSignal)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			gameResetSignal.GameOverScreen.SetActive(false);
		}

		public void OnBirdHitThePipe(BirdHitThePipeSignal birdHitThePipeSignal)
		{
			birdHitThePipeSignal.GameOverScreen.SetActive(true);
		}
	}
}
