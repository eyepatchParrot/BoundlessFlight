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
	exec("./scripts/enemyaibehavior.cs");
	
	%this.add( TamlRead( "./gui/ConsoleDialog.gui.taml" ) );
	%this.add( TamlRead( "./gui/StoryScreen.gui.taml" ) );
	%this.add( TamlRead( "./gui/HudOverlay.gui.taml" ) );
	%this.add( TamlRead( "./gui/MainMenu.gui.taml" ) );
	
	GlobalActionMap.bind( keyboard, "ctrl tilde", toggleConsole );

	%this.dieStory = "origWork:die1 origWork:die2";
	%this.winStory = "origWork:win1";
	%this.failStory = "origWork:fail1";
	%this.introStory = "origWork:intro1";
	
	%this.bookIsOpen = true;
	
	%this.initMainMenu();
}

function origWork::initMainMenu( %this )
{
	Canvas.setContent( MainMenu );
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
	%this.time = 0;
	%this.bossTime = 1;
	%this.kills = 0;
	%this.timerSchedule = %this.schedule(1000, updateTimer);
	
	new ScriptObject(InputManager);
	mySceneWindow.addInputListener(InputManager);
}

function origWork::destroyGame( %this )
{
	InputManager.delete();
	destroyScene();
	destroySceneWindow();
	cancel( %this.timerSchedule );
	cancel( %this.endSchedule );
}

function origWork::initIntro( %this )
{
	if ( %this.bookIsOpen )
	{
		%this.initStory( %this.introStory );
	}
	else
	{
		%this.createGame();
	}
}

function origWork::initDie( %this )
{
	%this.initStory( %this.dieStory );
}

function origWork::initEnd( %this )
{
	if ( %this.kills > 0 )
	{
		%this.initStory( %this.failStory );
	}
	else
	{
		%this.initStory( %this.winStory );
	}
}

function origWork::initStory( %this, %story )
{
	%this.destroyGame();
	%this.story = %story;
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
		StoryButton.setDownImage( %img );
	}
	else
	{
		switch$ (%this.story)
		{
			case %this.introStory:
				%this.createGame();
			
			default:
				%this.initMainMenu();
		}
	}
}

function origWork::updateTimer( %this )
{
	%this.time++;
	%min = mFloor( %this.time / 60 );
	%sec = %this.time % 60;
	if (%sec < 10)
	{
		%sec = "0" @ %sec;
	}
	HudTimeText.setText(%min @ ":" @ %sec);
	%this.schedule(1000, updateTimer);
	
	if ( %this.time == %this.bossTime )
	{
		createBoss();
		%this.endSchedule = %this.schedule( 5000, initEnd );
	}
}

function origWork::toggleBook( %this )
{
	%this.bookIsOpen = !%this.bookIsOpen;
	if ( %this.bookIsOpen )
	{
		%img = "origWork:bookOpen";
	}
	else
	{
		%img = "origWork:bookClosed";
	}
	BookButton.setNormalImage( %img );
	BookButton.setHoverImage( %img );
	BookButton.setDownImage( %img );
}

function origWork::incKills( %this )
{
	%this.kills++;
	HudKillsText.setText( %this.kills );
}

function origWork::destroy(%this)
{
	InputManager.delete();
	destroySceneWindow();
}