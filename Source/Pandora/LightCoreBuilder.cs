#region Header
// /*
//  *    2018 - Pandora - LightCoreBuilder.cs
//  */
#endregion

#region References
using LightCore;
using LightCore.Lifecycle;

using TheBox.Common;
using TheBox.Forms;
using TheBox.Forms.ProfileWizard;
#endregion

namespace TheBox
{
	public class LightCoreBuilder
	{
		public IContainer BuildContainer()
		{
			var builder = new ContainerBuilder();

			builder.Register<ProfileManager>().ControlledBy<SingletonLifecycle>();
			builder.Register<StartingContext>().ControlledBy<SingletonLifecycle>();

			// GUI
			builder.Register<ISplash, Splash>().ControlledBy<SingletonLifecycle>();
			builder.Register<ILanguageSelector, LanguageSelector>();
			builder.Register<IProfileChooser, ProfileChooser>();
			builder.Register<IBoxForm, Box>();

			return builder.Build();
		}
	}
}