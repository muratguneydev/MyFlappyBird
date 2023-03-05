using System;
using FlappyBird.Events;
using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class Destroyer //: IInitializable, IDisposable
	{
		private readonly float _deadZoneX;
		private readonly SignalBus _signalBus;

		public Destroyer(float deadZoneX, SignalBus signalBus)
		{
			_deadZoneX = deadZoneX;
			_signalBus = signalBus;
		}

		// public void Dispose()
		// {
		// 	_signalBus.Unsubscribe<ObjectMovedSignal>(OnObjectMoved);
		// }

		// public void Initialize()
		// {
		// 	_signalBus.Subscribe<ObjectMovedSignal>(OnObjectMoved);
		// }

		public void OnObjectMoved(ObjectMovedSignal objectMovedSignal)
		{
			DestroyIfInDeadZone(objectMovedSignal.GameObject);
		}

		private void DestroyIfInDeadZone(GameObject gameObject)
		{
			if (gameObject.transform.position.x > _deadZoneX)
				return;

			gameObject.SetActive(false);
			UnityEngine.Object.Destroy(gameObject);
			Debug.Log("Destroyed.");
		}
	}
}
