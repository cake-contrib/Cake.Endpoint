namespace Cake.Endpoint.Model
{
	/// <summary>
	/// Repesenting an endpoint that contains source / target mappings
	/// </summary>
	public class Endpoint
	{
		/// <summary>
		/// List of directory copy statements.
		/// </summary>
		public Directory[] Directories { get; set; }

		/// <summary>
		/// List of file copy statements.
		/// </summary>
		public File[] Files { get; set; }

		/// <summary>
		/// Id of endpoint, used for the target directory.
		/// </summary>
		public string Id { get; set; }
	}
}
