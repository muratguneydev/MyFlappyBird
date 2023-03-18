using FlappyBird.Events;
using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class PipeBehaviour : MonoBehaviour
	{
		[SerializeField] private float moveSpeed;
		private LeftMover _leftMover;
		private IEventBus _eventBus;

		[Inject]
        public void Construct(IEventBus eventBus, LeftMover leftMover)
        {
            _eventBus = eventBus;
			_leftMover = leftMover;
        }

		// // Start is called before the first frame update
		// void Start()
		// {
		// 	_leftMover = new LeftMover(moveSpeed);
		// }

		// Update is called once per frame
		void Update()
		{
			MoveLeft();
		}

		private void MoveLeft()
		{
			Debug.Log("0");
			Debug.Log($"Pipe pos:{transform.position}");
			transform.position = _leftMover.Move(transform.position, Time.deltaTime);
			Debug.Log($"Pipe pos:{transform.position}");
			Debug.Log("1");
			//Debug.Log($"Event Bus in Pipe:{_eventBus}");
			_eventBus.Fire(new ObjectMovedSignal(gameObject));
			//Debug.Log("2");
		}

		public class Factory : PlaceholderFactory<PipeBehaviour>
        {
        }
	}
}
