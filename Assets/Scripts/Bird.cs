using UnityEngine;

namespace FlappyBird
{
	public class Bird : MonoBehaviour
	{
		public Rigidbody2D myRigidBody;
		// Start is called before the first frame update
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
				myRigidBody.velocity = Vector2.up * 10;
		}
	}
}