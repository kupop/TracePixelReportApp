# TracePixelReportApp

# Project Description
This console application reads a .txt log generated by a tracking pixel and generates a report based on the findings.

```
|url          |page views  |visitors|
|/index.html  |1           |1       |
|/contact.html|1           |1       |
```

# How to Use
The log must be in the the following format and end with .txt:
```
|timestamp              |url           |userid|
|2020-03-01 09:00:00UTC |/index.html   |12345 |
|2020-03-01 09:00:00UTC |/contact.html |12345 |
|2020-03-01 10:00:00UTC |/index.html   |12345 |
```
Sample logs are provided in the /logs/ folder.

All date inputs will be read as UTC time.


# Development
This project is written in C# in .net 6 framework using Visual Studio on Windows 10.

# Requirements to use
Dotnet 6 SDK

# Instructions for build, run and test
Navigate to the root of the project folder.

type "dotnet build" to build application.

type "dotnet run --project TracePixelReportApp" to run application.

type "dotnet test" to run unit tests.

# List of known issues
- All suitable unit testing not completed.
- Code refactoring needed to complete unit tests.
- Output table breaks formatting depending on results.

Readme latest update: 2022-04-07
