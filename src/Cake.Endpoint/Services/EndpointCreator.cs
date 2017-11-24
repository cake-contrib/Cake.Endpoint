using System;
using System.Collections.Generic;
using Cake.Common.IO;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Endpoint.Model;

namespace Cake.Endpoint.Services
{
	internal class EndpointCreator
	{
		private readonly ICakeContext context;
		private readonly ICakeEnvironment environment;
		private readonly IFileSystem fileSystem;
		private readonly ICakeLog log;

		public EndpointCreator( ICakeContext context,
			IFileSystem fileSystem,
			ICakeEnvironment environment,
			ICakeLog log )
		{
			this.context = context;
			this.fileSystem = fileSystem;
			this.environment = environment;
			this.log = log;
		}

		public void Create( IEnumerable<Model.Endpoint> endpoints )
		{
			Create( endpoints, null );
		}

		public void Create( IEnumerable<Model.Endpoint> endpoints, EndpointCreatorSettings settings )
		{
			if( endpoints == null )
				throw new ArgumentNullException( nameof(endpoints) );

			foreach( Model.Endpoint endpoint in endpoints )
				CreateSingle( endpoint, settings );
		}

		private void CreateSingle( Model.Endpoint endpoint, EndpointCreatorSettings settings )
		{
			DirectoryPath targetRootPath = new DirectoryPath( settings?.TargetRootPath ?? "./" ).MakeAbsolute( environment );

			string targetEndpointPathName = endpoint.Id + settings?.TargetPathPostFix;

			DirectoryPath targetEndpointPath = targetRootPath.Combine( targetEndpointPathName );

			if( endpoint.Files != null )
			{
				foreach( File file in endpoint.Files )
				{
					string fileSourcePath = file.SourcePath;
					if( !string.IsNullOrWhiteSpace( settings?.BuildConfiguration ) )
						fileSourcePath = fileSourcePath.Replace( "[BuildConfiguration]", settings.BuildConfiguration );

					if( file.IsFilePath )
					{
						FilePath targetPath = targetEndpointPath.CombineWithFilePath( file.TargetPath );
						context.EnsureDirectoryExists( targetPath.GetDirectory() );
						context.CopyFile( file.SourcePath, targetPath );
					}
					else
					{
						DirectoryPath targetPath = targetEndpointPath.Combine( file.TargetPath );
						context.EnsureDirectoryExists( targetPath );
						context.CopyFileToDirectory( fileSourcePath, targetPath );
					}
				}
			}

			if( endpoint.Directories != null )
			{
				foreach( Directory directory in endpoint.Directories )
				{
					DirectoryPath targetDirectoryPath = targetEndpointPath.Combine( directory.TargetPath );
					context.EnsureDirectoryExists( targetDirectoryPath );

					string directorySourcePath = directory.SourcePath;
					if( !string.IsNullOrWhiteSpace( settings?.BuildConfiguration ) )
						directorySourcePath = directorySourcePath.Replace( "[BuildConfiguration]", settings.BuildConfiguration );

					if( context.DirectoryExists( directorySourcePath ) )
						context.CopyDirectory( directorySourcePath, targetDirectoryPath );
					else
						log.Warning( $"Skipped copying {directorySourcePath} because it does not exist." );
				}
			}

			log.Information( $"Created endpoint at {targetEndpointPath.FullPath}" );

			if( settings != null && settings.ZipTargetPath )
			{
				FilePath zipFilePath = targetRootPath.CombineWithFilePath( new FilePath( targetEndpointPathName + ".zip" ) );
				new Zipper( fileSystem, environment, log ).Zip( targetEndpointPath,
					zipFilePath,
					context.GetFiles( string.Concat( targetEndpointPath, "/**/*" ) ) );

				log.Information( $"Zipped endpoint at {zipFilePath.FullPath}" );
			}
		}
	}
}
