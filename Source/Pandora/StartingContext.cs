#region Header
// /*
//  *    2018 - Pandora - StartingContext.cs
//  */
#endregion

#region References
using System;
using System.Windows.Forms;

using LightCore;

using TheBox.Common;
using TheBox.Forms;
using TheBox.Forms.ProfileWizard;
using TheBox.Options;
#endregion

// Issue 28:  	 Refactoring Pandora.cs - Tarion
namespace TheBox
{
	/// <summary>
	///     The class dealing with the Pandora's startup
	/// </summary>
	public class StartingContext : ApplicationContext
	{
		private readonly ProfileManager _profileManager;
		private readonly ISplash _splash;
		private readonly IContainer _container;

		public StartingContext(IContainer container, ProfileManager profileManager, ISplash splash)
		{
			_container = container;
			_splash = splash;
			_profileManager = profileManager;

			if (_profileManager.ProfileLoaded)
			{
				Pandora.Log.WriteEntry("Import startup initiated");
				LoadProfile(_profileManager.Profile.Name);
			}
			else
			{
				Pandora.Log.WriteEntry("Normal startup initiated");

				// Move on with normal startup
				var proc = Pandora.ExistingInstance;
				if (proc != null) // Single instance check
				{
					Pandora.Log.WriteError(null, "Double instance detected");
					_ = MessageBox.Show("You can't run two instances of Pandora's Box at the same time");
					//  Issue 33:  	 Bring to front if already started - Tarion
					ProcessExtension.BringToFront(proc);
				}
				else
				{
					Pandora.Log.WriteEntry("Double instances check passed");
					DoProfile();
				}
			}
		}

		/// <summary>
		///     Called when we need a profile. Do one of the following:
		///     - Load the default profile
		///     - Show dialog to select a profile
		///     - Show dialog to create a profile
		///     Only public because of the bad implemented restart funktion in pandora.cs
		/// </summary>
		private void DoProfile()
		{
			if (_profileManager.DefaultProfile != null)
			{
				_splash.SetStatusText("Loading default profile");
				LoadProfile(_profileManager.DefaultProfile);
			}
			else
			{
				// No default profile specified. Either choose one or create a new one
				if (_profileManager.ProfileNames.Length == 0)
				{
					MakeNewProfile();
				}
				else
				{
					ChooseProfile();
				}
			}
		}

		/// <summary>
		///     Brings up a dialog that will create a new user profile
		/// </summary>
		private void MakeNewProfile()
		{
			_splash.SetStatusText("Creating new profile");

			var languageSelector = _container.Resolve<ILanguageSelector>();
			MainForm = languageSelector as Form;
			MainForm.Show();
		}

		/// <summary>
		///     Brings up the choose profile dialog
		/// </summary>
		/// <param name="profiles">A list of possible profile names. p.e. ProfileManager.ProfileNames</param>
		private void ChooseProfile()
		{
			_splash.SetStatusText("Profile selection");

			var profileChooser = _container.Resolve<IProfileChooser>();
			MainForm = profileChooser as Form;
			MainForm.Show();
		}

		/// <summary>
		///     Loads a profile
		///     Should be part of the profile manager and need a return value
		/// </summary>
		/// <param name="name">The name of the profile</param>
		private void LoadProfile(string name)
		{
			_splash.SetStatusText("Loading profile");

			try
			{
				_profileManager.LoadProfile(name);
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Couldn't load profile {0}", name);

				if (name == _profileManager.DefaultProfile)
				{
					_profileManager.DefaultProfile = "";
				}

				DoProfile();
				return;
			}

			if (_profileManager.Profile == null)
			{
				var msg = String.Format(
					"The profile {0} is corrupt, therefore it can't be loaded. Would you like to attempt to restore it?",
					name);

				if (MessageBox.Show(null, msg, "Profile Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					var p = new Profile
					{
						Name = name
					};
					p.Save();
					LoadProfile(name);
				}
				else
				{
					DoProfile();
				}

				return;
			}

			try
			{
				// To Test show the new form
				/* 
				// Should be handled through the LightCoreBuilder
				// Uncomment to get a first preview of the new form
				BoxForm newBoxForm = new BoxForm();
				Pandora.Localization.LocalizeControl(_newBoxForm);
				newBoxForm.Show();
				*/

				var boxForm = _container.Resolve<IBoxForm>();
				Pandora.BoxForm = boxForm;
				MainForm = boxForm as Form;
				MainForm.Show();
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, String.Format("Profile {0} failed.", name));
				// Issue 6:  	 Improve error management - Tarion
				// Application.Exit(); Did not worked correctly
				// We could use:  Environment.Exit(1);
				// But better forward the exception to the main function an cancel program there
				throw err;
				// End Issue 6
			}
		}

		protected override void OnMainFormClosed(object sender, EventArgs e)
		{
			// Action was NEW PROFILE: check if valid, if not exit
			if (sender is LanguageSelector)
			{
				if (_profileManager.Profile != null) // Profile creation succesful
				{
					var boxForm = _container.Resolve<IBoxForm>();
					Pandora.BoxForm = boxForm;
					MainForm = boxForm as Form;
					MainForm.Show();
					return;
				}
				Pandora.Log.WriteError(null, "Profile creation aborted");
			}

			// PROFILE CHOOSER: exit/new profile/load profile
			if (sender is ProfileChooser)
			{
				var chooser = sender as ProfileChooser;

				switch (chooser.Action)
				{
					case ProfileChooser.Actions.Exit:
						break;
					case ProfileChooser.Actions.LoadProfile:
						if (chooser.UseDefault)
						{
							_profileManager.DefaultProfile = chooser.SelectedProfile;
						}
						LoadProfile(chooser.SelectedProfile);
						return;
					case ProfileChooser.Actions.MakeNewProfile:
						MakeNewProfile();
						return;
				}
			}

			if (sender is IBoxForm)
			{
				var next = (sender as IBoxForm).NextProfile;

				if (next != null)
				{
					LoadProfile(next);
					return;
				}
			}

			base.OnMainFormClosed(sender, e);
		}
	}
}