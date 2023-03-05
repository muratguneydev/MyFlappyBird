using FlappyBird.Events;
using UnityEngine;

namespace FlappyBird
{
	public class Destroyer
	{
		private readonly float _deadZoneX;
		private readonly IEventBus _eventBus;
		private readonly ObjectDestroyer _objectDestroyer;

		public Destroyer(float deadZoneX, IEventBus eventBus, ObjectDestroyer objectDestroyer)
		{
			_deadZoneX = deadZoneX;
			_eventBus = eventBus;
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

	public class ObjectDestroyer
	{
		public virtual void Destroy(GameObject gameObject)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
