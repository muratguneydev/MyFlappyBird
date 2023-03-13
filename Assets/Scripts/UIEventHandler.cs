using System.Collections;
using System.Collections.Generic;
using FlappyBird;
using FlappyBird.Events;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIEventHandler : MonoBehaviour
{
	[SerializeField] private GameObject _gameOverScreen;
	private IEventBus _eventBus;

	[Inject]
	public void Construct(IEventBus eventBus)
	{
		_eventBus = eventBus;
	}

	public GameObject Get_gameOverScreen()
	{
		return _gameOverScreen;
	}

	// // Start is called before the first frame update
	// void Start()
	// {
	// 	// var button = transform.GetComponent<Button>();
	// 	// Debug.Log($"Button:{button}");
	// }

	// // Update is called once per frame
	// void Update()
	// {

	// }

	public void OnResetButtonClicked(GameObject _gameOverScreen)
	{
		Debug.Log($"Event bus:{_eventBus}");
		_eventBus.Fire(new GameResetSignal(_gameOverScreen));
		Debug.Log("Game reset fired.");
	}
}
