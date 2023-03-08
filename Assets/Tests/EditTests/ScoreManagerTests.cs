using FlappyBird;
using FlappyBird.Events;
using NUnit.Framework;

public class ScoreManagerTests
{
	private int _score;
	[Test]
	public void ShouldImcrement()
	{
		var scoreManager = new ScoreManager();
		scoreManager.OnChange += OnScoreChange;
		
		scoreManager.Increment(new GoneThroughPipesSignal());
		Assert.AreEqual(1, _score);

		scoreManager.Increment(new GoneThroughPipesSignal());
		Assert.AreEqual(2, _score);

		scoreManager.Increment(new GoneThroughPipesSignal());
		scoreManager.Increment(new GoneThroughPipesSignal());
		Assert.AreEqual(4, _score);
	}

	private void OnScoreChange(int newScore)
	{
		_score = newScore;
	}
}