using System;

using Server;
using Server.Mobiles;

using TheBox.Data;

namespace TheBox.BoxServer
{
	/// <summary>
	/// Provides methods that are used to manipulate spawners
	/// 
	/// This version of the class deals with the RunUO standard Spawner
	/// </summary>
	public class SpawnerHelper
	{
		/// <summary>
		/// This defines the type of the spawner object used on the shard
		/// </summary>
		public static Type SpawnerType
		{
			get
			{
				//
				// TODO : Define the type of your spawner object
				//
				// Example:
				// return typeof( Spawner );

				return null;
			}
		}

		/// <summary>
		/// Converts a spawner to a SpawnEntry used in SpawnData.
		/// </summary>
		/// <param name="spawnerItem">The spawner to convert</param>
		/// <returns>The SpawnEntry representing the spawner</returns>
		public static SpawnEntry SpawnerToData( Item spawnerItem )
		{
			//
			// TODO : Convert a spawner object to a SpawnEntry object
			// The code below (commented out) shows the implementation of this method
			// for the default Spawner object
			//

/*			Spawner spawner = spawnerItem as Spawner;

			if ( spawner == null || spawner.Map == Server.Map.Internal )
				return null;

			SpawnEntry entry = new SpawnEntry();

			entry.Map = spawner.Map.MapID;
			entry.X = spawner.X;
			entry.Y = spawner.Y;
			entry.Z = spawner.Z;

			entry.Team = spawner.Team;
			entry.Count = spawner.Count;
			entry.Range = spawner.HomeRange;
			entry.MinDelay = spawner.MinDelay.TotalSeconds;
			entry.MaxDelay = spawner.MaxDelay.TotalSeconds;

			entry.Names.AddRange( spawner.CreaturesName );

			return entry;*/
		}

		/// <summary>
		/// Converts a BoxSpawn to an actual spawner object. This function is used to generate
		/// spawn groups created in Pandora's Box
		/// </summary>
		/// <param name="spawn">The BoxSpawn object describing the spawn that should be created</param>
		/// <returns>A Spawner object - null if not valid</returns>
		public static Item CreateBoxSpawn( BoxSpawn spawn )
		{
			//
			// TODO : Convert the BoxSpawn object to your custom spawner
			// The code below (commented out) shows the implementation of this method
			// for the default Spawner object
			//


/*			if ( spawn == null || spawn.Entries.Count == 0 )
				return null;

			Spawner spawner = new Spawner( spawn.Count, spawn.MinDelay, spawn.MaxDelay, spawn.Team, spawn.HomeRange, null );
			spawner.Running = false;

			spawner.Group = spawn.Group;

			foreach ( BoxSpawnEntry entry in spawn.Entries )
			{
				spawner.CreaturesName.Add( entry.Type );
			}

			return spawner; */
		}

		/// <summary>
		/// Initializes and starts the spawner, spawning all the creatures
		/// </summary>
		/// <param name="spawner">The spawner item</param>
		public static void StartSpawner( Item spawner )
		{
			//
			// TODO : Define the code that will start the spawner and spawn its creatures
			// The code below (commented out) shows the implementation of this method
			// for the default Spawner object
			//

			Spawner s = spawner as Spawner;

			if ( s != null )
			{
				s.Running = true;
				s.Respawn();
			}
		}
	}
}
