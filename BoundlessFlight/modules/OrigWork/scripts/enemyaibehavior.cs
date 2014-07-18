if ( !isObject(EnemyAIBehavior) )
{
	%template = new BehaviorTemplate(EnemyAIBehavior);
	
	%template.friendlyName = "Enemy AI Behavior";
	%template.behaviorType = "AI";
	%template.description = "Controls the enemy ships.";
	
	%template.addBehaviorField(playerField, "Links to the player sprite.", SceneObject, null);
	%template.addBehaviorField(updateFreqField, "How often to update direction. (in millisecs)", int, 100);
	%template.addBehaviorField(moveSpeed, "Speed to move to target.", float, 3.0 );
}

function EnemyAIBehavior::onBehaviorAdd(%this)
{
	// Insert instantiation behavior here.
	%this.schedule(32, updateDirection);
}

function EnemyAIBehavior::updateDirection( %this )
{
	if ( !isObject( %this.playerField ) || getWord( %this.owner.getPosition(), 1) > 40 )
	{
		%this.owner.setLinearVelocityX( 0.0 );
	}
	else
	{
		%pX = getWord( %this.playerField.getPosition(), 0 );
		%tX = getWord( %this.owner.getPosition(), 0 );
		if ( %pX > %tX )
		{
			%mult = 1.0;
		}
		else
		{
			%mult = -1.0;
		}
	}
	
	%this.owner.setLinearVelocityX(%this.moveSpeed * %mult);
	%this.schedule(%this.updateFreqField, updateDirection);
}

function EnemyAIBehavior::onBehaviorRemove(%this)
{
	// Insert deletion behavior here.
}