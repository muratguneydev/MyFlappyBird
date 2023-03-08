using FlappyBird;
using NUnit.Framework;

public class YPositionRandomizerTests
{
	private const float Offset = 13f;

	[Test]
	public void ShouldRandomizeYPositionWithOffset()
	{
		var currentY = 29f;
		var yRandomizer = new YPositionRandomizer(Offset);
		var y = yRandomizer.Get(currentY);

		Assert.IsTrue(y >= 16f && y <= 42f);
	}
}
