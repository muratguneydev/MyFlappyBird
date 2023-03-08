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

		public virtual float Get(float currentY)
		{
			var lowestPoint = currentY - _offset;
			var highestPoint = currentY + _offset;
			var randomY = Random.Range(lowestPoint, highestPoint);
			return randomY;
		}
	}
}
