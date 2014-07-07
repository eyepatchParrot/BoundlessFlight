function origWork::create(%this)
{
	exec("./gui/guiProfiles.cs");
	exec("./scripts/scenewindow.cs");
	exec("./scripts/scene.cs");
	exec("./scripts/game.cs");
	exec("./scripts/player.cs");
	exec("./scripts/controls.cs");
	exec("./scripts/followmousebehavior.cs");
	exec("./scripts/shootbehavior.cs");
	
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