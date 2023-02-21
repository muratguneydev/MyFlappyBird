using UnityEngine;

namespace FlappyBird
{
	public class PipeMove : MonoBehaviour
	{
		[SerializeField] private float moveSpeed;
		private const float DeadZoneX = -23;

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
			new Destroyer(gameObject, DeadZoneX).DestroyIfInDeadZone();
		}
	}
}
