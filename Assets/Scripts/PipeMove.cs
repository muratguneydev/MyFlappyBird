using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class PipeMove : MonoBehaviour
	{
		private const float DeadZoneX = -23;

		[SerializeField] private float moveSpeed;
		private LeftMover _leftMover;
		private Destroyer _destroyer;

		// Start is called before the first frame update
		void Start()
		{
			_leftMover = new LeftMover(moveSpeed);
			_destroyer = new Destroyer(gameObject, DeadZoneX);
		}

		// Update is called once per frame
		void Update()
		{
			MoveLeft();
			_destroyer.DestroyIfInDeadZone();
		}

		private void MoveLeft()
		{
			transform.position = _leftMover.Move(transform.position, Time.deltaTime);
		}

		public class Factory : PlaceholderFactory<PipeMove>
        {
        }
	}
}
