namespace Cake.Endpoint.Model
{
	/// <summary>
	/// Representing a directory copy statement
	/// </summary>
	public class Directory
	{
		/// <summary>
		/// Source directory path
		/// </summary>
		public string SourcePath { get; set; }

		/// <summary>
		/// Target directory path
		/// </summary>
		public string TargetPath { get; set; }
	}
}
