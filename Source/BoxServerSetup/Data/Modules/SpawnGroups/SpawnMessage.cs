using System;
using Server;
using Server.Targeting;
using TheBox.Data;

namespace TheBox.BoxServer
{
	[ Serializable ]
	/// <summary>
	/// This message creates a spawn group in Pandora's Box
	/// </summary>
	public class SpawnMessage : BoxMessage, IAuthenticable
	{
		private BoxSpawn m_Spawn;

		/// <summary>
		/// Gets or sets the spawn requested by Pandora's Box
		/// </summary>
		public BoxSpawn Spawn
		{
			get { return m_Spawn; }
			set { m_Spawn = value; }
		}

		/// <summary>
		/// Creates a new SpawnMessage
		/// </summary>
		public SpawnMessage()
		{
		}

		/// <summary>
		/// Creates a new SpawnMessage
		/// </summary>
		/// <param name="spawn">The spawn that will be created on the server</param>
		public SpawnMessage( BoxSpawn spawn )
		{
			m_Spawn = spawn;
		}

		#region IAuthenticable Members

		public Server.AccessLevel MinAccessLevel
		{
			get
			{
				return AccessLevel.GameMaster;
			}
		}

		public bool RequireOnlineMobile
		{
			get
			{
				return true;
			}
		}

		#endregion

		public override BoxMessage Perform()
		{
			Item spawner = SpawnerHelper.CreateBoxSpawn( m_Spawn );
			Mobile m = Authentication.GetOnlineMobile( Username );

			if ( spawner != null && m != null )
			{
				m.SendMessage( BoxConfig.MessageHue, "Where do you wish to place the spawn?" );

				m.Target = new InternalTarget( m_Spawn );
			}

			return null;
		}

		#region InternalTarget

		private class InternalTarget : Target
		{
			private BoxSpawn m_Spawn;

			public InternalTarget( BoxSpawn spawn ) : base ( -1, true, TargetFlags.None )
			{
				m_Spawn = spawn;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				IPoint3D target = targeted as IPoint3D;

				if ( target != null )
				{
					Item spawner = SpawnerHelper.CreateBoxSpawn( m_Spawn );

					if ( spawner != null )
					{
						spawner.MoveToWorld( new Point3D( target ), from.Map );
						SpawnerHelper.StartSpawner( spawner );

						from.SendMessage( BoxConfig.MessageHue, "Spawn succesful." );
					}
					else
					{
						from.SendMessage( BoxConfig.MessageHue, "Spawn failed." );
					}
				}

				base.OnTarget (from, targeted);
			}
		}

		#endregion
	}
}
