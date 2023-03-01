using UnityEngine;
using TMPro;
using FlappyBird.Events;

public class Score : MonoBehaviour
{
    public TMP_Text _scoreText;
	private int _score;

	[ContextMenu("Increment Score")]
	public void Increment(GoneThroughPipesSignal signal)
	{
		_score++;
		_scoreText.text = _score.ToString();
	}
}
