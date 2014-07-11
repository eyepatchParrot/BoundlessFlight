if ( !isObject(ShootBehavior) )
{
	%template = new BehaviorTemplate(ShootBehavior);
	
	%template.friendlyName = "Shoot Behavior";
	%template.behaviorType = "Controls";
	%template.description = "Initiates a shot when the mouse button is pressed.";
	
	%template.addBehaviorField( speedField, "Speed of the bullet.", float, 20.0 );
	%template.addBehaviorField( sizeField, "Size of the bullet.", string, "5.0 5.0" );
	%template.addBehaviorField( animationField, "Animation for the bullet.", string, "ToyAssets:Cannonball_projectile_1Animation" );
}

function ShootBehavior::onBehaviorAdd(%this)
{
	// Insert instantiation behavior here.
}

function ShootBehavior::shoot( %this )
{
	%b = new Sprite()
	{
		class = "Bullet";
	};
	%b.Position = %this.owner.getPosition();
	%b.Size = %this.sizeField;
	%b.SceneLayer = 2;
	%b.setFixedAngle( true );
	%b.setLinearVelocityPolar( 90.0, %this.speedField);
	%b.playAnimation( %this.animationField );
	%b.setSceneGroup( $Game::BulletGroup );
	%sz = mGetMax( getWord( %this.sizeField, 0 ), getWord( %this.sizeField, 1 ) );
	%b.createCircleCollisionShape( %sz / 2.0 );
	%b.setCollisionGroups( $Game::EnemyGroup );
	
	myScene.add( %b );
}

function ShootBehavior::onBehaviorRemove(%this)
{
	// Insert deletion behavior here.
}