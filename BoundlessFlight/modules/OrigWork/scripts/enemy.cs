function createEnemy( %eRef )
{
	echo( "Spawn at" SPC %eRef.pos );
	%e = new Sprite();
	%e.class = "Enemy";
	%e.setPosition( %eRef.pos );
	%e.setSize( 5.0, 5.0 );
	%e.SceneLayer = 2;
	%e.setLinearVelocity( 0.0, -15.0 );
	%e.Image = "origWork:bug1";
	myScene.add( %e );
}