namespace Cake.Endpoint.Model
{
	/// <summary>
	/// Represents a directory copy statement
	/// </summary>
	public class Directory
	{
		/// <summary>
		/// Gets or sets the source directory path
		/// </summary>
		/// <value>
		///   A relative directory path that will be copied to the corresponding <c>TargetPath</c>.
		/// </value>
		public string SourcePath { get; set; }

		/// <summary>
		/// Gets or sets the target directory path
		/// </summary>
		/// <value>
		///   A relative directory path inside the endpoints output path.
		/// </value>
		public string TargetPath { get; set; }
	}
}
