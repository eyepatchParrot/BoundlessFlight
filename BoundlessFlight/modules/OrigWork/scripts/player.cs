function createPlayer()
{
	%xSz = 6.5;
	%ySz = 5.0;
	%p = new Sprite(Player);
	%p.setBodyType( dynamic );
	%p.Position = "0 -30";
	%p.Size = %xSz SPC %ySz;
	%p.SceneLayer = $Game::PlayerGroup;
	%p.Image = "origWork:player";
	%p.createCircleCollisionShape( %xSz / 2.0 );
	%p.setCollisionGroups( $Game::EnemyGroup );
	%p.setCollisionCallback( true );
	
	// Behaviors
	%c = FollowMouseBehavior.createInstance();
	%c.speedField = 30.0;
	%c.freqField = 200.0;
	%p.addBehavior(%c);
	
	%b = ShootBehavior.createInstance();
	%p.addBehavior(%b);
	// End Behaviors
	
	myScene.add( %p );
}

function Player::onCollision( %this, %sceneObj, %collisionDetails )
{
	echo( "this" SPC %this.class SPC "scene" SPC %sceneObj.class );
	
	%explosion = new ParticlePlayer();
	%explosion.Particle = "ToyAssets:impactExplosion";
	%explosion.setPosition( %this.getPosition() );
	%explosion.setSizeScale(2);
	myScene.add( %explosion );
		
	%this.safeDelete();
	%sceneObj.safeDelete();
	origWork.schedule( 500, "initDie" );
}
