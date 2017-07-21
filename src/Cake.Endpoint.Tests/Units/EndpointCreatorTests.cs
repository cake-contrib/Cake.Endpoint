using System;
using Cake.Endpoint.Model;
using Cake.Endpoint.Services;
using Cake.Endpoint.Tests.Fixtures;
using Cake.Testing;
using Xunit;

namespace Cake.Endpoint.Tests.Units
{
	public class EndpointCreatorTests
	{
		[Fact]
		public void Create_BuildConfigurationDefined_SubstitutesSourcePaths()
		{
			var fixture = new EndpointCreatorFixture( new[]
			{
				new Model.Endpoint
				{
					Id = "SomeEndpoint",
					Directories = new[]
					{
						new Directory
						{
							SourcePath = "Source/[BuildConfiguration]",
							TargetPath = "Target/Subtarget1/"
						},
						new Directory
						{
							SourcePath = "Source/Sourcedirectory2",
							TargetPath = "Target/Subtarget2/"
						}
					}
				}
			} );

			fixture.FileSystem.CreateDirectory( "/Working/Source" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Release" );
			fixture.FileSystem.CreateFile( "/Working/Source/Release/Sourcefile1.txt" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Sourcedirectory2" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcedirectory2/Sourcefile2.txt" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Sourcedirectory2/Subsourcedirectory" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcedirectory2/Subsourcedirectory/Subsourcefile.txt" );

			EndpointCreatorSettings settings = new EndpointCreatorSettings
			{
				BuildConfiguration = "Release"
			};

			var result = Record.Exception( () => fixture.Run( settings ) );

			Assert.Null( result );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpoint/Target/Subtarget1/Sourcefile1.txt" ).Exists );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpoint/Target/Subtarget2/Sourcefile2.txt" ).Exists );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpoint/Target/Subtarget2/Subsourcedirectory/Subsourcefile.txt" ).Exists );
		}

		[Fact]
		public void Create_DirectoriesAreValid_DirectoriesAreCopied()
		{
			var fixture = new EndpointCreatorFixture( new[]
			{
				new Model.Endpoint
				{
					Id = "SomeEndpoint",
					Directories = new[]
					{
						new Directory
						{
							SourcePath = "Source/Sourcedirectory1",
							TargetPath = "Target/Subtarget1"
						},
						new Directory
						{
							SourcePath = "Source/Sourcedirectory2",
							TargetPath = "Target/Subtarget2"
						}
					}
				}
			} );

			fixture.FileSystem.CreateDirectory( "/Working/Source" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Sourcedirectory1" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcedirectory1/Sourcefile1.txt" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Sourcedirectory2" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcedirectory2/Sourcefile2.txt" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Sourcedirectory2/Subsourcedirectory" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcedirectory2/Subsourcedirectory/Subsourcefile.txt" );

			var result = Record.Exception( () => fixture.Run() );

			Assert.Null( result );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpoint/Target/Subtarget1/Sourcefile1.txt" ).Exists );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpoint/Target/Subtarget2/Sourcefile2.txt" ).Exists );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpoint/Target/Subtarget2/Subsourcedirectory/Subsourcefile.txt" ).Exists );
		}

		[Fact]
		public void Create_EndpointIsNull_ThrowsArgumentNullException()
		{
			var fixture = new EndpointCreatorFixture( null );

			var result = Record.Exception( () => fixture.Run() );

			Assert.IsType<ArgumentNullException>( result );
			Assert.Equal( "endpoints", ( (ArgumentNullException)result ).ParamName );
		}

		[Fact]
		public void Create_FilesAreValid_FilesAreCopied()
		{
			var fixture = new EndpointCreatorFixture( new[]
			{
				new Model.Endpoint
				{
					Id = "SomeEndpoint",
					Files = new[]
					{
						new File
						{
							SourcePath = "Source/Sourcefile1.txt",
							TargetPath = "Target/Subtarget1/"
						},
						new File
						{
							SourcePath = "Source/Sourcefile2.txt",
							TargetPath = "Target/Subtarget2/"
						}
					}
				}
			} );

			fixture.FileSystem.CreateDirectory( "/Working/Source" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcefile1.txt" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcefile2.txt" );

			var result = Record.Exception( () => fixture.Run() );

			Assert.Null( result );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpoint/Target/Subtarget1/sourcefile1.txt" ).Exists );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpoint/Target/Subtarget2/sourcefile2.txt" ).Exists );
		}

		[Fact]
		public void Create_ShouldZip_CreatesZipFile()
		{
			var fixture = new EndpointCreatorFixture( new[]
			{
				new Model.Endpoint
				{
					Id = "SomeEndpoint",
					Directories = new[]
					{
						new Directory
						{
							SourcePath = "Source/Sourcedirectory1",
							TargetPath = "Target/Subtarget1/"
						},
						new Directory
						{
							SourcePath = "Source/Sourcedirectory2",
							TargetPath = "Target/Subtarget2/"
						}
					}
				}
			} );

			fixture.FileSystem.CreateDirectory( "/Working/Source" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Sourcedirectory1" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcedirectory1/Sourcefile1.txt" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Sourcedirectory2" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcedirectory2/Sourcefile2.txt" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Sourcedirectory2/Subsourcedirectory" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcedirectory2/Subsourcedirectory/Subsourcefile.txt" );

			EndpointCreatorSettings settings = new EndpointCreatorSettings
			{
				TargetRootPath = "SomeTargetRootPath"
			};

			var result = Record.Exception( () => fixture.Run( settings ) );

			Assert.Null( result );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeTargetRootPath/SomeEndpoint/Target/Subtarget1/Sourcefile1.txt" ).Exists );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeTargetRootPath/SomeEndpoint/Target/Subtarget2/Sourcefile2.txt" ).Exists );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeTargetRootPath/SomeEndpoint/Target/Subtarget2/Subsourcedirectory/Subsourcefile.txt" ).Exists );
		}

		[Fact]
		public void Create_TargetPathPostFixDefined_TargetPathGetsExtended()
		{
			var fixture = new EndpointCreatorFixture( new[]
			{
				new Model.Endpoint
				{
					Id = "SomeEndpoint",
					Directories = new[]
					{
						new Directory
						{
							SourcePath = "Source/Sourcedirectory1",
							TargetPath = "Target/Subtarget1/"
						},
						new Directory
						{
							SourcePath = "Source/Sourcedirectory2",
							TargetPath = "Target/Subtarget2/"
						}
					}
				}
			} );

			fixture.FileSystem.CreateDirectory( "/Working/Source" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Sourcedirectory1" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcedirectory1/Sourcefile1.txt" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Sourcedirectory2" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcedirectory2/Sourcefile2.txt" );
			fixture.FileSystem.CreateDirectory( "/Working/Source/Sourcedirectory2/Subsourcedirectory" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcedirectory2/Subsourcedirectory/Subsourcefile.txt" );

			EndpointCreatorSettings settings = new EndpointCreatorSettings
			{
				TargetPathPostFix = "SomeTargetPathPostFix"
			};

			var result = Record.Exception( () => fixture.Run( settings ) );

			Assert.Null( result );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpointSomeTargetPathPostFix/Target/Subtarget1/Sourcefile1.txt" ).Exists );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpointSomeTargetPathPostFix/Target/Subtarget2/Sourcefile2.txt" ).Exists );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpointSomeTargetPathPostFix/Target/Subtarget2/Subsourcedirectory/Subsourcefile.txt" ).Exists );
		}

		[Fact]
		public void Create_TargetRootPathDefined_PathGetsExtended()
		{
			var fixture = new EndpointCreatorFixture( new[]
			{
				new Model.Endpoint
				{
					Id = "SomeEndpoint",
					Files = new[]
					{
						new File
						{
							SourcePath = "Source/Sourcefile1.txt",
							TargetPath = "Target/Subtarget1/"
						},
						new File
						{
							SourcePath = "Source/Sourcefile2.txt",
							TargetPath = "Target/Subtarget2/"
						}
					}
				}
			} );

			fixture.FileSystem.CreateDirectory( "/Working/Source" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcefile1.txt" );
			fixture.FileSystem.CreateFile( "/Working/Source/Sourcefile2.txt" );

			EndpointCreatorSettings settings = new EndpointCreatorSettings
			{
				ZipTargetPath = true
			};

			var result = Record.Exception( () => fixture.Run( settings ) );

			Assert.Null( result );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpoint/Target/Subtarget1/sourcefile1.txt" ).Exists );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpoint/Target/Subtarget2/sourcefile2.txt" ).Exists );
			Assert.True( fixture.FileSystem.GetFile( "/Working/SomeEndpoint.zip" ).Exists );
		}
	}
}
