function createSpawner()
{
	%s = new SimSet( Spawner );
	
	%s.addNewWave( 3000, "" );
	%s.addNewWave( 3000, "0 40");
	%s.addNewWave( 3000, "0 40" SPC "40 40" SPC "-40 40" );
	%s.addNewWave( 2000, "20 40" SPC "-20 40" );
	%s.addNewWave( 2000, "-40 40" SPC "-10 40" SPC "10 40" SPC "40 40" );
	%s.addNewWave( 3000, "0 40" SPC "40 40" SPC "-40 40" SPC "20 52" SPC "-20 52" );
	%s.addNewWave( 2000, "20 40" SPC "-20 40" );
	%s.addNewWave( 3000, "-40 40" SPC "0 40" SPC "40 40" SPC "-20 52" SPC "20 52" );
	%s.addNewWave( 3000, "-40 40" SPC "0 40" SPC "40 40" SPC "-20 52" SPC "20 52" );
	%s.addNewWave( 3000, "-40 40" SPC "0 40" SPC "40 40" SPC "-20 52" SPC "20 52" );
	%s.addNewWave( 2000, "-40 40" SPC "-10 40" SPC "10 40" SPC "40 40" );
	%s.addNewWave( 2000, "-40 40" SPC "-10 40" SPC "10 40" SPC "40 40" );
	%s.addNewWave( 2000, "-40 40" SPC "0 40" SPC "10 40" SPC "40 40" );
	%s.addNewWave( 1000, "-40 40" SPC "0 40" SPC "40 40" );
	%s.addNewWave( 1000, "-40 40" SPC "0 40" SPC "40 40" );
	%s.addNewWave( 1000, "-40 40" SPC "0 40" SPC "40 40" );
	%s.addNewWave( 1000, "-40 40" SPC "0 40" SPC "40 40" );
	%s.addNewWave( 3000, "45 40" SPC "30 46" SPC "15 52" SPC "0 58" SPC "-15 64" SPC "-30 70" SPC "-45 76");
	%s.addNewWave( 3000, "-30 40" SPC "-15 46" SPC "0 52" SPC "15 58" SPC "30 64" SPC "45 70" );
	%s.addNewWave( 3000, "-40 40" SPC "0 40" SPC "40 40" SPC "-20 52" SPC "20 52" );
	%s.addNewWave( 3000, "-40 46" SPC "0 46" SPC "40 46" SPC "-20 40" SPC "20 40" );
	%s.update();
}

function Spawner::addWave( %this, %w )
{
	%this.add( %w );
}

function Spawner::addNewWave( %this, %delay, %enemies )
{
	%w = createWave( %delay );
	%max = getWordCount( %enemies );
	for (%i = 0; %i + 1 < %max; %i += 2 )
	{
		%w.addEnemy( getWord( %enemies, %i) SPC getWord( %enemies, %i + 1 ) );
	}
	%this.addWave( %w );
}

function Spawner::update( %this )
{
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
	while ( !%this.isEmpty() )
	{
		createEnemy( %this.popEnemy() );
	}
}