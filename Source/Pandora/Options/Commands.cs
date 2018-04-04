#region Header
// /*
//  *    2018 - Pandora - Commands.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
#endregion

namespace TheBox.Options
{
	/// <summary>
	///     Provides definitions for customizable commands
	/// </summary>
	[Serializable]
	public class CommandsOptions
	{
		/// <summary>
		///     Applies a modifier to a command
		/// </summary>
		/// <param name="cmd">The command being processed</param>
		/// <param name="modifier">The modifier that must be applied. Can be null</param>
		/// <returns>The processed command</returns>
		private static string ApplyModifier(string cmd, string modifier)
		{
			if (modifier != null)
			{
				return string.Format("{0} {1}", modifier, cmd);
			}
			return cmd;
		}

		#region General commands
		private string m_AddItem = "Add";
		private string m_AddMobile = "Add";
		private string m_AddToPack = "AddToPack";

		[Description("The command used to add scripted items"), Category("General")]
		public string AddItem { get { return m_AddItem; } set { m_AddItem = value; } }

		[Description("The command used to add scripted NPCs"), Category("General")]
		public string AddMobile { get { return m_AddMobile; } set { m_AddMobile = value; } }

		[Description("The command used to add an item to a Mobile's backpack"), Category("General")]
		public string AddToPack { get { return m_AddToPack; } set { m_AddToPack = value; } }

		public void DoAddItem(string item, string modifier, params string[] additional)
		{
			var cmd = string.Format("{0} {1}", m_AddItem, item);

			if (modifier != null)
			{
				cmd = string.Format("{0} {1}", modifier, cmd);
			}

			foreach (var s in additional)
			{
				cmd += " " + s;
			}

			Pandora.SendToUO(cmd, true);
		}

		public void DoAddMobile(string mobile, params string[] additional)
		{
			var cmd = string.Format("{0} {1}", m_AddMobile, mobile);

			foreach (var s in additional)
			{
				cmd += " " + s;
			}

			Pandora.SendToUO(cmd, true);
		}

		public void DoAddToPack(string item, string modifier, params string[] additional)
		{
			var cmd = string.Format("{0} {1}", m_AddToPack, item);

			if (modifier != null)
			{
				cmd = string.Format("{0} {1}", modifier, cmd);
			}

			foreach (var s in additional)
			{
				cmd += " " + s;
			}

			Pandora.SendToUO(cmd, true);
		}
		#endregion

		#region Properties
		private string m_Get = "Get {prop}";
		private string m_Set = "Set {prop} {value}";

		[Description(
			 @"Get the value of a property. Variables:

{prop} : the property being evaluated"), Category("Properties")]
		public string Get { get { return m_Get; } set { m_Get = value; } }

		[Description(
			 @"Set the value of a property. Variables:

{prop} : the property being set
{value} : the value"), Category("Properties")]
		public string Set { get { return m_Set; } set { m_Set = value; } }

		public void DoGet(string prop)
		{
			var cmd = m_Get.Replace("{prop}", prop);
			Pandora.SendToUO(cmd, true);
		}

		public void DoSet(string prop, string value, string modifier)
		{
			var cmd = m_Set.Replace("{prop}", prop);
			cmd = cmd.Replace("{value}", value);

			cmd = ApplyModifier(cmd, modifier);

			Pandora.SendToUO(cmd, true);
		}

		public void DoSet(string prop, string value, string filter, string modifier)
		{
			var cmd = m_Set.Replace("{prop}", prop);
			cmd = cmd.Replace("{value}", value);

			if (filter != null && filter.Length > 0)
			{
				cmd += " " + filter;
			}

			cmd = ApplyModifier(cmd, modifier);

			Pandora.SendToUO(cmd, true);
		}
		#endregion

		#region Go
		private string m_GoFormat = "Go {x} {y} {z}";
		private bool m_SetMapOnGo = true;

		[Description(
			 "When set to true, Pandora will [SetMy Map before sending the go command. Recommended for the default format"),
		 Category("Travel")]
		public bool SetMapOnGo { get { return m_SetMapOnGo; } set { m_SetMapOnGo = value; } }

		[Description(
			 @"Available variables:

{x}, {y}, {z} : The x, y and z coordinates of the target location
{map} : A value corresponding to the map plane the target location is on"), Category("Travel")]
		/// <summary>
		/// Gets or sets the format for the go command
		/// </summary>
		public string Go { get { return m_GoFormat; } set { m_GoFormat = value; } }

		/// <summary>
		///     Sends the Go command to UO
		/// </summary>
		/// <param name="x">The target X coordinate</param>
		/// <param name="y">The target Y coordinate</param>
		/// <param name="z">The target Z coordinate</param>
		/// <param name="map">The target map</param>
		public void DoGo(int x, int y, int z, int map)
		{
			var cmd = m_GoFormat;

			cmd = cmd.Replace("{x}", x.ToString());
			cmd = cmd.Replace("{y}", y.ToString());
			cmd = cmd.Replace("{z}", z.ToString());
			cmd = cmd.Replace("{map}", map.ToString());

			if (m_SetMapOnGo)
			{
				DoSet("map", map.ToString(), "Self");
			}

			Pandora.SendToUO(cmd, true);
		}
		#endregion

		#region Send
		private string m_SendFormat = "Set location {x} {y} {z}";

		[Description(
			 @"Available variables:

{x}, {y}, {z} : The x, y and z coordinates of the target location
{map} : A value corresponding to the map plane the target location is on"), Category("Travel")]

		/// <summary>
		/// Gets or sets the format for the Send command
		/// </summary>
		public string Send { get { return m_SendFormat; } set { m_SendFormat = value; } }

		/// <summary>
		///     Sends the Send command to UO
		/// </summary>
		/// <param name="x">The target X coordinate</param>
		/// <param name="y">The target Y coordinate</param>
		/// <param name="z">The target Z coordinate</param>
		/// <param name="map">The target map</param>
		public void DoSend(int x, int y, int z, int map)
		{
			var cmd = m_SendFormat;

			cmd = cmd.Replace("{x}", x.ToString());
			cmd = cmd.Replace("{y}", y.ToString());
			cmd = cmd.Replace("{z}", z.ToString());
			cmd = cmd.Replace("{map}", map.ToString());

			Pandora.SendToUO(cmd, true);
		}
		#endregion

		#region Spawn
		private string m_SpawnFormat = "Add Spawner {amount} {min} {max} {team} {range} {creature}";

		[Description(
			 @"Available properties are:

{creature} - The name of the creature as selected in the NPCs tab.
{amount}, {min}, {max}, {team}, {range} correspond to the values in the Spawn configuration.
{extra} is an additional parameter that can be used in conjunction with a custom spawner."), Category("Mobiles")]
		/// <summary>
		/// Gets or sets the format for the spawn command
		/// </summary>
		public string Spawn { get { return m_SpawnFormat; } set { m_SpawnFormat = value; } }

		/// <summary>
		///     Sends the spawn command to UO
		/// </summary>
		/// <param name="creature">The name of the creature being spawned</param>
		public void DoSpawn(string creature)
		{
			var cmd = m_SpawnFormat;

			cmd = cmd.Replace("{creature}", creature);
			cmd = cmd.Replace("{amount}", Pandora.Profile.Mobiles.Amount.ToString());
			cmd = cmd.Replace("{min}", Pandora.Profile.Mobiles.MinDelay.ToString());
			cmd = cmd.Replace("{max}", Pandora.Profile.Mobiles.MaxDelay.ToString());
			cmd = cmd.Replace("{team}", Pandora.Profile.Mobiles.Team.ToString());
			cmd = cmd.Replace("{range}", Pandora.Profile.Mobiles.Range.ToString());
			cmd = cmd.Replace("{extra}", Pandora.Profile.Mobiles.Extra.ToString());

			Pandora.SendToUO(cmd, true);
		}

		/// <summary>
		///     Spawns an item
		/// </summary>
		/// <param name="item">The item name</param>
		public void DoSpawnItem(string item)
		{
			var cmd = m_SpawnFormat;

			cmd = cmd.Replace("{creature}", item);
			cmd = cmd.Replace("{amount}", Pandora.Profile.Items.Amount.ToString());
			cmd = cmd.Replace("{min}", Pandora.Profile.Items.MinDelay.ToString());
			cmd = cmd.Replace("{max}", Pandora.Profile.Items.MaxDelay.ToString());
			cmd = cmd.Replace("{team}", Pandora.Profile.Items.Team.ToString());
			cmd = cmd.Replace("{range}", Pandora.Profile.Items.Range.ToString());
			cmd = cmd.Replace("{extra}", Pandora.Profile.Items.Extra.ToString());

			Pandora.SendToUO(cmd, true);
		}
		#endregion

		#region Deco
		private string m_Deco = "static {id} set movable {movable} hue {hue} light {light}";
		private string m_Tile = "TileZ {z} {item}";
		private string m_NudgeUp = "Inc Z {z}";
		private string m_NudgeDown = "Inc Z -{z}";

		/// <summary>
		///     Gets or sets the command used to nudge up items
		/// </summary>
		[Category("Deco"), Description("Command used to nudge objects up. Use {z} to specify the absolute nudge offset.")]
		public string NudgeUp { get { return m_NudgeUp; } set { m_NudgeUp = value; } }

		[Category("Deco"), Description("Command used to nudge objects down. Use {z} to specify the absolute nudge offset.")]
		public string NudgeDown { get { return m_NudgeDown; } set { m_NudgeDown = value; } }

		/// <summary>
		///     Gets or sets the constructor for a movable item
		/// </summary>
		[Category("Deco"), Description(
			 @"Constructor for a static item item. Available variables:

{id} - The Item ID
{movable} - Depends on the static checkbox
{hue} - The hue for the item
{light} - The light applied to the item")]
		public string Deco { get { return m_Deco; } set { m_Deco = value; } }

		/// <summary>
		///     Gets or sets the string that can be used to tile an item
		/// </summary>
		[Category("Deco"), Description(
			 @"Tiles an item at the specified height. Available variables:

{z} - The height at which the tiling occurs
{item} - The item being tiled")]
		public string Tile { get { return m_Tile; } set { m_Tile = value; } }

		/// <summary>
		///     Creates a decoration item
		/// </summary>
		/// <param name="id">The ID of the item being created</param>
		/// <param name="movable">States whether the item should be movable or not</param>
		/// <param name="hue">Specifies the hue of the item</param>
		/// <param name="rnd">The randomization amount. Use 0 to disable</param>
		/// <param name="modifer">The eventual modifier</param>
		public void DoAddDeco(int id, bool movable, int hue, int rnd, string modifier)
		{
			var item = m_Deco;

			if (rnd == 0)
			{
				item = item.Replace("{id}", id.ToString());
			}
			else
			{
				item = item.Replace("{id}", string.Format("{0} {1}", id, rnd));
			}
			item = item.Replace("{movable}", movable.ToString());
			item = item.Replace("{hue}", hue.ToString());
			item = item.Replace("{light}", Pandora.Profile.Deco.Light);

			DoAddItem(item, modifier);
		}

		/// <summary>
		///     Sends the tile command
		/// </summary>
		/// <param name="z">Height at which tiling occurs</param>
		/// <param name="id">ID of the item being added</param>
		/// <param name="movable">States whether the item can be moved or not</param>
		/// <param name="hue">The hue value</param>
		/// <param name="rnd">The randomization amount. Use 0 to disable</param>
		public void DoTile(int z, int id, bool movable, int hue, int rnd)
		{
			var item = m_Deco;
			string tile = null;

			if (rnd == 0)
			{
				item = item.Replace("{id}", id.ToString());
			}
			else
			{
				item = item.Replace("{id}", string.Format("{0} {1}", id, rnd));
			}
			item = item.Replace("{movable}", movable.ToString());
			item = item.Replace("{hue}", hue.ToString());

			tile = m_Tile.Replace("{item}", item);
			tile = tile.Replace("{z}", z.ToString());

			Pandora.SendToUO(tile, true);
		}

		/// <summary>
		///     Sends the IncXYZ command to UO
		/// </summary>
		/// <param name="modifier">The modifier for the command</param>
		/// <param name="x">The X Offset</param>
		/// <param name="y">The Y Offset</param>
		public void DoMove(string modifier, int x, int y)
		{
			var cmd = "Inc";

			if (modifier != null)
			{
				cmd = modifier + " " + cmd;
			}

			if (x != 0)
				cmd += string.Format(" X {0}", x);

			if (y != 0)
				cmd += string.Format(" Y {0}", y);

			Pandora.SendToUO(cmd, true);
		}

		/// <summary>
		///     Performs the nudge up command
		/// </summary>
		/// <param name="z">The amount to nudge</param>
		/// <param name="modifier">The command modifier</param>
		public void DoNudgeUp(int z, string modifier)
		{
			var nudge = m_NudgeUp.Replace("{z}", z.ToString());

			if (modifier != null)
			{
				nudge = string.Format("{0} {1}", modifier, nudge);
			}

			Pandora.SendToUO(nudge, true);
		}

		/// <summary>
		///     Performs the nudge down command
		/// </summary>
		/// <param name="z">The amount to nudge</param>
		/// <param name="modifier">The command modifier</param>
		public void DoNudgeDown(int z, string modifier)
		{
			var nudge = m_NudgeDown.Replace("{z}", z.ToString());

			if (modifier != null)
			{
				nudge = string.Format("{0} {1}", modifier, nudge);
			}

			Pandora.SendToUO(nudge, true);
		}

		/// <summary>
		///     Tiles a scripted item
		/// </summary>
		/// <param name="z">The tiling height</param>
		/// <param name="item">The item constructor</param>
		public void DoTileItem(int z, string item)
		{
			var cmd = m_Tile.Replace("{z}", z.ToString());
			cmd = cmd.Replace("{item}", item);

			Pandora.SendToUO(cmd, true);
		}
		#endregion

		#region Misc
		private string m_FindByName = "FindByName {item}";

		[Category("Misc"),
		 Description("Command used to search for items from the admin tab. Use {item} to specify the user input item name.")]
		/// <summary>
		/// Gets or sets the command used to search for items
		/// </summary>
		public string FindByName { get { return m_FindByName; } set { m_FindByName = value; } }

		/// <summary>
		///     Performs the FindByName command
		/// </summary>
		/// <param name="item">The item name to search for</param>
		public void DoFindByName(string item)
		{
			var cmd = m_FindByName.Replace("{item}", item);
			Pandora.SendToUO(cmd, true);
		}

		private string m_OpenBrowser = "OpenBrowser {url}";

		[Category("Misc"),
		 Description("Opens a web page in a targeted mobile browser. Use {url} to specify the page you wish to send.")]
		/// <summary>
		/// Gets or sets the Open Browser command
		/// </summary>
		public string OpenBrowser { get { return m_OpenBrowser; } set { m_OpenBrowser = value; } }

		/// <summary>
		///     Performs the open browser command
		/// </summary>
		/// <param name="url">The url to open</param>
		/// <param name="modifier">The command modifier</param>
		public void DoOpenBrowser(string url, string modifier)
		{
			var cmd = m_OpenBrowser.Replace("{url}", url);
			cmd = ApplyModifier(cmd, modifier);
			Pandora.SendToUO(cmd, true);
		}
		#endregion

		#region Skills
		private string m_SetSkill = "SetSkill {skill} {value}";
		private string m_GetSkill = "GetSkill {skill}";
		private string m_SetAllSkills = "SetAllSkills {value}";
		private string m_GetAllSkills = "Skills";

		[Category("Skills"), Description(
			 @"Command used to set a single skill. Parameters:

{skill} - The name of the skill
{value} - The value the skill must be set to")]
		/// <summary>
		/// Gets or sets the command used to set a skill
		/// </summary>
		public string SetSkill { get { return m_SetSkill; } set { m_SetSkill = value; } }

		[Category("Skills"),
		 Description("Command used to retrieve the value of a skill on a mobile. Use {skill} to describe the skill name.")]
		/// <summary>
		/// Gets or sets the command used to get a skill
		/// </summary>
		public string GetSkill { get { return m_GetSkill; } set { m_GetSkill = value; } }

		[Category("Skills"),
		 Description(
			 "Command used to set all the skills of a targeted mobile. Use {value} to define the value the skill must be set to.")]
		/// <summary>
		/// Gets or sets the command to set all skills
		/// </summary>
		public string SetAllSkills { get { return m_SetAllSkills; } set { m_SetAllSkills = value; } }

		[Category("Skills"), Description("Command used to view all the skills of a targeted mobile.")]
		/// <summary>
		/// Gets or sets the command to get all skills
		/// </summary>
		public string GetAllSkills { get { return m_GetAllSkills; } set { m_GetAllSkills = value; } }

		/// <summary>
		///     Sets a single skill on a targeted mobile
		/// </summary>
		/// <param name="skill">The name of the skill</param>
		/// <param name="value">The value of the skill</param>
		public void DoSetSkill(string skill, decimal value)
		{
			var cmd = m_SetSkill.Replace("{skill}", skill);
			cmd = cmd.Replace("{value}", value.ToString());

			Pandora.SendToUO(cmd, true);
		}

		/// <summary>
		///     Gets the value of a skill on a targeted mobile
		/// </summary>
		/// <param name="skill">The name of the skill to get</param>
		public void DoGetSkill(string skill)
		{
			var cmd = m_GetSkill.Replace("{skill}", skill);
			Pandora.SendToUO(cmd, true);
		}

		/// <summary>
		///     Sets all the skills of a targeted mobile
		/// </summary>
		/// <param name="value">The value that should be set</param>
		public void DoSetAllSkills(decimal value)
		{
			var cmd = m_SetAllSkills.Replace("{value}", value.ToString());
			Pandora.SendToUO(cmd, true);
		}

		/// <summary>
		///     Sends the Skills command
		/// </summary>
		public void DoGetAllSkills()
		{
			Pandora.SendToUO(m_GetAllSkills, true);
		}
		#endregion

		#region Duping
		private string m_Dupe = "Dupe";
		private string m_DupeInBag = "DupeInBag";
		private string m_AmountDupe = "Dupe {amount}";
		private string m_AmountDupeInBag = "DupeInBag {amount}";

		[Category("Duping"), Description("Command used to dupe an item")]
		/// <summary>
		/// Gets or sets the dupe command
		/// </summary>
		public string Dupe { get { return m_Dupe; } set { m_Dupe = value; } }

		[Category("Duping"), Description("Command used to dupe an item inside its container")]
		/// <summary>
		/// Gets or sets the dupe in bag command
		/// </summary>
		public string DupeInBag { get { return m_DupeInBag; } set { m_DupeInBag = value; } }

		[Category("Duping"),
		 Description(
			 "Command used to dupe an amount of items. Use {amount} to specify how many times the item will be duped.")]
		/// <summary>
		/// Gets or sets the amount duping command
		/// </summary>
		public string AmountDupe { get { return m_AmountDupe; } set { m_AmountDupe = value; } }

		[Category("Duping"),
		 Description(
			 "Command to dupe an item in its container a given number of times. Use {amount} to specify how many times the item will be duped.")]
		/// <summary>
		/// Gets or sets the amount dupe in bag command
		/// </summary>
		public string AmountDupeInBag { get { return m_AmountDupeInBag; } set { m_AmountDupeInBag = value; } }

		/// <summary>
		///     Performs the dupe command
		/// </summary>
		/// <param name="useamount">States wheter an amount should be specified</param>
		/// <param name="amount">The amount of items to be duped</param>
		public void DoDupe(bool useamount, int amount)
		{
			var cmd = useamount ? m_AmountDupe.Replace("{amount}", amount.ToString()) : m_Dupe;

			Pandora.SendToUO(cmd, true);
		}

		/// <summary>
		///     Performs the dupe in bag command
		/// </summary>
		/// <param name="useamount">States wheter an amount should be specified</param>
		/// <param name="amount">The amount of items to be duped</param>
		public void DoDupeInBag(bool useamount, int amount)
		{
			var cmd = useamount ? m_AmountDupeInBag.Replace("{amount}", amount.ToString()) : m_DupeInBag;

			Pandora.SendToUO(cmd, true);
		}
		#endregion

		#region Light
		private string m_LocalLight = "Light {level}";
		private string m_GlobalLight = "GlobalLight {level}";

		[Category("Light"), Description("Sets your local light level. Use {level} to specify the light amount.")]
		/// <summary>
		/// Gets or sets the local light level
		/// </summary>
		public string LocalLight { get { return m_LocalLight; } set { m_LocalLight = value; } }

		[Category("Light"), Description("Sets the global light level. Use {level} to specify the light amount.")]
		/// <summary>
		/// Gets or sets the global light level
		/// </summary>
		public string GlobalLight { get { return m_GlobalLight; } set { m_GlobalLight = value; } }

		/// <summary>
		///     Sends the local light command
		/// </summary>
		/// <param name="amount">The light level</param>
		public void DoLocalLight(int amount)
		{
			var cmd = m_LocalLight.Replace("{level}", amount.ToString());
			Pandora.SendToUO(cmd, true);
		}

		/// <summary>
		///     Sends the global light command
		/// </summary>
		/// <param name="amount">The light level</param>
		public void DoGlobalLight(int amount)
		{
			var cmd = m_GlobalLight.Replace("{level}", amount.ToString());
			Pandora.SendToUO(cmd, true);
		}
		#endregion

		#region Speech and Sound
		private string m_Tell = "Tell {text}";
		private string m_StaffMessage = "SMsg {text}";
		private string m_Broadcast = "BCast {text}";
		private string m_PrivSound = "PrivSound {sound}";
		private string m_Sound = "Sound {sound}";

		[Category("Speech and Sound"), Description("Sends a message to a player. Use {text} to specify the message.")]
		/// <summary>
		/// Gets or sets the Tell command
		/// </summary>
		public string Tell { get { return m_Tell; } set { m_Tell = value; } }

		[Category("Speech and Sound"), Description("Sends a message to all staff. Use {text} to specify the message.")]
		/// <summary>
		/// Gets or sets the staff message command
		/// </summary>
		public string StaffMessage { get { return m_StaffMessage; } set { m_StaffMessage = value; } }

		[Category("Speech and Sound"),
		 Description("Broadcasts a message to all online players. Use {text} to specify the message.")]
		/// <summary>
		/// Gets or sets the broadcast command
		/// </summary>
		public string Broadcast { get { return m_Broadcast; } set { m_Broadcast = value; } }

		[Category("Speech and Sound"), Description("Plays a sound to a specified mobile. Use {sound} to specify the sound.")]
		/// <summary>
		/// Gets or sets the PrivSound command
		/// </summary>
		public string PrivSound { get { return m_PrivSound; } set { m_PrivSound = value; } }

		[Category("Speech and Sound"),
		 Description("Plays a sound to all mobiles near you. Use {sound} to specify the sound.")]
		/// <summary>
		/// Gets or sets the Sound command
		/// </summary>
		public string Sound { get { return m_Sound; } set { m_Sound = value; } }

		/// <summary>
		///     Sends the PrivSound command
		/// </summary>
		/// <param name="sound">The sound index to play</param>
		/// <param name="modifier">The command modifier</param>
		public void DoPrivSound(int sound, string modifier)
		{
			var cmd = m_PrivSound.Replace("{sound}", sound.ToString());
			cmd = ApplyModifier(cmd, modifier);
			Pandora.SendToUO(cmd, true);
		}

		/// <summary>
		///     Sends the Sound command
		/// </summary>
		/// <param name="sound">The sound index to play</param>
		public void DoSound(int sound)
		{
			var cmd = m_Sound.Replace("{sound}", sound.ToString());
			Pandora.SendToUO(cmd, true);
		}

		/// <summary>
		///     Performs the Tell command
		/// </summary>
		/// <param name="text">The message to send</param>
		/// <param name="modifier">The modifier for the command</param>
		public void DoTell(string text, string modifier)
		{
			var cmd = m_Tell.Replace("{text}", text);
			cmd = ApplyModifier(cmd, modifier);
			Pandora.SendToUO(cmd, true);
		}

		/// <summary>
		///     Broadcasts a message to staff only
		/// </summary>
		/// <param name="text">The message text</param>
		public void DoStaffMessage(string text)
		{
			var cmd = m_StaffMessage.Replace("{text}", text);
			Pandora.SendToUO(cmd, true);
		}

		/// <summary>
		///     Broadcasts a message
		/// </summary>
		/// <param name="text">The message text</param>
		public void DoBroadcast(string text)
		{
			var cmd = m_Broadcast.Replace("{text}", text);
			Pandora.SendToUO(cmd, true);
		}
		#endregion
	}
}