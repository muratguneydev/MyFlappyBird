using FlappyBird;
using NUnit.Framework;

public class YPositionRandomizerTests
{
	private const float Offset = 10f;

	[Test]
	public void ShouldRandomizeYPositionWithOffset()
	{
		var currentY = 29f;
		var yRandomizer = new YPositionRandomizer(Offset);
		var y = yRandomizer.Get(currentY);

		Assert.IsTrue(y >= 19f && y <= 39f);
	}
}
