namespace Cake.Endpoint.Model
{
	/// <summary>
	/// Represents a file copy statement.
	/// </summary>
	public class File
	{
		/// <summary>
		/// Source file path.
		/// </summary>
		public string SourcePath { get; set; }

		/// <summary>
		/// Target file path.
		/// </summary>
		public string TargetPath { get; set; }
	}
}
