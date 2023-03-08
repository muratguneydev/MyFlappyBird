using FlappyBird;

public class YPositionRandomizerFake : YPositionRandomizer
{
	private readonly float[] _yPositionsToReturn;
	private int _currentYPositionIndex;

	public YPositionRandomizerFake(float[] yPositionsToReturn)
			: base(default)
	{
		_yPositionsToReturn = yPositionsToReturn;
	}

	public override float Get(float currentY)
	{
		return _yPositionsToReturn[_currentYPositionIndex++];
	}
}