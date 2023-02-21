using UnityEngine;

namespace FlappyBird
{
	public class YPositionRandomizer
	{
		private readonly float _offset;

		public YPositionRandomizer(float offset)
		{
			_offset = offset;
		}

		public float Get(float currentY)
		{
			//Debug.Log($"Current Y:{currentY}");
			var lowestPoint = currentY - 3 - _offset;
			var highestPoint = currentY + 3 + _offset;
			var randomY = Random.Range(lowestPoint, highestPoint);
			return randomY;
		}
	}
}
