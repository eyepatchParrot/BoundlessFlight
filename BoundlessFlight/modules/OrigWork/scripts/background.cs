function createBackground()
{
	%bg = new Sprite( Background );
	%bg.setPosition( "0 0" );
	%bg.setSize( "100 75" );
	%bg.setSceneLayer( 31 );
	%bg.setImage( "ToyAssets:skyBackground" );
	myScene.add( %bg );
	
	%pbg = new Sprite( ParallaxBackground );
	%pbg.setPosition( "0 0" );
	%pbg.setSize( "100 75" );
	%pbg.setSceneLayer( 30 );
	%pbg.setImage( "OrigWork:starsParallax" );
	%pbg.setLinearVelocity( 0.0, -5.0 );
	myScene.add( %pbg );
	
	%pbg2 = %pbg.clone();
	%pbg2.setPosition( "0 37.5" );
	myScene.add( %pbg2 );
}