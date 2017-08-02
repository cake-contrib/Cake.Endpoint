namespace Cake.Endpoint.Model
{
	/// <summary>
	/// Repesenting an endpoint that contains source / target mappings
	/// </summary>
	public class Endpoint
	{
		/// <summary>
		/// Gets or sets a list of directory copy statements.
		/// </summary>
		/// <value>
		///   Collection of copy statements that will be copied by the endpoint creator.
		/// </value>
		public Directory[] Directories { get; set; }

		/// <summary>
		/// Gets or sets a list of file copy statements
		/// </summary>
		/// <value>
		///   Collection of copy statements that will be copied by the endpoint creator.
		/// </value>
		public File[] Files { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the Id of an endpoint.
		/// The Id is used for the relative target directory.
		/// </summary>
		/// <value>
		///   A string representing the endpoint.
		/// </value>
		public string Id { get; set; }
	}
}
