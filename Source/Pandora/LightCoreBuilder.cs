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

			_ = builder.Register<ProfileManager>().ControlledBy<SingletonLifecycle>();
			_ = builder.Register<StartingContext>().ControlledBy<SingletonLifecycle>();

			// GUI
			_ = builder.Register<ISplash, Splash>().ControlledBy<SingletonLifecycle>();
			_ = builder.Register<ILanguageSelector, LanguageSelector>();
			_ = builder.Register<IProfileChooser, ProfileChooser>();
			_ = builder.Register<IBoxForm, Box>();

			return builder.Build();
		}
	}
}