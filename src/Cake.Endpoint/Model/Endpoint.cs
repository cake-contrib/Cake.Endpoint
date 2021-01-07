using System.Collections.Generic;

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

		/// <summary>
		/// Gets or sets a value indicating the name of an endpoint.
		/// </summary>
		/// <value>
		///   A string name of the endpoint.
		/// </value>
		public MlString Name { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the description of an endpoint.
		/// </summary>
		/// <value>
		///   A string description of the endpoint.
		/// </value>
		public MlString Description { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the microservice of an endpoint.
		/// </summary>
		/// <value>
		///   A string microservice of the endpoint.
		/// </value>
		public string Microservice { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the icon url of an endpoint.
		/// </summary>
		/// <value>
		///   A string icon url of the endpoint.
		/// </value>
		public string IconUrl { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the service ids of an endpoint.
		/// </summary>
		/// <value>
		///   A service id list of the endpoint.
		/// </value>
		public List<ServiceId> ServiceIds { get; set; }

		/// <summary>
		/// Gets or sets a list of departments of an endpoint.
		/// </summary>
		/// <value>
		///   A string list departments of the endpoint.
		/// </value>
		public List<MlString> Departments { get; set; }

		/// <summary>
		/// Gets or sets a value indicating that the endpoint should be released.
		/// </summary>
		/// <value>
		///   A boolean representing the fact that the package should be released.
		/// </value>
		public bool CreateRelease { get; set; } = true;
	}
}
