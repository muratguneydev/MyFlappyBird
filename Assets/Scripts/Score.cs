using UnityEngine;
using TMPro;
using FlappyBird.Events;
using Zenject;

public class Score : MonoBehaviour
{
	public TMP_Text _scoreText;
	private int _scorePoints;
	private SignalBus _signalBus;

	[Inject]
	public void Construct(SignalBus signalBus)
	{
		Debug.Log("Constructed Score.");
		//https://github.com/modesttree/Zenject/blob/master/Documentation/Signals.md
		_signalBus = signalBus;
		_signalBus.Subscribe<GoneThroughPipesSignal>(Increment);
	}

	//TODO: This is not called. Find out a destructor method.
	void Destroy()
	{
		Debug.Log("Destroying Score.");
		_signalBus.Unsubscribe<GoneThroughPipesSignal>(Increment);
	}

	//[ContextMenu("Increment Score")]
	public void Increment(GoneThroughPipesSignal signal)
	{
		_scorePoints++;
		_scoreText.text = _scorePoints.ToString();
	}
}
