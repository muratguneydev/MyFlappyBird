using UnityEngine;
using Zenject;

namespace FlappyBird
{
	public class Bird : MonoBehaviour
	{
		private Jumper _jumper;
		private Rigidbody2D _rigidBody;

		[Inject]
        public void Construct(Jumper jumper)
        {
			Debug.Log("Constructed Bird.");

            _jumper = jumper;
			_rigidBody = GetComponent<Rigidbody2D>();
        }

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
				_jumper.Move(_rigidBody);
		}
	}
}
