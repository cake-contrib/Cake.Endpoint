Usage
=====

In order to use this _Cake_ addin you need to add it to your `build.cake`
file in the following way

```c#
#addin Cake.Endpoint
```

After that the following _Cake_ aliases are available to you.

EndpointCreate
--------------

Copies files and directories defined within endpoint definition.

```c#
Task( "Create" )
  .Does( () =>
{
  EndpointCreate( new Endpoint()[] );
} );
```

Providing an endpoint

An endpoint should be provided within the solution through an
`endpoints.json` file. The file can be deserialized using the _Cake.Json_
addin in following way:

```c#
var endpoint = DeserializeJsonFromFile<Endpoint>( "./endpoint.json" );
```

[Example endpoint file](./docs/Endpoints_example.json)

Development
===========

Just execute the following commands after you have commited your work.

```PowerShell
$> git tag <semver>
$> .\build.ps1 -target pack
$> git push origin master --tags
```

Then publish the resulting `.\Cake.Endpoint.<semver>.nupkg` on
[nuget.org](https://www.nuget.org)
