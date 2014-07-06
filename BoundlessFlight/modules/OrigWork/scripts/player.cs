function createPlayer()
{
	%p = new Sprite(Player);
	%p.setBodyType( dynamic );
	%p.Position = "0 -10";
	%p.Size = "5.0 5.0";
	%p.SceneLayer = 1;
	
	%c = FollowMouseBehavior.createInstance();
	%c.speedField = 30.0;
	%c.freqField = 200.0;
	%p.addBehavior(%c);
	
	%s = ShootBehavior.createInstance();
	%p.addBehavior(%c);
	
	%p.Image = "origWork:ship4";
	
	myScene.add( %p );
}