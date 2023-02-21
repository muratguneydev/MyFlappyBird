using UnityEngine;

namespace FlappyBird
{
	public class Destroyer
	{
		private readonly GameObject _gameObject;
		private readonly float _deadZoneX;

		public Destroyer(GameObject gameObject, float deadZoneX)
		{
			this._gameObject = gameObject;
			this._deadZoneX = deadZoneX;
		}

		public void DestroyIfInDeadZone()
		{
			if (_gameObject.transform.position.x < _deadZoneX)
			{
				_gameObject.SetActive(false);
				Object.Destroy(_gameObject);
				Debug.Log("Destroyed.");
			}
		}
	}
}
