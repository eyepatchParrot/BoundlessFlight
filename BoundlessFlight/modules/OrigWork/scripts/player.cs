function createPlayer()
{
	%sz = 5.0;
	%p = new Sprite(Player);
	%p.setBodyType( dynamic );
	%p.Position = "0 -30";
	%p.Size = %sz SPC %sz;
	%p.SceneLayer = $Game::PlayerGroup;
	%p.Image = "origWork:ship4";
	%p.createCircleCollisionShape( %sz / 2.0 );
	%p.setCollisionGroups( $Game::EnemyGroup );
	
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

function Player::shoot( %this )
{
	%this.getBehavior("ShootBehavior").shoot();
}