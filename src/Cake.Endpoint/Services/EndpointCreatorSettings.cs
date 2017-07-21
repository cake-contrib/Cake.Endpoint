namespace Cake.Endpoint.Services
{
	/// <summary>
	/// Settings that will be forwarded to the enpoint creator.
	/// </summary>
	public class EndpointCreatorSettings
	{
		/// <summary>
		/// Build configuration. Can be used inside copy statements as [BuildConfiguration] pattern.
		/// </summary>
		public string BuildConfiguration { get; set; }

		/// <summary>
		/// Add information to the endpoint id that will be the target directory name.
		/// </summary>
		public string TargetPathPostFix { get; set; }

		/// <summary>
		/// The parent path where the endpoints will be created. Defaults to <c>./</c>
		/// </summary>
		public string TargetRootPath { get; set; }

		/// <summary>
		/// Tell the endpoint creator to zip the resulting endpoints. Defaults to <c>false</c>
		/// </summary>
		public bool ZipTargetPath { get; set; }
	}
}
