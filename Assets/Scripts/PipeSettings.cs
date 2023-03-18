using System;
using UnityEngine;

[Serializable]
public class PipeSettings
{
	public PipeSettings(GameObject pipe, float pipeDeadZoneX, float moveSpeed)
	{
		PipePrefab = pipe;
		PipeDeadZoneX = pipeDeadZoneX;
		MoveSpeed = moveSpeed;
	}
	public GameObject PipePrefab;
	public float PipeDeadZoneX = -23;
	public float MoveSpeed = -23;
}
