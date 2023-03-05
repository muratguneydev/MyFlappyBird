using UnityEngine;

namespace FlappyBird.Events
{
	public class ObjectMovedSignal
	{
		public ObjectMovedSignal(GameObject gameObject)
		{
			GameObject = gameObject;
		}

		public GameObject GameObject { get; }
	}
}