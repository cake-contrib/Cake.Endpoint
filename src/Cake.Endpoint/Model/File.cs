namespace Cake.Endpoint.Model
{
	/// <summary>
	/// Represents a file copy statement.
	/// </summary>
	public class File
	{
		/// <summary>
		/// Gets or sets the source file path
		/// </summary>
		/// <value>
		///   A relative file path that will be copied to the corresponding <c>TargetPath</c>.
		/// </value>
		public string SourcePath { get; set; }

		/// <summary>
		/// Gets or sets the target file path
		/// </summary>
		/// <value>
		///   A relative file path inside the endpoints output path.
		/// </value>
		public string TargetPath { get; set; }
	}
}
