using UnityEngine;

namespace FlappyBird
{
	public class ObjectDestroyer
	{
		public virtual void Destroy(GameObject gameObject)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
