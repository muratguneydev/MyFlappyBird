using FlappyBird;
using NUnit.Framework;
using UnityEngine;

public class LeftMoverTests
{
	[TestCase(0, 0, 0.7f, 10f, -7f, 0)]
	[TestCase(3, 9, 0.7f, 10f, -4f, 9f)]
	public void ShouldMoveLeft(float currentX, float currentY, float deltaTime, float moveSpeed, float expectedX, float expectedY)
	{
		var leftMover = new LeftMover(moveSpeed);
		var newPosition = leftMover.Move(new Vector3(currentX, currentY, 0), deltaTime);
		Assert.AreEqual(new Vector3(expectedX, expectedY, 0), newPosition);

	}
}
