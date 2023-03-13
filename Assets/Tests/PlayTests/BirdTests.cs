using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using FlappyBird;
using UnityEngine.SceneManagement;
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
		
		var container = new DiContainer(StaticContext.Container);
		container.Install<CoreInstaller>();
		BirdInstaller.Install(container, new BirdSettings(10));

		var spaceKeyInputStub = new KeyInputStub(KeyCode.Space);
		//container.Bind<KeyInput>().FromInstance(spaceKeyInputStub).AsSingle();

		var gameObject = new GameObject();
		var bird = gameObject.AddComponent<BirdBehaviour>();
		bird.Construct(container.Resolve<IEventBus>(), container.Resolve<Jumper>(), spaceKeyInputStub);
		//var objectCurrentY = 10f;
		//gameObject = GameObject.Instantiate(gameObject, new Vector3(0, objectCurrentY, 0), Quaternion.identity);

		yield return null;
		Debug.Log($"Bird Test new Y:{gameObject.transform.position.y}");
		yield return null;
		Debug.Log($"Bird Test new Y:{gameObject.transform.position.y}");
		yield return null;
		Debug.Log($"Bird Test new Y:{gameObject.transform.position.y}");
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