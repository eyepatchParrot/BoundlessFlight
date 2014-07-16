function createEnemy( %eRef )
{
	%xSz = 6.5;
	%ySz = 5.0;
	%e = new Sprite();
	%e.class = "Enemy";
	%e.setPosition( %eRef.pos );
	%e.setSize( %xSz, %ySz );
	%e.SceneLayer = 2;
	%e.setLinearVelocity( 0.0, -15.0 );
	%e.Image = "origWork:enemy1";
	%e.setFlipY( true );
	%e.setSceneGroup( $Game::EnemyGroup );
	%e.createCircleCollisionShape( %xSz / 2.0 );
	%e.setCollisionGroups( $Game::PlayerGroup SPC $Game::BulletGroup SPC $Game::EnemyGroup );
	%e.setCollisionCallback( true );
	
	// Behaviors
	%ai = EnemyAIBehavior.createInstance();
	%ai.playerField = Player;
	%e.addBehavior( %ai );
	// End Behaviors
	
	myScene.add( %e );
}

function Enemy::onCollision(%this, %sceneObject, %collisionDetails)
{
	if (%sceneObject.getSceneGroup() != $Game::EnemyGroup)
	{
		%explosion = new ParticlePlayer();
		%explosion.Particle = "ToyAssets:impactExplosion";
		%explosion.setPosition( %this.getPosition() );
		%explosion.setSizeScale(2);
		%explosion.setLinearVelocity( 0.0, -15.0 );
		myScene.add( %explosion );
		%this.safeDelete();
	}
}