# DalList Solution (DotNet2025_2756_6390)

Short, practical README for building, running and troubleshooting the solution.

## Overview
This solution contains a small in-memory DAL implementation (dalList) and a console test app (DalTest) that exercises CRUD operations for Customers, Products and Sales. A lightweight logging helper (Tools/LogManager.cs) writes per-month log files under a `Log` folder in the app output directory by default.

## Projects
- DalFacade — DAL interfaces and DO (data objects).
- dalList — in-memory implementation of the DAL (ICustomer, IProduct, ISale).
- Tools — LogManager helper used by dalList implementations.
- DalTest — console test application demonstrating the DAL.

## Requirements
- Visual Studio 2022 (recommended) or dotnet CLI for compatible projects.
- Solution contains mixed targets: some projects target .NET 8, Tools/LogManager compiled for .NET Framework 4.7.2 in earlier files — open the project properties and align target frameworks if you intend to build everything together.

## Build & Run
1. Open the solution in Visual Studio 2022.
2. Ensure the startup project is `DalTest`.
3. Build the solution (`__Build > Build Solution__`).
4. Run the app with `__Debug > Start Debugging__` or `__Debug > Start Without Debugging__` (or press __Ctrl+F5__).

Alternatively, if projects target .NET 8 and you prefer the CLI:
- From the project folder: `dotnet build` and `dotnet run --project DalTest`

## Usage
DalTest is an interactive console app. Follow on-screen menus to:
- Create / Read / Update / Delete Customers, Products and Sales.

Example: create a customer -> ReadAll -> see results printed to console.

## Logging (LogManager)
- Default folder: a relative `Log` folder under the running app's base directory (e.g. `.../DalTest/bin/Debug/net8.0/Log/<MM>/Log_dd-MM-yyyy.txt`).
- Each month gets its own subfolder (month number).
- If you don't see logs:
  - Confirm writeToLog is actually being called (use breakpoints or console diagnostics).
  - Check the exact full path printed by the app (LogManager writes diagnostics to the console in debug builds).
  - Verify the process has write permissions to the output directory (network drives may require elevated permissions).
  - If necessary, change LogManager.BaseDirPath to an absolute path you control (e.g. `C:\Temp\ProjectLogs`) or align project target frameworks so Tools runs under the expected runtime.

## Troubleshooting
- "Could not find a part of the path ..." — usually caused by malformed path composition or duplicated path segments. The LogManager implementation uses month subfolders; ensure getPathDir/getPathFile return sane paths.
- If Directory.Exists(path) returns true but you cannot find the folder in Explorer, copy the full path printed by the app and paste into Explorer's address bar.
- If building fails due to mixed target frameworks, set matching target frameworks in each project via Project Properties.

## Notes & Recommendations
- Keep LogManager path assembly simple and use `Path.Combine` for cross-platform safety.
- Avoid swallowing exceptions silently when debugging file I/O — LogManager contains minimal diagnostics to help locate permission/path issues.
- After confirming logging works, remove or reduce diagnostic console output.

## Contributing
Make minimal, well-documented changes. Keep to the project's existing style and only change what is necessary.

---
If you want, I can:
- Add a short example walkthrough showing a typical CRUD session in DalTest.
- Add a script or VS settings to standardize project target frameworks.
