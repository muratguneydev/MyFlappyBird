using FlappyBird;
using FlappyBird.Events;
using NUnit.Framework;
using UnityEngine;

public class BirdBehaviourTests
{
	[Test]
	public void Should_Jump_WhenSpacebarKeyDown()
	{
		//Arrange
		var jumperSpy = new JumperSpy();
		var birdBehaviourWrapper = SetUpBirdBehaviourForJump(jumperSpy);
		//Act
		birdBehaviourWrapper.Update();
		//Assert
		Assert.IsTrue(jumperSpy.IsInvoked);
	}

	[Test]
	public void Should_FireBirdHitThePipeSignal_WhenCollided()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<BirdHitThePipeSignal>();
		var birdBehaviourWrapper = SetUpBirdBehaviourForCollusion(eventBusSpy);
		//Act
		birdBehaviourWrapper.OnCollisionEnter2D(new Collision2D());
		//Assert
		Assert.True(eventBusSpy.IsExpectedEventFired());
	}

	private MonoReflector<BirdBehaviour> SetUpBirdBehaviourForCollusion(IEventBus _eventBusSpy)
	{
		var birdBehaviourWrapper = new MonoReflector<BirdBehaviour>();
		birdBehaviourWrapper.MonoBehaviour.Construct(_eventBusSpy, new Jumper(default), new KeyInput());
		return birdBehaviourWrapper;
	}

	private MonoReflector<BirdBehaviour> SetUpBirdBehaviourForJump(Jumper jumper)
	{
		var birdBehaviourWrapper = new MonoReflector<BirdBehaviour>();
		birdBehaviourWrapper.MonoBehaviour.Construct(new EventBusSpy<BirdHitThePipeSignal>(), jumper, new KeyInputStub(KeyCode.Space));
		return birdBehaviourWrapper;
	}
}