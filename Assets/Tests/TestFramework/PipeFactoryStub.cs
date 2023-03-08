using FlappyBird;

public class PipeFactoryStub : Pipe.Factory
{
	private readonly Pipe[] _pipesToReturn;
	private int _currentPipeIndex;
	public PipeFactoryStub(Pipe[] pipesToReturn)
	{
		_pipesToReturn = pipesToReturn;
	}
	public override Pipe Create()
	{
		return _pipesToReturn[_currentPipeIndex++];
	}

	// private static GameObject GetPipePrefab()
	// {
	// 	return AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Pipe.prefab");
	// 	//var prefabInstance = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
	// }
}
