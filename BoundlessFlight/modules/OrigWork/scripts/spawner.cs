function createSpawner()
{
	%s = new SimSet( Spawner );
	
	%w = createWave( 500 );
	%w.addEnemy( "0 40" );
	%s.addWave( %w );
	
	%w = createWave();
	%w.addEnemy("10 40");
	%w.addEnemy("-10 40");
	%s.addWave( %w );
	
	%s.update();
}

function Spawner::addWave( %this, %w )
{
	%this.add( %w );
}

function Spawner::update( %this )
{
	echo( "Updating. Num waves" SPC %this.getCount() );
	%w = %this.getObject( 0 );
	
	%w.spawn();
	if( %this.getCount() > 1 )
	{
		%this.schedule( %w.getDelay(), "update" );
		%this.remove( %w );
	}
}

function createWave( %delayAfter )
{
	%w = new ScriptObject();
	%w.class = "Wave";
	%w.delayAfter = %delayAfter;
	%w.enemies = new SimSet();
	return %w;
}

function Wave::addEnemy( %this, %pos )
{
	%e = new ScriptObject();
	%e.pos = %pos;
	%this.enemies.add( %e );
}

function Wave::getDelay( %this )
{
	return %this.delayAfter;
}

function Wave::isEmpty( %this )
{
	return (%this.enemies.getCount() == 0);
}

function Wave::popEnemy( %this )
{
	%e = %this.enemies.getObject( 0 );
	%this.enemies.remove( %e );
	return %e;
}

function Wave::spawn( %this )
{
	echo( "Spawning wave. Wave is empty:" SPC %this.isEmpty() );
	while ( !%this.isEmpty() )
	{
		createEnemy( %this.popEnemy() );
	}
}