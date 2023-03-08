using UnityEngine;

namespace FlappyBird
{
	public class DeltaTime
	{
		public virtual float GetSeconds()
		{
			return Time.deltaTime;
		}
	}
}
