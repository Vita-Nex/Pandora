#region Header
// /*
//  *    2018 - Pandora - ButtonDef.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using TheBox.Common;
#endregion

namespace TheBox.Buttons
{
	[Serializable]
	[XmlInclude(typeof(LastCommand))]
	[XmlInclude(typeof(MenuCommand))]
	[XmlInclude(typeof(MenuDef))]
	[XmlInclude(typeof(MultiCommandDef))]
	[XmlInclude(typeof(GenericNode))]
	[XmlInclude(typeof(ModifierCommand))]
	/// <summary>
	/// Defines the behaviour of a BoxButton
	/// </summary>
	public class ButtonDef : IDisposable, ICloneable
	{
		private IButtonFunction m_Left;
		private IButtonFunction m_Right;
		private string m_Caption = "";
		private SendCommandEventArgs m_LastCommand;

		/// <summary>
		///     Occurs when the tool tip text changes
		/// </summary>
		public event ToolTipChangedEventHandler ToolTipChanged;

		protected virtual void OnToolTipChanged(ToolTipEventArgs e)
		{
			ToolTipChanged?.Invoke(this, e);
		}

		[XmlIgnore]
		/// <summary>
		/// Gets or sets the action performed by the left button
		/// </summary>
		public IButtonFunction Left
		{
			get => m_Left;
			set
			{
				if (value == m_Left)
				{
					return;
				}

				if (m_Left != null)
				{
					if (m_Left is IDisposable d)
					{
						d.Dispose();
					}
				}

				m_Left = value;

				if (m_Left != null)
				{
					m_Left.CommandChanged += OnCommandChanged;
					m_Left.SendCommand += OnChildSendCommand;
					m_Left.SendLastCommand += SendLastCommand;
				}

				UpdateToolTip();
			}
		}

		[XmlIgnore]
		/// <summary>
		/// Gets or sets the action performed by the right button
		/// </summary>
		public IButtonFunction Right
		{
			get => m_Right;
			set
			{
				if (value == m_Right)
				{
					return;
				}

				if (m_Right != null)
				{
					if (m_Right is IDisposable d)
					{
						d.Dispose();
					}
				}

				m_Right = value;

				if (m_Right != null)
				{
					m_Right.CommandChanged += OnCommandChanged;
					m_Right.SendCommand += OnChildSendCommand;
					m_Right.SendLastCommand += SendLastCommand;
				}

				UpdateToolTip();
			}
		}

		/// <summary>
		///     Gets or sets the object assigned to the right button
		/// </summary>
		public object RightObject { get => m_Right; set => Right = value as IButtonFunction; }

		/// <summary>
		///     Gets or sets the object assigned to the left button
		/// </summary>
		public object LeftObject { get => m_Left; set => Left = value as IButtonFunction; }

		protected void SendLastCommand(object sender, EventArgs e)
		{
			if (m_LastCommand != null)
			{
				OnSendCommand(m_LastCommand);
			}
		}

		protected void OnChildSendCommand(object sender, SendCommandEventArgs e)
		{
			m_LastCommand = e;
			OnSendCommand(e);

			UpdateToolTip();
		}

		protected void OnCommandChanged(object sender, CommandChangedEventArgs e)
		{
			m_Caption = e.Command.Caption;

			OnCaptionChanged(new EventArgs());

			UpdateToolTip();
		}

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the current button caption
		/// </summary>
		public string Caption
		{
			get
			{
				if (m_Left is MultiCommandDef)
				{
					return (m_Left as MultiCommandDef).DefaultCommand.Caption;
				}

				if (m_Right is MultiCommandDef)
				{
					return (m_Right as MultiCommandDef).DefaultCommand.Caption;
				}

				if (m_Left == null && m_Right == null)
				{
					return String.Empty;
				}

				return m_Caption;
			}
			set
			{
				m_Caption = value;
				OnCaptionChanged(new EventArgs());
			}
		}

		/// <summary>
		///     Occurs when the caption of the button should change
		/// </summary>
		public event EventHandler CaptionChanged;

		protected virtual void OnCaptionChanged(EventArgs e)
		{
			CaptionChanged?.Invoke(this, e);
		}

		/// <summary>
		///     Occurs when the button must send a command
		/// </summary>
		public event SendCommandEventHandler SendCommand;

		protected virtual void OnSendCommand(SendCommandEventArgs e)
		{
			SendCommand?.Invoke(this, e);
		}

		/// <summary>
		///     Executes the action specified for this button
		/// </summary>
		/// <param name="button">The BoxButton that owns this MenuDef object</param>
		/// <param name="clickPoint">The location of the click</param>
		/// <param name="mouseButton">The mouse button clicked</param>
		public void DoAction(BoxButton button, Point clickPoint, MouseButtons mouseButton)
		{
			switch (mouseButton)
			{
				case MouseButtons.Left:

					if (m_Left != null)
					{
						m_Left.DoAction(button, clickPoint, mouseButton);
					}
					else if (m_Right != null && !m_Right.AllowsSecondButton)
					{
						m_Right.DoAction(button, clickPoint, mouseButton);
					}
					break;

				case MouseButtons.Right:

					if (m_Right != null)
					{
						m_Right.DoAction(button, clickPoint, mouseButton);
					}
					else if (m_Left != null && !m_Left.AllowsSecondButton)
					{
						m_Left.DoAction(button, clickPoint, mouseButton);
					}
					break;
			}
		}

		/// <summary>
		///     Verifies if adding an item as left button will function properly
		/// </summary>
		/// <param name="left">The left button candidate</param>
		/// <returns>True if the combination is valid, false otherwise</returns>
		public bool TryLeft(IButtonFunction left)
		{
			if (m_Right == null)
			{
				if (left.RequiresSecondButton)
				{
					return false;
				}

				return true;
			}
			if (m_Right.AllowsSecondButton && left.AllowsSecondButton)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		///     Verifies if adding an item as right button will function properly
		/// </summary>
		/// <param name="right">The right button candidate</param>
		/// <returns>True if the combination is valid, false otherwise</returns>
		public bool TryRight(IButtonFunction right)
		{
			if (m_Left == null)
			{
				if (right.RequiresSecondButton)
				{
					return false;
				}

				return true;
			}
			if (m_Left.AllowsSecondButton && right.AllowsSecondButton)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		///     Saves the ButtonDef object to an xml file
		/// </summary>
		/// <param name="FileName">The target filename for this</param>
		/// <returns>True if succesful, false otherwise</returns>
		public bool Save(string FileName)
		{
			try
			{
				var serializer = new XmlSerializer(typeof(ButtonDef));

				var stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);

				serializer.Serialize(stream, this);

				stream.Close();

				Pandora.Log.WriteEntry(String.Format("Custom button definition serizlized correctly to {0}", FileName));
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, String.Format("Failed to serialize custom button definition to: {0}", FileName));
				return false;
			}

			return true;
		}

		/// <summary>
		///     Loads a ButtonDef from an xml file
		/// </summary>
		/// <param name="FileName">The file to read the definition from</param>
		/// <returns>A ButtonDef object read from the XML</returns>
		public static ButtonDef Load(string FileName)
		{
			try
			{
				var serializer = new XmlSerializer(typeof(ButtonDef));

				var stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

				var def = serializer.Deserialize(stream) as ButtonDef;

				Pandora.Log.WriteEntry(String.Format("Succesfully deserialized button from: {0}", FileName));

				return def;
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, String.Format("Failed to read custom button from: {0}", FileName));
				return null;
			}
		}

		/// <summary>
		///     Gets a MultiCommandDef object if there is one assigned. Returns null is none is found
		/// </summary>
		public MultiCommandDef MultiDef
		{
			get
			{
				if (m_Left != null && m_Left is MultiCommandDef)
				{
					return m_Left as MultiCommandDef;
				}

				if (m_Right != null && m_Right is MultiCommandDef)
				{
					return m_Right as MultiCommandDef;
				}

				return null;
			}
		}

		/// <summary>
		///     Gets a ModifierCommand def if there is one assigned on this button
		/// </summary>
		public ModifierCommand ModifierDef
		{
			get
			{
				if (m_Left != null && m_Left is ModifierCommand)
				{
					return m_Left as ModifierCommand;
				}

				if (m_Right != null && m_Right is ModifierCommand)
				{
					return m_Right as ModifierCommand;
				}

				return null;
			}
		}

		/// <summary>
		///     Gets a description performed by possible actions
		/// </summary>
		/// <param name="function">The IButtonFunction action to evaluate</param>
		/// <returns>A string describing the action, null if not found</returns>
		private string GetButtonAction(IButtonFunction function)
		{
			if (function is MenuCommand)
			{
				var mc = function as MenuCommand;

				return mc.FullCommand;
			}
			if (function is LastCommand)
			{
				if (m_LastCommand != null)
				{
					return m_LastCommand.FullCommand;
				}

				return null;
			}
			if (function is MenuDef)
			{
				return Pandora.Localization.TextProvider["Buttons.MenuDesc"];
			}

			return null;
		}

		/// <summary>
		///     Gets a string representing the tool tip for the button
		/// </summary>
		public string ToolTipText
		{
			get
			{
				if (ModifierDef != null)
				{
					var left = String.Format(Pandora.Localization.TextProvider["Buttons.TipLeft"], ModifierDef.Command);
					var right = String.Format(
						Pandora.Localization.TextProvider["Buttons.TipRight"],
						Pandora.Localization.TextProvider["Buttons.ModRight"]);

					return String.Format(Pandora.Localization.TextProvider["Buttons.TipTwoLine"], left, right);
				}
				if (MultiDef == null)
				{
					string left = null;
					string right = null;

					if (m_Left != null)
					{
						left = GetButtonAction(m_Left);
					}

					if (m_Right != null)
					{
						right = GetButtonAction(m_Right);
					}

					if (left != null && right != null)
					{
						var l = String.Format(Pandora.Localization.TextProvider["Buttons.TipLeft"], left);
						var r = String.Format(Pandora.Localization.TextProvider["Buttons.TipRight"], right);

						return String.Format(Pandora.Localization.TextProvider["Buttons.TipTwoLine"], l, r);
					}
					if (left != null)
					{
						return String.Format(Pandora.Localization.TextProvider["Buttons.TipLeft"], left);
					}
					if (right != null)
					{
						return String.Format(Pandora.Localization.TextProvider["Buttons.TipRight"], right);
					}

					return null;
				}
				else
				{
					// This is a multi def

					var left = String.Format(
						Pandora.Localization.TextProvider["Buttons.TipLeft"],
						MultiDef.DefaultCommand.FullCommand);
					var right = String.Format(
						Pandora.Localization.TextProvider["Buttons.TipRight"],
						Pandora.Localization.TextProvider["Buttons.MultiRightClick"]);

					return String.Format(Pandora.Localization.TextProvider["Buttons.TipTwoLine"], left, right);
				}
			}
		}

		private void UpdateToolTip()
		{
			OnToolTipChanged(new ToolTipEventArgs(ToolTipText));
		}

		[XmlIgnore]
		/// <summary>
		/// Gets the command callback for modifiers buttons
		/// </summary>
		public CommandCallback CommandCallback
		{
			get
			{
				if (m_Left != null && m_Left is ModifierCommand)
				{
					return (m_Left as ModifierCommand).CommandCallback;
				}
				if (m_Right != null && m_Right is ModifierCommand)
				{
					return (m_Right as ModifierCommand).CommandCallback;
				}
				return null;
			}
		}

		#region IDisposable Members
		public void Dispose()
		{
			if (m_Left is IDisposable)
			{
				(m_Left as IDisposable).Dispose();
			}

			if (m_Right is IDisposable)
			{
				(m_Right as IDisposable).Dispose();
			}
		}
		#endregion

		#region ICloneable Members
		public object Clone()
		{
			var def = new ButtonDef();

			if (m_Caption != null)
			{
				def.m_Caption = String.Copy(m_Caption);
			}

			if (m_LastCommand != null)
			{
				def.m_LastCommand = new SendCommandEventArgs(m_LastCommand.Command, m_LastCommand.UsePrefix);
			}

			if (m_Left != null)
			{
				def.Left = (m_Left as ICloneable).Clone() as IButtonFunction;
			}

			if (m_Right != null)
			{
				def.Right = (m_Right as ICloneable).Clone() as IButtonFunction;
			}

			return def;
		}
		#endregion
	}
}