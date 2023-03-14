using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using FlappyBird;
using Zenject;

public class BirdTests
{
	// [OneTimeSetUp]
	// public void LoadScene()
	// {
	// 	//https://forum.unity.com/threads/play-mode-tests-scenehandling.751049/
	// 	SceneManager.LoadScene("MainScene");

	// }

	// A Test behaves as an ordinary method
	// [Test]
	// public void ShouldJumpWhenSpacebarKeyDown()
	// {
	//     // Use the Assert class to test conditions
	// }

	// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
	// `yield return null;` to skip a frame.
	[UnityTest]
	public IEnumerator ShouldJumpWhenSpacebarKeyDown()
	{
		//Arrange
		const int BirdUpVelocity = 10;
		const int HeightTolerance = 2;
		var container = new DiContainer(StaticContext.Container);
		container.Install<CoreInstaller>();
		BirdInstaller.Install(container, new BirdSettings(BirdUpVelocity));

		var spaceKeyInputStub = new KeyInputStub(KeyCode.Space);
		//container.Bind<KeyInput>().FromInstance(spaceKeyInputStub).AsSingle();

		var gameObject = new GameObject();
		var bird = gameObject.AddComponent<BirdBehaviour>();
		bird.Construct(container.Resolve<IEventBus>(), container.Resolve<Jumper>(), spaceKeyInputStub);
		//Act
		yield return new WaitForSeconds(1);//Let it move up around 10 units in 1 second
		//Assert
		CleanUp(gameObject);
		Assert.IsTrue(gameObject.transform.position.y > BirdUpVelocity - HeightTolerance);
	}

	private static void CleanUp(GameObject gameObject)
	{
		GameObject.Destroy(gameObject);
	}

	[UnityTest]
	public IEnumerator TestCommon()
	{
		yield return new EnterPlayMode();
		yield return new WaitForSeconds(5);
		yield return new ExitPlayMode();
	}

	// [UnityTest]
	// public IEnumerator MonoBehaviourTest_Works()
	// {
	// 	var testableBehaviour = new MonoBehaviourTest<BirdBehaviourTestable>();

	// 	yield return testableBehaviour;
	// }
}
