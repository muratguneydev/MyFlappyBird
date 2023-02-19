using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using FlappyBird;

public class BirdTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void BirdTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BirdTestsWithEnumeratorPasses()
    {
        //var gameObject = new GameObject();
		//var bird = gameObject.AddComponent<Bird>();

		yield return null;
    }
}
