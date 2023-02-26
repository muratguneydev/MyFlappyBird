using UnityEngine;

namespace FlappyBird
{
	public class LeftMover
	{
		private float moveSpeed;

		public LeftMover(float moveSpeed)
		{
			this.moveSpeed = moveSpeed;
		}

		public virtual Vector3 Move(Vector3 currentPosition, float deltaTime)
		{
			return currentPosition + (Vector3.left * moveSpeed) * deltaTime;
		}
	}
}