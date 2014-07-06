function createPlayer()
{
	%p = new Sprite(Player);
	%p.setBodyType( dynamic );
	%p.Position = "0 0";
	%p.Size = "1.0 1.0";
	%p.SceneLayer = 1;
	
	%c = FollowMouseBehavior.createInstance();
	%p.addBehavior(%c);
	
	%p.Image = "origWork:ship4";
	
	myScene.add( %p );
}