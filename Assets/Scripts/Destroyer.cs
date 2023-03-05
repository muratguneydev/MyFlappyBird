using FlappyBird.Events;
using UnityEngine;

namespace FlappyBird
{
	public class Destroyer
	{
		private readonly float _deadZoneX;
		private readonly ObjectDestroyer _objectDestroyer;

		public Destroyer(float deadZoneX, ObjectDestroyer objectDestroyer)
		{
			_deadZoneX = deadZoneX;
			_objectDestroyer = objectDestroyer;
		}

		public void OnObjectMoved(ObjectMovedSignal objectMovedSignal)
		{
			DestroyIfInDeadZone(objectMovedSignal.GameObject);
		}

		private void DestroyIfInDeadZone(GameObject gameObject)
		{
			if (gameObject.transform.position.x > _deadZoneX)
				return;

			gameObject.SetActive(false);
			_objectDestroyer.Destroy(gameObject);
			Debug.Log("Destroyed.");
		}
	}
}
