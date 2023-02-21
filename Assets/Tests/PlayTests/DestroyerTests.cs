using FlappyBird;
using NUnit.Framework;
using UnityEngine;

public class DestroyerTests
{
	[Test]
	public void ShouldDestroyIfInDeadZone()
	{
		// Create a new root game object.
		var root = new GameObject();
		root = GameObject.Instantiate(root, new Vector3(-40, 0, 0), Quaternion.identity);
		var destroyer = new Destroyer(root, -20);
		destroyer.DestroyIfInDeadZone();
		Assert.IsFalse(root.activeInHierarchy);
	}

	[Test]
	public void ShouldNotDestroyIfOutsideOfDeadZone()
	{
		// Create a new root game object.
		var root = new GameObject();
		root = GameObject.Instantiate(root, new Vector3(-10, 0, 0), Quaternion.identity);
		var destroyer = new Destroyer(root, -20);
		destroyer.DestroyIfInDeadZone();
		Assert.IsTrue(root.activeInHierarchy);
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
