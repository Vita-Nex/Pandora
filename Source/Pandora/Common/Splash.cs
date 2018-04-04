#region Header
// /*
//  *    2018 - Pandora - Splash.cs
//  */
#endregion

#region References
using System.Threading;
using System.Windows.Forms;

using TheBox.Forms;
#endregion

namespace TheBox.Common
{
	/// <summary>
	///     Provides access to the splash screen
	/// </summary>
	public class Splash : ISplash
	{
		private SplashScreen m_Form;
		private Thread m_Thread;

		private void ShowThread()
		{
			m_Form = new SplashScreen();
			Application.Run(m_Form);
		}

		public void Show()
		{
			if (m_Thread != null)
			{
				return;
			}

			m_Thread = new Thread(ShowThread);
			m_Thread.IsBackground = true;
			m_Thread.SetApartmentState(ApartmentState.STA);
			m_Thread.Start();
		}

		public void Close()
		{
			if (m_Thread == null || m_Form == null)
				return;

			try
			{
				m_Form.Invoke(new MethodInvoker(m_Form.Close));
			}
			catch
			{ }

			m_Thread = null;
			m_Form = null;
		}

		public void SetStatusText(string text)
		{
			if (m_Form != null)
			{
				// Issue 1 - CrossThread operation exception - http://code.google.com/p/pandorasbox3/issues/detail?id=1 - Smjert
				// Threadsave for every access see SetActionText - Tarion
				m_Form.SetActionText(text);
				// Issue 1 - End
			}
		}
	}
}