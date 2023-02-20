using FlappyBird;
using NUnit.Framework;
using UnityEngine;

public class GameTimerTests
{
	private bool _hasElapsed;

	[Test]
	public void ShouldExecuteOnTimeElapsed()
	{
		var timer = new GameTimer(0.02f, Elapsed);
		//IncreaseTheTimeScaleToElapseQuickly();
		timer.Tick(0.005f);
		Assert.IsFalse(_hasElapsed);
		timer.Tick(0.01f);
		Assert.IsFalse(_hasElapsed);
		timer.Tick(0.01f);
		Assert.IsTrue(_hasElapsed);
		//RestoreTheTimeScaleToOriginal();
	}

	// private static void RestoreTheTimeScaleToOriginal()
	// {
	// 	Time.timeScale = 1.0f;
	// }

	// private static void IncreaseTheTimeScaleToElapseQuickly()
	// {
	// 	Time.timeScale = 20.0f;
	// }

	private void Elapsed()
	{
		_hasElapsed = true;
	}
}