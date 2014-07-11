function createEnemy( %eRef )
{
	%sz = 5.0;
	echo( "Spawn at" SPC %eRef.pos );
	%e = new Sprite();
	%e.class = "Enemy";
	%e.setPosition( %eRef.pos );
	%e.setSize( %sz, %sz );
	%e.SceneLayer = 2;
	%e.setLinearVelocity( 0.0, -15.0 );
	%e.Image = "origWork:bug1";
	%e.setSceneGroup( $Game::EnemyGroup );
	%e.createCircleCollisionShape( %sz / 2.0 );
	%e.setCollisionGroups( $Game::PlayerGroup SPC $Game::BulletGroup );
	%e.setCollisionCallback( true );
	
	// Behaviors
	
	// End Behaviors
	
	myScene.add( %e );
}

function Enemy::onCollision(%this, %sceneObject, %collisionDetails)
{
	%this.safeDelete();
}