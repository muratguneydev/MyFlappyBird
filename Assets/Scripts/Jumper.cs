using UnityEngine;

namespace FlappyBird
{
	public class Jumper : IMove
	{
		private readonly Rigidbody2D rigidbody;

		public Jumper(Rigidbody2D rigidbody)
		{
			this.rigidbody = rigidbody;
		}

		public void Move()
		{
			this.rigidbody.velocity = Vector2.up * 10;
		}
	}
}