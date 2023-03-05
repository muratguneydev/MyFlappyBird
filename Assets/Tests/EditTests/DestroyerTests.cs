using FlappyBird;
using FlappyBird.Events;
using NUnit.Framework;
using UnityEngine;

public class DestroyerTests
{
	[TestCase(-23f, -40f, true, "Game object should be destroyed.")]
	[TestCase(-23f, -10f, false, "Game object should not be destroyed.")]
	public void ShouldDestroyIfInDeadZone(float deadZoneX, float objectCurrentX, bool shouldBeDestroyed, string failureMessage)
	{
		var objectDestroyerSpy = new ObjectDestroyerSpy();
		var destroyer = new Destroyer(deadZoneX, objectDestroyerSpy);
		
		var objectToBeDestroyed = new GameObject();
		objectToBeDestroyed = GameObject.Instantiate(objectToBeDestroyed, new Vector3(objectCurrentX, 0, 0), Quaternion.identity);
		destroyer.OnObjectMoved(new ObjectMovedSignal(objectToBeDestroyed));
		Assert.AreEqual(shouldBeDestroyed, objectDestroyerSpy.IsDestroyInvoked, failureMessage);
	}
}
