using System;
using FlappyBird;

public class GameTimerFake : GameTimer
{
	public GameTimerFake(Action onElapsed)
		: base(0, onElapsed)
	{
	}
}
