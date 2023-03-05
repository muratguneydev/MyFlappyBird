using FlappyBird;
using UnityEngine;

public class ObjectDestroyerSpy : ObjectDestroyer
{
	public bool IsDestroyInvoked { get; private set; }
	public override void Destroy(GameObject gameObject)
	{
		IsDestroyInvoked = true;
	}
}
