using System;
using FlappyBird;
using FlappyBird.Events;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using Zenject;

public class DestroyerTests
{
	//https://github.com/modesttree/Zenject/blob/master/Documentation/WritingAutomatedTests.md
	[TestCase(-23f, -40f, true, "Game object should be destroyed.")]
	[TestCase(-23f, -10f, false, "Game object should not be destroyed.")]
	public void ShouldDestroyIfInDeadZone(float deadZoneX, float objectCurrentX, bool shouldBeDestroyed, string failureMessage)
	{
		var pipePrefab = GetPipePrefab();
		var container = new DiContainer(StaticContext.Container);
		container.Install<CoreInstaller>();
		PipeInstaller.Install(container, pipePrefab, deadZoneX);


		var eventBus = container.Resolve<IEventBus>();
		Assert.That(eventBus is not null);

		var unsubscribeDestroyer = SubscribeDestroyerAsOriginalRegistrationDoesntWorkInTestMode(container);

		var objectToBeDestroyed = new GameObject();
		objectToBeDestroyed = GameObject.Instantiate(objectToBeDestroyed, new Vector3(objectCurrentX, 0, 0), Quaternion.identity);
		eventBus.Fire(new ObjectMovedSignal(objectToBeDestroyed));

		unsubscribeDestroyer();
		//Assert.IsFalse(objectToBeDestroyed.activeInHierarchy, "Game object wasn't destroyed.");
		Assert.AreEqual(shouldBeDestroyed, !objectToBeDestroyed.activeInHierarchy, failureMessage);
	}

	private static GameObject GetPipePrefab()
	{
		return AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Pipe.prefab");
		//var prefabInstance = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
	}

	private static Action SubscribeDestroyerAsOriginalRegistrationDoesntWorkInTestMode(DiContainer container)
	{
		var destroyer = container.Resolve<Destroyer>();
		Assert.That(destroyer is not null);
		var eventBus = container.Resolve<IEventBus>();
		eventBus.Subscribe<ObjectMovedSignal>(destroyer.OnObjectMoved);

		return () => eventBus.Unsubscribe<ObjectMovedSignal>(destroyer.OnObjectMoved);
	}


	// [UnityTest]
	// [Timeout(180000)] // Sets the timeout of the test in milliseconds (if the test hangs, this will ensure it closes after 3 minutes).
	// public IEnumerator TestAnimationAnimUtilityPrefab()
	// {
	//     // Remove the default skybox.
	//     RenderSettings.skybox = null;
	//     // Create a new root game object.
	//     var root = new GameObject();
	//     // Attach a camera to our root game object.
	//     root.AddComponent(typeof(Camera));
	//     // Get a reference to the camera.
	//     var camera = root.GetComponent<Camera>();
	//     // Set the camera's background color to white.
	//     camera.backgroundColor = Colors.white;
	//     // Add our game object (with the camera included) to the scene by instantiating it.
	//     root = GameObject.Instantiate(root);
	//     // Load a prefab (by giving it the path to an existing prefab).
	//     var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Example.prefab");
	//     // Instantiate the prefab (by adding it to the scene). Use the Quaternion to set the rotation in degrees and the Vector3 to set the position in 3D space.
	//     prefab = GameObject.Instantiate(prefab, new Vector3(0, 0, 10), new Quaternion(0, 180, 0, 0));
	//     // Wait for three seconds (this gives us time to see the prefab in the scene if its an animation or something else).
	//     yield return new WaitForSeconds(3f);
	//     // In this example, let's assume that our Example.prefab has a script on it called ExampleScript.
	//     var script = prefab.gameObject.GetComponentInChildren<ExampleScript>();
	//     // Assert that the script exists on our prefab so we don't stumble upon this problem in the future.
	//     Assert.IsTrue(script != null, "ExampleScript must be set on Example.prefab.");
	//     // Finally, we should clean up our scene by destroying our objects.
	//     GameObject.Destroy(prefab);
	//     GameObject.Destroy(root);
	// }
}
