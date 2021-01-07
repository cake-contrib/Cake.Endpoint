using System.Collections.Generic;

namespace Cake.Endpoint.Model
{
	/// <summary>
	/// Represents a service id.
	/// </summary>
	public class ServiceId
	{
		/// <summary>
		/// Gets or sets the service id.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the required resources.
		/// </summary>
		public List<string> Resources { get; set; }
	}
}
