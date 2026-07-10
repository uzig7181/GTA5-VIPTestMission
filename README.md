# GTA5 VIPTestMission

A GTA5 mission script built with .NET Framework 4.8, ScriptHookV, and ScriptHookVDotNet (Nightly Build).

## Overview

VIPTestMission is a custom mission script for Grand Theft Auto V that demonstrates advanced scripting capabilities using the ScriptHookVDotNet framework. This mission includes VIP protection mechanics, advanced AI interactions, and dynamic mission scenarios.

## Requirements

- **GTA V** (Latest version)
- **.NET Framework 4.8** or higher
- **ScriptHookV** (Latest version)
- **ScriptHookVDotNet Nightly Build**

## Installation

1. Download and install ScriptHookV from [here](http://www.dev-c.com/gtav/scripthookv)
2. Download ScriptHookVDotNet Nightly Build from [here](https://github.com/crosire/scripthookvdotnet/releases)
3. Place the compiled `VIPTestMission.dll` in your `scripts` folder
4. Launch GTA V and trigger the mission

## Project Structure

```
GTA5-VIPTestMission/
├── VIPTestMission/
│   ├── Properties/
│   │   └── AssemblyInfo.cs
│   ├── Mission/
│   │   ├── VIPMission.cs
│   │   ├── VIPProtection.cs
│   │   └── MissionEvents.cs
│   ├── Utilities/
│   │   ├── Logger.cs
│   │   └── Helper.cs
│   ├── App.cs
│   └── VIPTestMission.csproj
├── packages.config
├── README.md
├── SETUP.md
└── LICENSE
```

## Features

- **VIP Protection System**: Advanced NPC protection mechanics
- **Dynamic Events**: Random mission scenarios and objectives
- **Mission Tracking**: Real-time mission progress updates
- **Advanced AI**: Enhanced NPC behavior and interactions
- **Customizable Settings**: Easy configuration of mission parameters
- **Comprehensive Logging**: Debug and error logging capabilities

## Building

### Requirements for Building
- Visual Studio 2019 or later
- .NET Framework 4.8 SDK
- ScriptHookVDotNet references

### Build Steps

1. Open `VIPTestMission\VIPTestMission.csproj` in Visual Studio
2. Add references to ScriptHookVDotNet DLLs
3. Build the solution (Build → Build Solution)
4. The compiled DLL will be output to `bin\Release\VIPTestMission.dll`
5. Copy the DLL to your GTA V `scripts` folder

## Configuration

Edit the settings in `VIPTestMission\App.cs` to customize:
- Mission difficulty levels (0.5 = Easy, 1.0 = Normal, 2.0 = Hard)
- VIP behavior parameters
- Event trigger rates
- Debug logging options
- Maximum enemy counts
- Mission timeouts

Example configuration:
```csharp
Config.DebugMode = false;
Config.EnableLogging = true;
Config.MissionDifficulty = 1.0f;
Config.MissionTimeout = 300; // seconds
Config.MaxEnemies = 20;
```

## Usage

Once installed and GTA V is launched:
1. The script will automatically load when the game starts
2. Trigger the mission via in-game commands or key bindings
3. Follow on-screen instructions to complete objectives
4. Mission includes wave-based enemy encounters and VIP protection scenarios

## Mission Objectives

1. **Protect the VIP** - Keep the VIP safe from threats
2. **Eliminate Threats** - Defeat incoming enemy waves
3. **Reach Extraction** - Guide the VIP to the extraction point
4. **Mission Complete** - Success upon reaching objectives

## API Overview

### App Class
Main application controller with mission lifecycle management.
- `Initialize()` - Initialize the script
- `StartMission()` - Start a new mission
- `StopMission()` - Stop current mission
- `Update()` - Called every frame

### VIPMission Class
Core mission logic and state management.
- `Start()` - Start the mission
- `Stop()` - Stop the mission
- `Update()` - Update mission each frame
- `GetCurrentObjective()` - Get current mission objective

### VIPProtection Class
VIP protection and threat management system.
- `InitiateEvacuation()` - Start VIP evacuation
- `DetectThreats()` - Scan for threats
- `GetStatusInfo()` - Get VIP status

### MissionEvents Class
Dynamic mission events system.
- `RegisterEventHandlers()` - Register all event types
- `Update()` - Check for event triggers
- `GetWaveNumber()` - Get current wave number

## Troubleshooting

### Script Not Loading
- Ensure ScriptHookV is installed in your GTA V root directory
- Verify ScriptHookVDotNet files are in the `scripts` folder
- Check that .NET Framework 4.8 is installed on your system
- Look for error messages in the GTA V console

### Mission Crashes
- Check `VIPTestMission.log` for error messages
- Ensure all dependencies are up to date
- Verify the DLL is compiled for .NET Framework 4.8
- Try reducing `MaxEnemies` in configuration

### Build Errors
- Ensure Visual Studio has ".NET Framework 4.8 development tools"
- Add ScriptHookVDotNet DLL references to the project
- Check that the project targets .NET Framework 4.8

### Performance Issues
- Reduce `MaxEnemies` value in configuration
- Disable `DebugMode` to reduce logging overhead
- Lower mission difficulty for fewer spawned entities

## Development

### Adding New Events
1. Add new event type to `MissionEvents.EventType` enum
2. Create handler method in `MissionEvents` class
3. Register in `RegisterEventHandlers()`
4. Implement logic in the handler

### Customizing VIP Behavior
Edit `VIPProtection.cs`:
- Modify threat detection range
- Customize bodyguard spawning
- Add new protection mechanics

### Extending Mission Logic
Edit `VIPMission.cs`:
- Add new objectives
- Implement completion conditions
- Customize state transitions

## Contributing

Contributions are welcome! Please:
1. Fork the repository
2. Create a feature branch
3. Submit a pull request with detailed descriptions

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Disclaimer

This is a custom script for personal use. Use at your own risk. Not affiliated with Rockstar Games or Take-Two Interactive.

## Resources

- [ScriptHookVDotNet GitHub](https://github.com/crosire/scripthookvdotnet)
- [ScriptHookV Website](http://www.dev-c.com/gtav/scripthookv)
- [.NET Framework Documentation](https://docs.microsoft.com/en-us/dotnet/framework/)
- [GTA Modding Community](https://www.gtaforums.com/)

## Support

For issues, questions, or suggestions:
1. Check the SETUP.md guide
2. Review the troubleshooting section above
3. Open an issue on the GitHub repository

---

**Version**: 1.0.0  
**Author**: uzig7181  
**Last Updated**: 2026-07-10
