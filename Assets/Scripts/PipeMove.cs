using UnityEngine;

namespace FlappyBird
{
	public class PipeMove : MonoBehaviour
	{
		public float moveSpeed;

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
		}
	}
}