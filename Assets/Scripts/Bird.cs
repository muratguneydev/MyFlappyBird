using SimpleDependencyInjection;
using UnityEngine;

namespace FlappyBird
{
	public class Bird : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D myRigidBody;
		[InjectField] private Jumper _jumper;

		// private void Awake()
		// {
		// 	Debug.Log("Bird awake...");

		// }

		// Start is called before the first frame update
		void Start()
		{
			//_jumper = new Jumper();
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
				_jumper.Move(myRigidBody);
		}
	}
}
