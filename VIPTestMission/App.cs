using System;
using System.Collections.Generic;

namespace VIPTestMission
{
    /// <summary>
    /// Main application class for the VIPTestMission script
    /// </summary>
    public class App
    {
        private static bool _isRunning = false;
        private static VIPMission _currentMission = null;
        private static Logger _logger = new Logger("VIPTestMission");

        // Configuration Settings
        public static class Config
        {
            public static bool DebugMode = false;
            public static bool EnableLogging = true;
            public static float MissionDifficulty = 1.0f; // 1.0 = Normal, 0.5 = Easy, 2.0 = Hard
            public static int MissionTimeout = 300; // seconds
            public static bool EnableVIPProtection = true;
            public static int MaxEnemies = 20;
        }

        /// <summary>
        /// Initializes the VIPTestMission script
        /// </summary>
        public static void Initialize()
        {
            try
            {
                if (_isRunning)
                {
                    _logger.Warning("Script is already running");
                    return;
                }

                _logger.Info("Initializing VIPTestMission v1.0.0");
                _logger.Info($"Debug Mode: {Config.DebugMode}");
                _logger.Info($"Mission Difficulty: {Config.MissionDifficulty}");

                _isRunning = true;
                _logger.Info("VIPTestMission initialized successfully");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to initialize VIPTestMission: {ex.Message}");
                _isRunning = false;
            }
        }

        /// <summary>
        /// Starts a new VIP mission
        /// </summary>
        public static bool StartMission()
        {
            try
            {
                if (_currentMission != null && _currentMission.IsActive)
                {
                    _logger.Warning("A mission is already active");
                    return false;
                }

                _logger.Info("Starting new VIP mission...");
                _currentMission = new VIPMission();
                _currentMission.Start();

                _logger.Info("VIP mission started successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to start mission: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Stops the current mission
        /// </summary>
        public static bool StopMission()
        {
            try
            {
                if (_currentMission == null || !_currentMission.IsActive)
                {
                    _logger.Warning("No active mission to stop");
                    return false;
                }

                _logger.Info("Stopping current mission...");
                _currentMission.Stop();
                _currentMission = null;

                _logger.Info("Mission stopped successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to stop mission: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the current mission status
        /// </summary>
        public static bool GetMissionStatus()
        {
            return _currentMission != null && _currentMission.IsActive;
        }

        /// <summary>
        /// Updates the mission every frame
        /// Call this from the main game loop
        /// </summary>
        public static void Update()
        {
            if (!_isRunning)
                return;

            try
            {
                if (_currentMission != null && _currentMission.IsActive)
                {
                    _currentMission.Update();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Error during mission update: {ex.Message}");
            }
        }

        /// <summary>
        /// Cleans up and shuts down the script
        /// </summary>
        public static void Shutdown()
        {
            try
            {
                _logger.Info("Shutting down VIPTestMission...");

                if (_currentMission != null && _currentMission.IsActive)
                {
                    _currentMission.Stop();
                }

                _isRunning = false;
                _logger.Info("VIPTestMission shut down successfully");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error during shutdown: {ex.Message}");
            }
        }

        /// <summary>
        /// Sets the mission difficulty level
        /// </summary>
        public static void SetDifficulty(float difficulty)
        {
            if (difficulty < 0.1f || difficulty > 3.0f)
            {
                _logger.Warning("Difficulty must be between 0.1 and 3.0");
                return;
            }

            Config.MissionDifficulty = difficulty;
            _logger.Info($"Mission difficulty set to {difficulty}");
        }

        /// <summary>
        /// Toggles debug mode
        /// </summary>
        public static void ToggleDebugMode()
        {
            Config.DebugMode = !Config.DebugMode;
            _logger.Info($"Debug mode: {(Config.DebugMode ? "ENABLED" : "DISABLED")}");
        }
    }
}
