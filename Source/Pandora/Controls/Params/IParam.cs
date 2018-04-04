#region Header
// /*
//  *    2018 - Pandora - IParam.cs
//  */
#endregion

namespace TheBox.Controls.Params
{
	/// <summary>
	///     Provides an interface for the parameter panels
	/// </summary>
	public interface IParam
	{
		/// <summary>
		///     Sets the name of the parameter
		/// </summary>
		string ParamName { set; }

		/// <summary>
		///     Gets the value set by the user
		/// </summary>
		string Value { get; }

		/// <summary>
		///     States whether the panel has a defined value
		/// </summary>
		bool IsDefined { get; }
	}
}