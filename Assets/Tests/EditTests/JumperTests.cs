using FlappyBird;
using NUnit.Framework;
using UnityEngine;

public class JumperTests
{
	[Test]
	public void ShouldJump()
	{
		var rigidBody = GetRigidBody();
		var originalVelocity = rigidBody.velocity;

		var jumper = new Jumper(rigidBody);
		jumper.Move();
		Assert.AreEqual(rigidBody.velocity, Vector2.up * 10);
	}

	private static Rigidbody2D GetRigidBody()
	{
		var gameObject = new GameObject();
		var rigidBody = gameObject.AddComponent<Rigidbody2D>();
		return rigidBody;
	}
}
