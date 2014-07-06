if ( !isObject(FollowMouseBehavior) )
{
	%template = new BehaviorTemplate(FollowMouseBehavior);
	
	%template.friendlyName = "Follow Mouse Behavior";
	%template.behaviorType = "Controls";
	%template.description = "Causes an object to follow the mouse.";
	
	%template.addBehaviorField(speedField, "The speed of movement", float, 10.0);
	%template.addBehaviorField(freqField, "The frequency at which to update the position of the mouse", int, 200);
}

function FollowMouseBehavior::onBehaviorAdd(%this)
{
	%this.schedule(%this.freqField, update);
}

function FollowMouseBehavior::update( %this )
{
	%x = getWord(mySceneWindow.getMousePosition(), 0);
	%y = getWord(%this.owner.getPosition(), 1);
	%this.owner.MoveTo( %x SPC %y, %this.speedField );
	
	%this.schedule(%this.freqField, update);
}

function FollowMouseBehavior::onBehaviorRemove(%this)
{
	// Insert deletion behavior here.
}