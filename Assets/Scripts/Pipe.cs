using FlappyBird.Events;
using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class Pipe : MonoBehaviour
	{
		[SerializeField] private float moveSpeed;
		private LeftMover _leftMover;
		private IEventBus _eventBus;

		[Inject]
        public void Construct(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

		// Start is called before the first frame update
		void Start()
		{
			_leftMover = new LeftMover(moveSpeed);
		}

		// Update is called once per frame
		void Update()
		{
			MoveLeft();
		}

		private void MoveLeft()
		{
			transform.position = _leftMover.Move(transform.position, Time.deltaTime);
			_eventBus.Fire(new ObjectMovedSignal(gameObject));
		}

		public class Factory : PlaceholderFactory<Pipe>
        {
        }
	}
}
