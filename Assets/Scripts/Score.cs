using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text _scoreText;
	private int _score;

	[ContextMenu("Increment Score")]
	public void Increment()
	{
		_score++;
		_scoreText.text = _score.ToString();
	}
}
