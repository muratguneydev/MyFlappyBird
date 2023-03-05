using FlappyBird;
using NUnit.Framework;
using UnityEngine;

public class JumperTests
{
	private const int JumpUpVelocity = 10;

	[Test]
	public void ShouldJump()
	{
		var rigidBody = GetRigidBody();
		var originalVelocity = rigidBody.velocity;

		var jumper = new Jumper(JumpUpVelocity);
		jumper.Move(rigidBody);
		Assert.AreEqual(Vector2.up * JumpUpVelocity, rigidBody.velocity);
	}

	private static Rigidbody2D GetRigidBody()
	{
		var gameObject = new GameObject();
		var rigidBody = gameObject.AddComponent<Rigidbody2D>();
		return rigidBody;
	}
}
