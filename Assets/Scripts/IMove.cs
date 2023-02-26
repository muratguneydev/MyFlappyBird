using UnityEngine;

namespace FlappyBird
{
	public interface IMove
	{
		void Move(Rigidbody2D rigidbody);
	}
}