using UnityEngine;

namespace FlappyBird
{
	public class Bird : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D myRigidBody;
		private Jumper _jumper;

		// Start is called before the first frame update
		void Start()
		{
			_jumper = new Jumper(myRigidBody);
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
				_jumper.Move();
		}
	}
}
