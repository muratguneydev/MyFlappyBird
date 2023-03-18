using UnityEngine;

namespace FlappyBird
{
	public class ObjectDestroyer
	{
		public virtual void Destroy(GameObject gameObject)
		{
			gameObject.SetActive(false);
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
