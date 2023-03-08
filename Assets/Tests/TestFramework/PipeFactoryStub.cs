using FlappyBird;

public class PipeFactoryStub : Pipe.Factory
{
	public override Pipe Create()
	{
		return new TestPipe();
		//base.Create();
	}

	// private static GameObject GetPipePrefab()
	// {
	// 	return AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Pipe.prefab");
	// 	//var prefabInstance = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
	// }
}
