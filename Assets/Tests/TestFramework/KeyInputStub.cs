using FlappyBird;
using UnityEngine;

public class KeyInputStub : KeyInput
{
	private readonly KeyCode _keyCode;

	public KeyInputStub(KeyCode keyCode)
	{
		_keyCode = keyCode;
	}
	public override bool GetKeyDown(KeyCode keyCode)
	{
		return keyCode == _keyCode;
	}
}