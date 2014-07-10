if ( !isObject(ParallaxBehavior) )
{
	%template = new BehaviorTemplate(ParallaxBehavior);
	
	%template.friendlyName = "Parallax Behavior";
	%template.behaviorType = "Graphics";
	%template.description = "Scrolls until unseen the resets to the top of the screen.";
	
	%template.addBehaviorField(worldSizeField, "The size of the world", string, "100 75");
	%template.addBehaviorField( spd, "How fast to parallax", float, -10.0 );
}

function ParallaxBehavior::onBehaviorAdd(%this)
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
	
	%this.owner.setLinearVelocityY( %this.spd );
}

function ParallaxBehavior::onCollision( %this, %obj, %collisionDetails )
{
	%this.reset();
}

function ParallaxBehavior::reset( %this )
{
	%this.owner.setPositionY( getWord( %this.worldSizeField, 1 ) );
	%this.owner.setLinearVelocityY( %this.spd );
}
	
function ParallaxBehavior::onBehaviorRemove(%this)
{
	// Insert deletion behavior here.
}