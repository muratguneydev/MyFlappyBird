using UnityEngine;

namespace FlappyBird
{
	public class KeyInput
	{
		public virtual bool GetKeyDown(KeyCode keyCode)
		{
			return Input.GetKeyDown(keyCode);
		}
	}
}
