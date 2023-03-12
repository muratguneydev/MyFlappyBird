// using UnityEngine;
// using UnityEngine.TestTools;
// using FlappyBird;

// public class BirdBehaviourTestable : BirdBehaviour, IMonoBehaviourTest
// {
// 	private int frameCount;
// 	public bool IsTestFinished
// 	{
// 		get { return frameCount > 500; }
// 	}

// 	void Update()
// 	{
// 		frameCount++;
// 	}

// 	public override void Construct(Jumper jumper, KeyInput keyInput)
// 	{
// 		var spaceKeyInputStub = new KeyInputStub(KeyCode.Space);
// 		Debug.Log("Test construct called.");
// 		base.Construct(jumper, spaceKeyInputStub);
// 	}
// }
