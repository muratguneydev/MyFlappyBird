using System.Collections.Generic;
using System.Linq;
using FlappyBird;
using NUnit.Framework;
using UnityEngine;

//https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/reference-attribute-unitytest.html
public class PipeSpawnerTests
{
    [Test]
    public void ShouldSpawn()
	{
		var pipesToUse = new List<SpawnedTestPipe> { new SpawnedTestPipe(5f), new SpawnedTestPipe(7f), new SpawnedTestPipe(19f) };
		var pipeSpawner = GetPipeSpawner(pipesToUse);

		foreach (var testPipe in pipesToUse)
		{
			pipeSpawner.Invoke();
			testPipe.AssertYPosition();
		}
	}

	private static PipeSpawner GetPipeSpawner(IReadOnlyList<SpawnedTestPipe> pipesToUse)
	{
		var pipeFactory = new PipeFactoryStub(pipesToUse.Select(pipesToUse => pipesToUse.Pipe).ToArray());
		var pipeSpawnerSettings = new PipeSpawnerSettings();
		var yPositionRandomizer = new YPositionRandomizerFake(pipesToUse.Select(pipesToUse => pipesToUse.ExpectedYPosition).ToArray());
		return new PipeSpawner(pipeFactory, pipeSpawnerSettings, yPositionRandomizer);
	}

	private class SpawnedTestPipe
	{
		public SpawnedTestPipe(float expectedYPosition)
		{
			ExpectedYPosition = expectedYPosition;

			var gameObject = new GameObject();
			Pipe = gameObject.AddComponent<TestPipe>();
		}

		public float ExpectedYPosition { get; }
		public TestPipe Pipe { get; }

		public void AssertYPosition()
		{
			Assert.AreEqual(ExpectedYPosition, Pipe.transform.position.y);
		}
	}

	// // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
	// // `yield return null;` to skip a frame.
	// [UnityTest]
	// public IEnumerator SpawnerTestsWithEnumeratorPasses()
	// {
	//     // Use the Assert class to test conditions.
	//     // Use yield to skip a frame.
	//     yield return null;
	// }

	// [UnityTest]//, Category(TestCategoryConstants.Controllers.HydraulicLiftController)]
	// public IEnumerator EnsurePlayerIsCrushedByHorizontalExtension()
	// {
	// 	GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
	// 	//var game = gameGameObject.GetComponent<Game>();


	// 	yield return null;

	// 	// SceneManager.LoadScene("SampleScene");
	// 	// yield return null;

	// 	// var sceneCtrl = GameObject.FindObjectOfType<Pipe>();

	// 	// GlobalStateDirector.Instance.SetTimeScale(3);

	// 	// //Move the player over the simple lift.
	// 	// SubscriptionDirector.Instance.Publish(Code.Common.Enums.SubscriptionType.RepositionPlayer, new RepositionPlayerSubscriptionPayload()
	// 	// {
	// 	// 	Position = sceneCtrl.SimpleHorizontalLift.StaticFloorCollider.transform.position + 2 * sceneCtrl.SimpleHorizontalLift.transform.up
	// 	// });

	// 	// //Wait for the player to land in place.
	// 	// yield return new WaitForSecondsRealtime(1);

	// 	// Assert.False(PlayerIsDead());

	// 	// //Move the lift up, and make sure the player goes up.
	// 	// sceneCtrl.SimpleHorizontalLift.SetPlatformExtensionLength(5f);
	// 	// yield return new WaitUntilLimit(3, () => PlayerIsDead());
	// 	// Assert.True(PlayerIsDead());

	// }

}
