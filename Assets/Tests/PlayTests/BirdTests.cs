using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using FlappyBird;
using Zenject;
using FlappyBird.Events;

public class BirdTests : ZenjectIntegrationTestFixture
{
	[UnityTest]
	public IEnumerator Should_Jump_WhenSpacebarKeyDown()
	{
		//Arrange
		PreInstall();
		const int BirdUpVelocityUnitsPerSecond = 10;
		const int HeightTolerance = 3;
		Container.Install<CoreInstaller>();

		var pipePrefab = PipePrefab.Create();
		var pipeSettings = new PipeSettings(pipePrefab, -23f, 5);
		var pipeSpawnerSettings = new PipeSpawnerSettings();
		Container.Bind<PipeSettings>().FromInstance(pipeSettings).AsSingle();
		Container.Bind<PipeSpawnerSettings>().FromInstance(pipeSpawnerSettings).AsSingle();
		PipeInstaller.Install(Container, pipeSettings, pipeSpawnerSettings);

		BirdInstaller.Install(Container, new BirdSettings(BirdUpVelocityUnitsPerSecond));

		var spaceKeyInputStub = new KeyInputStub(KeyCode.Space);
		Container.Rebind<KeyInput>().FromInstance(spaceKeyInputStub);//For non-interface types, rebind cannot be AsSingle.
		
		Container.Bind<BirdBehaviour>().FromNewComponentOnNewGameObject()
			.AsSingle();
		PostInstall();
		
		var birdBehaviour = Container.Resolve<BirdBehaviour>();
		//Act
		yield return new WaitForSeconds(1.1f);//Let it move up around 10 units in 1 second.
		//Assert
		Assert.IsTrue(birdBehaviour.gameObject.transform.position.y > BirdUpVelocityUnitsPerSecond - HeightTolerance);
	}

	[Test]
	public void Should_FireBirdHitThePipeSignal_WhenCollided()
	{
		var eventBusSpy = new EventBusSpy<BirdHitThePipeUISignal>();

		PreInstall();

		Container.Install<CoreInstaller>();

		var pipePrefab = PipePrefab.Create();
		var pipeSettings = new PipeSettings(pipePrefab, -23f, 5);
		var pipeSpawnerSettings = new PipeSpawnerSettings();
		Container.Bind<PipeSettings>().FromInstance(pipeSettings).AsSingle();
		Container.Bind<PipeSpawnerSettings>().FromInstance(pipeSpawnerSettings).AsSingle();
		PipeInstaller.Install(Container, pipeSettings, pipeSpawnerSettings);

		BirdInstaller.Install(Container, new BirdSettings(default));

		Container.Rebind<IEventBus>().FromInstance(eventBusSpy).AsSingle();

		Container.Bind<BirdBehaviour>().FromNewComponentOnNewGameObject()
			.AsSingle();

		PostInstall();

		var birdBehaviour = Container.Resolve<BirdBehaviour>();
		var birdBehaviourWrapper = new MonoReflector<BirdBehaviour>(birdBehaviour);
		
		birdBehaviourWrapper.OnCollisionEnter2D(null);
		
		Debug.Log($"Fired:{eventBusSpy.IsExpectedEventFired()}");
	}

	[Test, Ignore("Cannot simulate collision")]
	public void Should_FireWhenCollided_Ignored()
	{
		//SceneManager.LoadScene("MainScene");
		//Arrange
		var container = new DiContainer(StaticContext.Container);
		container.Install<CoreInstaller>();
		BirdInstaller.Install(container, new BirdSettings(default));

		var gameObject = new GameObject();
		var bird = gameObject.AddComponent<BirdBehaviour>();
		gameObject.AddComponent<CircleCollider2D>();

		var pipePrefab = PipePrefab.Create();

		//Note:Alternative to the EventBusSpy, this can be used.
		//var eventBus = container.Resolve<IEventBus>();
		//eventBus.Subscribe<BirdHitThePipeSignal>(OnBirdHitThePipe);
		var eventBusSpy = new EventBusSpy<BirdHitThePipeUISignal>();
		bird.Construct(eventBusSpy, container.Resolve<JumperFactory>());
		//Act
		gameObject.transform.position = pipePrefab.transform.position;
		Debug.Log($"Fired:{eventBusSpy.IsExpectedEventFired()}");
		Debug.Log($"{gameObject.transform.position} - {pipePrefab.transform.position}");

		//yield return new WaitForFixedUpdate();
		CleanUp(gameObject);
		//Assert
		//Debug.Log($"Fired:{eventBusSpy.ShouldFireExpectedEvent()}");
		Assert.IsTrue(eventBusSpy.IsExpectedEventFired());
	}

	private static void CleanUp(GameObject gameObject)
	{
		GameObject.Destroy(gameObject);
	}

	//[UnityTest]
	[Test, Ignore("Just for demo.")]
	public IEnumerator Test_ShowcaseForDifferentReturnTypes()
	{
		PreInstall();
		yield return new EnterPlayMode();
		yield return new WaitForSeconds(5);
		yield return new ExitPlayMode();
		PostInstall();
	}

	// [UnityTest] //PreInstall/PostInstall not called test failure error.
	// public IEnumerator Should_Jump_WhenSpacebarKeyDown2()
	// {
	// 	//Arrange
	// 	const int BirdUpVelocity = 10;
	// 	const int HeightTolerance = 2;
	// 	var container = new DiContainer(StaticContext.Container);
	// 	container.Install<CoreInstaller>();
	// 	BirdInstaller.Install(container, new BirdSettings(BirdUpVelocity));

	// 	var spaceKeyInputStub = new KeyInputStub(KeyCode.Space);

	// 	var gameObject = new GameObject();
	// 	var bird = gameObject.AddComponent<BirdBehaviour>();
	// 	bird.Construct(container.Resolve<IEventBus>(), new JumperFactory(spaceKeyInputStub, container.Resolve<Jumper>()));
	// 	//Act
	// 	yield return new WaitForSeconds(1);//Let it move up around 10 units in 1 second
	// 	CleanUp(gameObject);
	// 	//Assert
	// 	Assert.IsTrue(gameObject.transform.position.y > BirdUpVelocity - HeightTolerance);
	// }
}