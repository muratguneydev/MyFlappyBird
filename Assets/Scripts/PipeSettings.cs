using System;
using UnityEngine;

[Serializable]
public class PipeSettings
{
	public PipeSettings(GameObject pipe, float pipeDeadZoneX)
	{
		PipePrefab = pipe;
		PipeDeadZoneX = pipeDeadZoneX;
	}
	public GameObject PipePrefab;
	public float PipeDeadZoneX = -23;
}
