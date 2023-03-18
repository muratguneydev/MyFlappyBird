using FlappyBird;
using UnityEngine;

public class JumperSpy : Jumper
{
	public JumperSpy() : base(default)
	{
	}

	public bool IsInvoked { get; private set; }

	public override void Move(Rigidbody2D rigidbody)
	{
		IsInvoked = true;
	}

}