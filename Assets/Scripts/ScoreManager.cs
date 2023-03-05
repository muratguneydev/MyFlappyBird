using System;
using FlappyBird.Events;
using UnityEngine;

namespace FlappyBird
{
	public class ScoreManager
	{
		private int _scorePoints;
		public event Action<int>  OnChange;

		public void Increment(GoneThroughPipesSignal signal)
		{
			_scorePoints++;
			Debug.Log($"score:{_scorePoints}");
			if (OnChange is null)
				return;
			OnChange(_scorePoints);
		}
	}
}