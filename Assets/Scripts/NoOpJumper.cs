using UnityEngine;

namespace FlappyBird
{
	public class NoOpJumper : Jumper
{
	public NoOpJumper() : base(default)
	{
	}

	public override void Move(Rigidbody2D rigidbody)
	{
		//no-op
	}

}
}
