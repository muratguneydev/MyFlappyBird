using System;

namespace FlappyBird
{
	[Serializable]
	public class PipeSpawnerSettings
	{
		public float HeightOffset = 13;
		public float SpawnFrequencySeconds = 4;
		public float StartPositionX = 11.14f;
		public float StartPositionY;
	}
}
