using UnityEngine;

namespace FlappyBird
{
	public class Jumper : IMove
	{
		private readonly Rigidbody2D rigidbody;

		public void Move(Rigidbody2D rigidbody)
		{
			rigidbody.velocity = Vector2.up * 10;
		}
	}
}
