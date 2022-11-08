namespace Ultima
{
	public class WindowProcessStream : ProcessStream
	{
		private ClientProcessHandle m_ProcessID;

		public ClientWindowHandle Window { get; set; }

		public WindowProcessStream(ClientWindowHandle window)
		{
			Window = window;
			m_ProcessID = ClientProcessHandle.Invalid;
		}

		public override ClientProcessHandle ProcessID
		{
			get
			{
				if (NativeMethods.IsWindow(Window) != 0 && !m_ProcessID.IsInvalid)
				{
					return m_ProcessID;
				}

				_ = NativeMethods.GetWindowThreadProcessId(Window, ref m_ProcessID);

				return m_ProcessID;
			}
		}
	}
}