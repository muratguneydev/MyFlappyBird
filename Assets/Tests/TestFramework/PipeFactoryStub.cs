using FlappyBird;

public class PipeFactoryStub : PipeBehaviour.Factory
{
	private readonly PipeBehaviour[] _pipesToReturn;
	private int _currentPipeIndex;
	public PipeFactoryStub(PipeBehaviour[] pipesToReturn)
	{
		_pipesToReturn = pipesToReturn;
	}
	public override PipeBehaviour Create()
	{
		return _pipesToReturn[_currentPipeIndex++];
	}

	// private static GameObject GetPipePrefab()
	// {
	// 	return AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Pipe.prefab");
	// 	//var prefabInstance = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
	// }
}
