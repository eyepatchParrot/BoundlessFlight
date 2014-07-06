function origWork::create(%this)
{
	exec("./gui/guiProfiles.cs");
	exec("./scripts/scenewindow.cs");
	exec("./scripts/scene.cs");
	exec("./scripts/game.cs");
	exec("./scripts/player.cs");
	
	createSceneWindow();
	createScene();
	mySceneWindow.setScene(myScene);
	myScene.setDebugOn("collision", "position", "aabb");
	createGame();
}

function origWork::destroy(%this)
{
	destroySceneWindow();
}