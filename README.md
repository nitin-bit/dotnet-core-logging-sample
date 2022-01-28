# Dotnet Core Logging Sample....
This is an example of logging simultaneously to the console and [nLog](https://github.com/NLog/NLog.Extensions.Logging) from .NET Core.
---
This sample is an [ASP.NET Core](https://www.asp.net/core) API site that shows:
* Making logging available within the Startup.cs class by pre-configuring logging from `Program.cs`.
* Demonstrating how to log from the `Startup.cs` class.
* Including the [nLog](https://github.com/NLog/NLog.Extensions.Logging) logging provider.

---

##How to log events from within Startup.cs:

* Create an ASP.NET Core Web Application *(this sample uses the Web API template)*.

* From `Program.cs`, configure logging and log to the console as shown here:

```
public class Program
{
	public static void Main(string[] args)
	{
		var host = new WebHostBuilder()
			.UseKestrel()
			.UseContentRoot(Directory.GetCurrentDirectory())
			.UseIISIntegration()
			.ConfigureLogging(f => f.AddConsole(LogLevel.Debug)) // initialize logging here to make the logger available in Startup.cs
			.UseStartup<Startup>()
			.Build();

		host.Run();
	}
}
```

* In the `Startup.cs` class, create a private logger class variable:

```
private readonly ILogger<Startup> logger;
```

* In the `Startup.cs` constructor, add an `ILoggerFactory` parameter and create the logger:

```
public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
{
	// logging was configured in Programs.cs, now it can be used here in Startup when the ILoggerFactory is a Startup constructor parameter
	logger = loggerFactory.CreateLogger<Startup>();
	...
```

* In the `Configure` method of `Startup.cs`, you can now remove the `ILoggerFactory` method parameter any lines you had to add Console and Debug logging:
```
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
  // loggerFactory.AddConsole(Configuration.GetSection("Logging"));
  // loggerFactory.AddDebug();
  ```

* Logging is now available in `Startup.cs`!  Give it a try:
```
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
	logger.LogInformation("Hello from startup.cs!");
	...
```

---

## How to also output to the nLog provider:

* Add the [`NLog.Extensions.Logging`](https://github.com/NLog/NLog.Extensions.Logging) NuGet package
* Follow the instructions from the [nLog NuGet site](https://github.com/NLog/NLog.Extensions.Logging) to add an nLog config file, add nLog from `Startup.cs`, and publish the nLog.config.

This repo demonstrates using nLog in conjunction with Console logging.

For more information on logging with .NET Core and a list of other supported logging providers, see the [ASP.NET Core documentation on logging](https://docs.asp.net/en/latest/fundamentals/logging.html).
