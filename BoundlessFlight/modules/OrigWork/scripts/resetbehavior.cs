if ( !isObject(ResetBehavior) )
{
	%template = new BehaviorTemplate(ResetBehavior);
	
	%template.friendlyName = "Reset Behavior";
	%template.behaviorType = "Graphics";
	%template.description = "When a background goes below the screen reset it above the screen.";
	
	%template.addBehaviorField(worldSizeField, "The size of the world", string, "100 75");
}

function ResetBehavior::onBehaviorAdd(%this)
{
	// Insert instantiation behavior here.
	%worldWidth = getWord( %this.worldSizeField, 0 );
	%worldHeight = getWord( %this.worldSizeField, 1 );
	%boundHeight = 10.0;
	%size = %worldWidth SPC %boundHeight;
	%position = "0" SPC -(((%worldHeight + %boundHeight) / 2.0) + %worldHeight);
	
	%bound = new SceneObject();
	%bound.setSize( %size );
	%bound.setPosition( %position );
	%bound.createPolygonBoxCollisionShape( %size );
	%bound.setCollisionGroups( none );
	%bound.setSceneGroup( $Game::ParallaxBoundaryGroup );
	%bound.setBodyType( static );
	myScene.add(%bound);
	
	%this.owner.createPolygonBoxCollisionShape( %this.owner.getSize() );
	%this.owner.setCollisionCallback( true );
	%this.owner.setCollisionGroups( $Game::ParallaxBoundaryGroup );
	//%this.owner.setBodyType( static );
}

function ResetBehavior::onCollision( %this, %obj, %collisionDetails )
{
	%velY = %this.owner.getLinearVelocityY();
	%this.owner.setPositionY( getWord( %this.worldSizeField, 1 ) );
	%this.owner.setLinearVelocityY( %velY );
}

function ResetBehavior::onBehaviorRemove(%this)
{
	// Insert deletion behavior here.
}