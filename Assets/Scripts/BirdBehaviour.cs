using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class BirdBehaviour : MonoBehaviour
	{
		private Jumper _jumper;
		private Rigidbody2D _rigidBody;
		private KeyInput _keyInput;

		[Inject]
        public void Construct(Jumper jumper, KeyInput keyInput)
        {
			Debug.Log("Constructed Bird.");

            _jumper = jumper;
			_rigidBody = GetComponent<Rigidbody2D>();
			_keyInput = keyInput;
        }

		void Update()
		{
			if (_keyInput.GetKeyDown(KeyCode.Space))
				_jumper.Move(_rigidBody);
		}
	}
}
