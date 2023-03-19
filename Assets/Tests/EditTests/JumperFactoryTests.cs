using FlappyBird;
using NUnit.Framework;
using UnityEngine;

public class JumperFactoryTests
{
	[Test]
	public void Creates_NoOpJumper_WhenGameIsOver()
	{
		//Arrange
		var (jumperFactory, jumper, noOpJumper) = PopulateFactory(new KeyInputStub(KeyCode.None));
		//Act
		var result = jumperFactory.Get(isGameOver: true);
		//Assert
		Assert.AreEqual(noOpJumper, result);
	}

	[Test]
	public void Creates_NoOpJumper_WhenGameIsOverAndSpaceKeyPressed()
	{
		//Arrange
		var (jumperFactory, jumper, noOpJumper) = PopulateFactory(new KeyInputStub(KeyCode.Space));
		//Act
		var result = jumperFactory.Get(isGameOver: true);
		//Assert
		Assert.AreEqual(noOpJumper, result);
	}

	[Test]
	public void Creates_Jumper_WhenGameIsOnAndSpaceKeyPressed()
	{
		//Arrange
		var (jumperFactory, jumper, noOpJumper) = PopulateFactory(new KeyInputStub(KeyCode.Space));
		//Act
		var result = jumperFactory.Get(isGameOver: false);
		//Assert
		Assert.AreEqual(jumper, result);
	}

	[Test]
	public void Creates_NoOpJumper_WhenGameIsOnAndSpaceKeyNotPressed()
	{
		//Arrange
		var (jumperFactory, jumper, noOpJumper) = PopulateFactory(new KeyInputStub(KeyCode.None));
		//Act
		var result = jumperFactory.Get(isGameOver: false);
		//Assert
		Assert.AreEqual(noOpJumper, result);
	}

	private static (JumperFactory, Jumper, NoOpJumper) PopulateFactory(KeyInput keyInput)
	{
		var jumper = new Jumper(default);
		var noOpJumper = new NoOpJumper();
		return (new JumperFactory(keyInput, jumper, noOpJumper), jumper, noOpJumper);
	}
}