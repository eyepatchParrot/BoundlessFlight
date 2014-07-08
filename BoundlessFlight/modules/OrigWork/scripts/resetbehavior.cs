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
	%bound = new SceneObject();
	
}

function TemplateBehavior::onBehaviorRemove(%this)
{
	// Insert deletion behavior here.
}