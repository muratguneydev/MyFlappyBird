using UnityEngine;

namespace FlappyBird
{
	public class Jumper : IMove
	{
		private readonly Rigidbody2D rigidbody;
		private readonly int _jumpUpVelocity;

		public Jumper(int jumpUpVelocity)
		{
			_jumpUpVelocity = jumpUpVelocity;
		}

		public void Move(Rigidbody2D rigidbody)
		{
			rigidbody.velocity = Vector2.up * _jumpUpVelocity;
		}
	}
}
