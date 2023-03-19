using FlappyBird;
using FlappyBird.Events;
using NUnit.Framework;
using UnityEngine;

public class BirdBehaviourTests
{
	[Test]
	public void Should_Jump_WhenSpacebarKeyDownAndGameIsOn()
	{
		//Arrange
		var jumperSpy = new JumperSpy();
		var birdBehaviourWrapper = SetUpBirdBehaviourForJump(jumperSpy, new NoOpJumper(), new KeyInputStub(KeyCode.Space));
		//Act
		birdBehaviourWrapper.Update();
		//Assert
		Assert.IsTrue(jumperSpy.IsInvoked);
	}

	[Test]
	public void Should_Jump_WhenSpacebarKeyDownAndGameIsOnAfterReset()
	{
		//Arrange
		var jumperSpy = new JumperSpy();
		var birdBehaviourWrapper = SetUpBirdBehaviourForJump(jumperSpy, new NoOpJumper(), new KeyInputStub(KeyCode.Space));
		birdBehaviourWrapper.MonoBehaviour.OnGameReset(new GameResetSignal());
		//Act
		birdBehaviourWrapper.Update();
		//Assert
		Assert.IsTrue(jumperSpy.IsInvoked);
	}

	[Test]
	public void Should_NotJump_WhenSpacebarKeyDownAndGameIsOver()
	{
		//Arrange
		var noOpJumperSpy = new JumperSpy();
		var dummyJumper = new NoOpJumper();
		var birdBehaviourWrapper = SetUpBirdBehaviourForJump(dummyJumper, noOpJumperSpy, new KeyInputStub(KeyCode.Space));
		birdBehaviourWrapper.MonoBehaviour.OnGameOver(new GameOverSignal());
		//Act
		birdBehaviourWrapper.Update();
		//Assert
		Assert.IsTrue(noOpJumperSpy.IsInvoked);
	}

	[Test]
	public void Should_NotJump_WhenSpacebarKeyNotDownAndGameIsOver()
	{
		//Arrange
		var noOpJumperSpy = new JumperSpy();
		var dummyJumper = new NoOpJumper();
		var birdBehaviourWrapper = SetUpBirdBehaviourForJump(dummyJumper, noOpJumperSpy, new KeyInputStub(KeyCode.None));
		birdBehaviourWrapper.MonoBehaviour.OnGameOver(new GameOverSignal());
		//Act
		birdBehaviourWrapper.Update();
		//Assert
		Assert.IsTrue(noOpJumperSpy.IsInvoked);
	}

	[Test]
	public void Should_NotJump_WhenSpacebarKeyNotDownAndGameIsOn()
	{
		//Arrange
		var noOpJumperSpy = new JumperSpy();
		var dummyJumper = new NoOpJumper();
		var birdBehaviourWrapper = SetUpBirdBehaviourForJump(dummyJumper, noOpJumperSpy, new KeyInputStub(KeyCode.None));
		//Act
		birdBehaviourWrapper.Update();
		//Assert
		Assert.IsTrue(noOpJumperSpy.IsInvoked);
	}

	[Test]
	public void Should_FireBirdHitThePipeSignal_WhenCollided()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<BirdHitThePipeUISignal>();
		var birdBehaviourWrapper = SetUpBirdBehaviourForCollusion(eventBusSpy);
		//Act
		birdBehaviourWrapper.OnCollisionEnter2D(new Collision2D());
		//Assert
		Assert.True(eventBusSpy.IsExpectedEventFired());
	}

	private MonoReflector<BirdBehaviour> SetUpBirdBehaviourForCollusion(IEventBus _eventBusSpy)
	{
		var birdBehaviourWrapper = new MonoReflector<BirdBehaviour>();
		birdBehaviourWrapper.MonoBehaviour.Construct(_eventBusSpy, new JumperFactory(new KeyInput(), new NoOpJumper(), new NoOpJumper()));
		return birdBehaviourWrapper;
	}

	private MonoReflector<BirdBehaviour> SetUpBirdBehaviourForJump(Jumper jumper, Jumper noOpJumper, KeyInput keyInput)
	{
		var birdBehaviourWrapper = new MonoReflector<BirdBehaviour>();
		birdBehaviourWrapper.MonoBehaviour.Construct(new EventBusSpy<BirdHitThePipeUISignal>(), new JumperFactory(keyInput, jumper, noOpJumper));
		return birdBehaviourWrapper;
	}
}