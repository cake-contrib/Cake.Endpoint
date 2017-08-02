namespace Cake.Endpoint.Services
{
	/// <summary>
	/// Settings that will be forwarded to the enpoint creator.
	/// </summary>
	public class EndpointCreatorSettings
	{
		/// <summary>
		/// Gets or sets a value used as a replacement inside the parsed endpoints file. Value
		/// will be injected as a replacement for every found <c>[BuildConfiguration]</c> pattern.
		/// </summary>
		/// <value>
		///   A string that will be injected into the parsed endpoints file; otherwise, <c>null</c>.
		/// </value>
		public string BuildConfiguration { get; set; }

		/// <summary>
		/// Gets or sets a value used as postfix in the final target directory name.
		/// </summary>
		/// <value>
		///   A string that will be used as postfix; otherwise, <c>null</c>.
		/// </value>
		public string TargetPathPostFix { get; set; }

		/// <summary>
		/// Gets or sets the parent path where the endpoints will be created.
		/// </summary>
		/// <value>
		///   A string that will be used as target directory; defaults to <c>./</c>
		/// </value>
		public string TargetRootPath { get; set; }

		/// <summary>
		/// Gets or sets a value indicating that the copied files and directories should be
		/// zipped.
		/// </summary>
		/// <value>
		///   <c>true</c> to zip the resulting output directories; otherwise, <c>false</c>.
		/// </value>
		public bool ZipTargetPath { get; set; }
	}
}
