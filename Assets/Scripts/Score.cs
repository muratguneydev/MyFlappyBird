using UnityEngine;
using TMPro;
using Zenject;

namespace FlappyBird
{
	public class Score : MonoBehaviour
	{
		public TMP_Text _scoreText;

		[Inject]
		public void Construct(ScoreManager scoreManager)
		{
			scoreManager.OnChange += OnScoreChanged;
		}

		private void OnScoreChanged(int score)
		{
			_scoreText.text = score.ToString();
		}
	}
}