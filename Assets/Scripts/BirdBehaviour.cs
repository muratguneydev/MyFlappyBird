using UnityEngine;
using Zenject;

namespace FlappyBird
{
	[RequireComponent(typeof(Rigidbody))]
	public class BirdBehaviour : MonoBehaviour
	{
		private Jumper _jumper;
		private Rigidbody2D _rigidBody;
		private KeyInput _keyInput;

		[Inject]
        public virtual void Construct(Jumper jumper, KeyInput keyInput)
        {
            _jumper = jumper;
			_rigidBody = GetComponent<Rigidbody2D>();
			_keyInput = keyInput;
			Debug.Log(keyInput);
        }

		void Update()
		{
			if (_keyInput.GetKeyDown(KeyCode.Space))
				_jumper.Move(_rigidBody);
		}
	}
}
