using System;
using System.IO;
using Server;

using TheBox.Data;
using TheBox.Common;

namespace TheBox.BoxServer
{
	/// <summary>
	/// Defines the datafiles that can be retrieved from the server
	/// </summary>
	public enum BoxDatafile
	{
		BoxData,
		PropsData,
		SpawnData
	}

	[ Serializable ]
	/// <summary>
	/// This message is used to retrieve a datafile from the server
	/// </summary>
	public class GetDatafile : BoxMessage, IAuthenticable
	{
		/// <summary>
		/// Creates a new GetPropsData message
		/// </summary>
		public GetDatafile()
		{
		}

		private BoxDatafile m_DataType;

		/// <summary>
		/// Gets or sets the datafile type to retrieve
		/// </summary>
		public BoxDatafile DataType
		{
			get { return m_DataType; }
			set { m_DataType = value; }
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
				return false;
			}
		}

		#endregion

		public override BoxMessage Perform()
		{
			string file = null;
			string path = null;
			Type type = null;

			switch ( m_DataType )
			{
				case BoxDatafile.BoxData:

					file = "BoxData.xml";
					type = typeof( BoxData );
					break;

				case BoxDatafile.PropsData:

					file = "PropsData.xml";
					type = typeof( PropsData );
					break;

				case BoxDatafile.SpawnData:

					file = "SpawnData.xml";
					type = typeof( SpawnData );
					break;
			}

			path = System.IO.Path.Combine( BoxUtil.BoxFolder, file );

			object data = BoxUtil.XmlLoad( path, type );

			if ( data == null )
			{
				return new DatafileNotFound();
			}
			else
			{
				return new ReturnDatafile( data );
			}
		}
	}
}
