using FlappyBird.Events;
using Zenject;


namespace FlappyBird
{
	public class GameInitializer : IInitializable
	{
		//readonly SignalBus _signalBus;

		public GameInitializer()//SignalBus signalBus)
		{
			//_signalBus = signalBus;
		}

		public void Initialize()
		{
			//_signalBus.Fire(new GoneThroughPipesSignal());
		}
	}
}
