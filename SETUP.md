# Setup Guide - GTA5 VIPTestMission

This guide will help you set up and run the VIPTestMission script.

## Prerequisites

Before you begin, ensure you have the following installed:

### 1. GTA V
- Latest version of Grand Theft Auto V
- Ensure the game is fully updated

### 2. ScriptHookV
Download and install from: http://www.dev-c.com/gtav/scripthookv

**Installation Steps:**
1. Download `ScriptHookV_1.0.XXXX.X.zip` (latest version)
2. Extract all files to your GTA V root directory
3. You should see files like `dinput8.dll`, `ScriptHookV.dll`, etc. in the root folder

### 3. ScriptHookVDotNet Nightly Build
Download from: https://github.com/crosire/scripthookvdotnet/releases

**Installation Steps:**
1. Download the latest nightly build release
2. Extract all files to your GTA V root directory
3. You should see a `scripts` folder and `ScriptHookVDotNet.dll` in the root folder

### 4. .NET Framework 4.8
Download from: https://dotnet.microsoft.com/download/dotnet-framework

**Installation Steps:**
1. Download the .NET Framework 4.8 Runtime
2. Run the installer and follow the on-screen instructions
3. Restart your computer after installation

### 5. Visual Studio (for development/compilation)
Download Community Edition from: https://visualstudio.microsoft.com/

**Installation Steps:**
1. Download Visual Studio Community
2. During installation, select ".NET desktop development" workload
3. Ensure ".NET Framework 4.8 development tools" is selected

## Installation Steps

### Step 1: Clone or Download the Repository
```bash
git clone https://github.com/uzig7181/GTA5-VIPTestMission.git
cd GTA5-VIPTestMission
```

### Step 2: Build the Project

#### Option A: Using Visual Studio
1. Open `VIPTestMission/VIPTestMission.csproj` in Visual Studio
2. Right-click the project → Properties
3. Go to Build → Output path: Set to `bin\Release\`
4. Build → Build Solution (or press Ctrl+Shift+B)
5. The compiled DLL will be in `VIPTestMission\bin\Release\VIPTestMission.dll`

#### Option B: Using Command Line
```bash
cd VIPTestMission
msbuild VIPTestMission.csproj /p:Configuration=Release
```

### Step 3: Deploy to GTA V

1. Navigate to your GTA V installation directory
2. Locate the `scripts` folder (create it if it doesn't exist)
3. Copy `VIPTestMission.dll` to the `scripts` folder
4. Your folder structure should look like:
   ```
   GTA V/
   ├── scripts/
   │   ├── VIPTestMission.dll (your script)
   │   ├── ScriptHookVDotNet.dll
   │   ├── ScriptHookVDotNet2.dll
   │   └── ... (other scripts)
   ├── dinput8.dll
   ├── ScriptHookV.dll
   └── gta5.exe
   ```

### Step 4: Launch the Game

1. Start GTA V
2. The VIPTestMission script should load automatically
3. Check the console for any initialization messages

## Configuration

Edit `VIPTestMission\App.cs` to customize settings:

```csharp
public static class Config
{
    public static bool DebugMode = false;           // Enable debug logging
    public static bool EnableLogging = true;        // Enable all logging
    public static float MissionDifficulty = 1.0f;   // 0.5 = Easy, 1.0 = Normal, 2.0 = Hard
    public static int MissionTimeout = 300;         // Timeout in seconds
    public static bool EnableVIPProtection = true;  // Enable VIP protection mechanics
    public static int MaxEnemies = 20;              // Maximum enemy count
}
```

After making changes, rebuild the project and redeploy the DLL.

## Running a Mission

Once the script is loaded:

1. **Start Mission**: Use the in-game command or key binding to start a mission
2. **Monitor Progress**: Watch the mission objectives and VIP status
3. **Complete Objectives**: Follow the on-screen instructions
4. **Success**: Complete all objectives to finish the mission

## Troubleshooting

### Script Not Loading
- **Issue**: Script doesn't appear in game
- **Solution**: 
  - Verify ScriptHookV is installed correctly
  - Check that `VIPTestMission.dll` is in the `scripts` folder
  - Ensure .NET Framework 4.8 is installed
  - Check the game console for error messages

### Build Errors
- **Issue**: Compilation fails
- **Solution**:
  - Ensure Visual Studio has ".NET Framework 4.8 development tools"
  - Add missing references to ScriptHookVDotNet DLLs:
    1. Right-click Project → Add Reference
    2. Browse to ScriptHookVDotNet DLL location
    3. Select and add the reference

### Mission Crashes
- **Issue**: Mission crashes during gameplay
- **Solution**:
  - Check the log file at `VIPTestMission.log`
  - Reduce `MaxEnemies` in configuration
  - Update ScriptHookVDotNet to latest nightly build

### Performance Issues
- **Issue**: Game stutters or lags with the script
- **Solution**:
  - Reduce `MaxEnemies` value
  - Disable `DebugMode` to reduce logging overhead
  - Ensure your graphics settings are appropriate for your system

## Debugging

### Enable Debug Mode
In `App.cs`, set:
```csharp
Config.DebugMode = true;
Config.EnableLogging = true;
```

This will create detailed logs in `VIPTestMission.log`

### View Logs
```bash
# Windows
type VIPTestMission.log

# Linux/Mac
cat VIPTestMission.log
```

## Next Steps

- Explore the source code in `VIPTestMission/`
- Customize mission objectives in `Mission/VIPMission.cs`
- Add new events in `Mission/MissionEvents.cs`
- Modify VIP behavior in `Mission/VIPProtection.cs`

## Support

For issues or questions:
1. Check the troubleshooting section above
2. Review the README.md
3. Open an issue on GitHub: https://github.com/uzig7181/GTA5-VIPTestMission/issues

## Additional Resources

- [ScriptHookVDotNet Documentation](https://github.com/crosire/scripthookvdotnet)
- [GTA V Modding Community](https://www.gtaforums.com/)
- [.NET Framework Documentation](https://docs.microsoft.com/en-us/dotnet/framework/)

---

Happy scripting!
