using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Endpoint.Services;
using Cake.Testing;
using NSubstitute;

namespace Cake.Endpoint.Tests.Fixtures
{
	public class EndpointCreatorFixture
	{
		public EndpointCreatorFixture( IEnumerable<Model.Endpoint> endpoints )
		{
			Endpoints = endpoints;
			Environment = new FakeEnvironment( PlatformFamily.Windows ) { WorkingDirectory = "/Working" };
			FileSystem = new FakeFileSystem( Environment );
			Globber = Substitute.For<IGlobber>();
			Log = new FakeLog();
			Arguments = Substitute.For<ICakeArguments>();
			ProcessRunner = Substitute.For<IProcessRunner>();
			Registry = Substitute.For<IRegistry>();
			Tools = Substitute.For<IToolLocator>();
			Context = new CakeContext( FileSystem,
				Environment,
				Globber,
				Log,
				Arguments,
				ProcessRunner,
				Registry,
				Tools,
				Substitute.For<ICakeDataService>(),
				Substitute.For<Core.Configuration.ICakeConfiguration>() );
		}

		public ICakeArguments Arguments { get; set; }

		public ICakeContext Context { get; set; }

		public IEnumerable<Model.Endpoint> Endpoints { get; set; }

		public ICakeEnvironment Environment { get; set; }

		public FakeFileSystem FileSystem { get; set; }

		public IGlobber Globber { get; set; }

		public ICakeLog Log { get; set; }

		public IProcessRunner ProcessRunner { get; set; }

		public IRegistry Registry { get; set; }

		public IToolLocator Tools { get; set; }

		public void Run()
		{
			Context.EndpointCreate( Endpoints );
		}

		public void Run( EndpointCreatorSettings settings )
		{
			Context.EndpointCreate( Endpoints, settings );
		}
	}
}
