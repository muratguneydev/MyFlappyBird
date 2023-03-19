using UnityEngine;

namespace FlappyBird
{
	public class JumperFactory
	{
		private readonly KeyInput _keyInput;
		private readonly Jumper _jumper;
		private readonly Jumper _noOpJumer;

		public JumperFactory(KeyInput keyInput, Jumper jumper, Jumper noOpJumper)
		{
			_keyInput = keyInput;
			_jumper = jumper;
			_noOpJumer = noOpJumper;
		}

		public Jumper Get(bool isGameOver)
		{
			return !isGameOver && _keyInput.GetKeyDown(KeyCode.Space) ? _jumper : _noOpJumer;
		}
	}
}
