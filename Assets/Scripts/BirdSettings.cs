using System;

[Serializable]
public class BirdSettings
{
	public BirdSettings(int jumpUpVelocity)
	{
		JumpUpVelocity = jumpUpVelocity;
	}

	public int JumpUpVelocity = 10;
}
