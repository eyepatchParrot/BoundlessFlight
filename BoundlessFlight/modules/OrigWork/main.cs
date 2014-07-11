$Game::PlayerGroup = 1;
$Game::ParallaxBoundaryGroup = 2;
$Game::EnemyGroup = 3;
$Game::BulletGroup = 4;

$Game::DeathStory = 1;

function origWork::create(%this)
{
	exec("./gui/guiProfiles.cs");
	exec( "./scripts/console.cs" );
	exec("./scripts/scenewindow.cs");
	exec("./scripts/scene.cs");
	exec("./scripts/background.cs");
	exec("./scripts/player.cs");
	exec("./scripts/controls.cs");
	exec("./scripts/followmousebehavior.cs");
	exec("./scripts/shootbehavior.cs");
	exec("./scripts/parallaxbehavior.cs");
	exec("./scripts/spawner.cs");
	exec("./scripts/enemy.cs");
	
	%this.add( TamlRead( "./gui/ConsoleDialog.gui.taml" ) );
	%this.add( TamlRead( "./gui/StoryScreen.gui.taml" ) );
	
	GlobalActionMap.bind( keyboard, "ctrl tilde", toggleConsole );

	%this.dieStory = "origWork:die1 origWork:die2";
	
	%this.createGame();
}

function origWork::createGame( %this )
{
	createSceneWindow();
	createScene();
	mySceneWindow.setScene( myScene );
	myScene.setDebugOn( "collision", "position", "aabb" );
	createPlayer();
	createBackground();
	createSpawner();
	
	new ScriptObject(InputManager);
	mySceneWindow.addInputListener(InputManager);
}

function origWork::destroyGame( %this )
{
	InputManager.delete();
	destroyScene();
	destroySceneWindow();
}

function origWork::initDie( %this )
{
	%this.destroyGame();
	
	%this.story = %this.dieStory;
	%this.storyIdx = -1;
	%this.nextStory();
	
	Canvas.setContent( StoryScreen );
}

function origWork::nextStory( %this )
{
	%this.storyIdx++;
	echo( %this.storyIdx SPC getWordCount( %this.story ) );
	if (%this.storyIdx < getWordCount( %this.story ) )
	{
		%img = getWord( %this.story, %this.storyIdx );
		StoryButton.setHoverImage( %img );
		StoryButton.setNormalImage( %img );
	}
	else
	{
		switch$ (%this.story)
		{
			case %this.dieStory:
				%this.createGame();
		}
	}
}

function origWork::destroy(%this)
{
	InputManager.delete();
	destroySceneWindow();
}