using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Endpoint.Services;

namespace Cake.Endpoint
{
	/// <summary>
	/// Collection of Cake.Endpoint aliases that will be injected into the cake context.
	/// </summary>
	[CakeAliasCategory( "Endpoint" )]
	public static class EndpointAliases
	{
		/// <summary>
		/// Creates endpoints by copying all files and directories accoring to the endpoint definition.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="endpoints">Required. Endpoint list defining all files and directories.</param>
		/// <example>
		/// <para>Cake task:</para>
		/// <code>
		/// <![CDATA[
		/// Task("Create")
		///     .Does(() =>
		/// {
		///     var endpoints = DeserializeJsonFromFile<IEnumerable<Endpoint>>( "./endpoints.json" );
		///     EndpointCreate( endpoints );
		/// });
		/// ]]>
		/// </code>
		/// </example>
		[CakeMethodAlias]
		[CakeNamespaceImport( "Cake.Endpoint.Model" )]
		public static void EndpointCreate( this ICakeContext context,
			IEnumerable<Model.Endpoint> endpoints )
		{
			if( context == null )
				throw new ArgumentNullException( nameof(context) );

			if( endpoints == null )
				throw new ArgumentNullException( nameof(endpoints) );

			new EndpointCreator( context,
				context.FileSystem,
				context.Environment,
				context.Log ).Create( endpoints );
		}

		/// <summary>
		/// Creates endpoints by copying all files and directories accoring to the endpoint definition.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="endpoints">Required. Endpoint list defining all files and directories.</param>
		/// <param name="settings">Required. Settings holding additional information when creating endpoints.</param>
		/// <example>
		/// <para>Cake task:</para>
		/// <code>
		/// <![CDATA[
		/// Task("Create")
		///     .Does(() =>
		/// {
		///     var endpoints = DeserializeJsonFromFile<IEnumerable<Endpoint>>( "./endpoints.json" );
		///     EndpointCreate( endpoints, new EndpointCreatorSettings
		///     {
		///       ZipTargetPath = true
		///     } );
		/// });
		/// ]]>
		/// </code>
		/// </example>
		[CakeMethodAlias]
		[CakeNamespaceImport( "Cake.Endpoint.Model" )]
		[CakeNamespaceImport( "Cake.Endpoint.Services" )]
		public static void EndpointCreate( this ICakeContext context,
			IEnumerable<Model.Endpoint> endpoints,
			EndpointCreatorSettings settings )
		{
			if( context == null )
				throw new ArgumentNullException( nameof(context) );

			if( endpoints == null )
				throw new ArgumentNullException( nameof(endpoints) );

			if( settings == null )
				throw new ArgumentNullException( nameof(settings) );

			new EndpointCreator( context,
				context.FileSystem,
				context.Environment,
				context.Log ).Create( endpoints, settings );
		}
	}
}
