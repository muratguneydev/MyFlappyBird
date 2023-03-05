using FlappyBird.Events;
using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class Pipe : MonoBehaviour
	{
		//private const float DeadZoneX = -23;

		[SerializeField] private float moveSpeed;
		private LeftMover _leftMover;
		private Destroyer _destroyer;
		private SignalBus _signalBus;

		// Start is called before the first frame update
		void Start()
		{
			_leftMover = new LeftMover(moveSpeed);
			//_destroyer = new Destroyer(gameObject, DeadZoneX);
		}

		[Inject]
        public void Construct(SignalBus signalBus)
        {
			Debug.Log("Constructed PipeMiddle.");
            _signalBus = signalBus;
        }

		// Update is called once per frame
		void Update()
		{
			MoveLeft();

			//_destroyer.DestroyIfInDeadZone();
		}

		private void MoveLeft()
		{
			transform.position = _leftMover.Move(transform.position, Time.deltaTime);
			_signalBus.Fire(new ObjectMovedSignal(gameObject));
		}

		public class Factory : PlaceholderFactory<Pipe>
        {
        }
	}
}
