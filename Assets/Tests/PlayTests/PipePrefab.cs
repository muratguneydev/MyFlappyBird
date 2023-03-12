using UnityEditor;
using UnityEngine;

public static class PipePrefab
{
	public static GameObject Create()
	{
		//return UnityEditor.PrefabUtility.CreatePrefab("Assets/Prefabs/Pipe.prefab", )
		return AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Pipe.prefab");
		//var prefabInstance = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
	}
}