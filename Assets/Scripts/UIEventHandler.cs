using FlappyBird;
using FlappyBird.Events;
using UnityEngine;
using Zenject;

public class UIEventHandler : MonoBehaviour
{
	private IEventBus _eventBus;

	[Inject]
	public void Construct(IEventBus eventBus)
	{
		_eventBus = eventBus;
	}

	public void OnResetButtonClicked(GameObject gameOverScreen)
	{
		_eventBus.Fire(new OnResetButtonClickedUISignal(gameOverScreen));
		Debug.Log("Game reset fired.");
	}
}
