using FlappyBird.Events;
using UnityEngine.SceneManagement;

namespace FlappyBird
{
	public class GameController
	{
		private readonly IEventBus _eventBus;

		public GameController(IEventBus eventBus)
		{
			_eventBus = eventBus;
		}

		//Note: We are not directly raising domain events from UIEventHandler or handling those events there. We are raising UI events instead and subscribe to those here.
		public void OnResetButtonClicked(OnResetButtonClickedUISignal onResetButtonClickedUISignal)
		{
			//TODO: Do these in UIEventHandler as they are UI related?
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			onResetButtonClickedUISignal.GameOverScreen.SetActive(false);
			//
			_eventBus.Fire(new GameResetSignal());
		}

		public void OnBirdHitThePipe(BirdHitThePipeUISignal birdHitThePipeSignal)
		{
			birdHitThePipeSignal.GameOverScreen.SetActive(true);
			_eventBus.Fire(new GameOverSignal());
		}
	}
}
