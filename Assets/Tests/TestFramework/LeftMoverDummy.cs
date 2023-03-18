using FlappyBird;
using UnityEngine;

public class LeftMoverDummy : LeftMover
{
	public LeftMoverDummy() : base(default)
	{
		
	}

	public override Vector3 Move(Vector3 currentPosition, float deltaTime)
	{
		return currentPosition;
	}
}
