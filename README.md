# DeskMate <img src="https://github.com/DAQEM/DeskMate/blob/master/MVC/wwwroot/images/logo_small_transparant.png" height="30">
DeskMate is a web application that allows users to reserve workspaces. It allows users to search for workspaces based on location, time, and availability.

The project is built using C# .NET Core 7 with 4 layers: MVC layer, BLL layer, DAL layer, and a factory layer that connects the MVC and DAL layers.

## Requirements
- Visual Studio, Rider or any other .NET IDE
- .NET Core SDK 7.0
## Installation
1. Clone the repository
```
git clone https://github.com/yourusername/deskmate.git
```
2. Open the solution file DeskMate.sln in your IDE.
3. Build the solution.
4. Run the application.

## Usage
1. Open the application in a web browser.
2. Search for available workspaces based on location, time, and availability.
3. Reserve a workspace by selecting the desired workspace and providing your information.
4. Cancel a reservation if necessary.

## Architecture
The application follows a 4-layer architecture:

1. MVC layer: The user interface layer that handles user requests and responses.
2. BLL layer: The business logic layer that handles business rules and data validation.
3. DAL layer: The data access layer that handles data persistence and retrieval.
4. Factory layer: The layer that connects the MVC and DAL layers.

## Contributing
Contributions to DeskMate are welcome. Please open an issue or pull request for any changes.

## License
DeskMate is licensed under the MIT license. See the LICENSE file for more information.
