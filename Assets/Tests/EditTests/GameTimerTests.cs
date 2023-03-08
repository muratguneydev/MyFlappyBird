using FlappyBird;
using NUnit.Framework;

public class GameTimerTests
{
	private bool _hasElapsed;

	[Test]
	public void ShouldExecuteOnTimeElapsed()
	{
		var timer = new GameTimer(0.02f, Elapsed);
		timer.Tick(0.005f);
		Assert.IsFalse(_hasElapsed);
		timer.Tick(0.01f);
		Assert.IsFalse(_hasElapsed);
		timer.Tick(0.01f);
		Assert.IsTrue(_hasElapsed);
	}

	private void Elapsed()
	{
		_hasElapsed = true;
	}
}
