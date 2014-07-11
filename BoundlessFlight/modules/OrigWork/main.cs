$Game::PlayerGroup = 1;
$Game::ParallaxBoundaryGroup = 2;
$Game::EnemyGroup = 3;
$Game::BulletGroup = 4;

function origWork::create(%this)
{
	exec("./gui/guiProfiles.cs");
	exec("./scripts/scenewindow.cs");
	exec("./scripts/scene.cs");
	exec("./scripts/game.cs");
	exec("./scripts/background.cs");
	exec("./scripts/player.cs");
	exec("./scripts/controls.cs");
	exec("./scripts/followmousebehavior.cs");
	exec("./scripts/shootbehavior.cs");
	exec("./scripts/parallaxbehavior.cs");
	exec("./scripts/spawner.cs");
	exec("./scripts/enemy.cs");
	
	createSceneWindow();
	createScene();
	mySceneWindow.setScene(myScene);
	myScene.setDebugOn("collision", "position", "aabb");
	createGame();
	new ScriptObject(InputManager);
	mySceneWindow.addInputListener(InputManager);
}

function origWork::destroy(%this)
{
	InputManager.delete();
	destroySceneWindow();
}