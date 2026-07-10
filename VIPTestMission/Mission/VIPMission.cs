using System;
using System.Collections.Generic;

namespace VIPTestMission
{
    /// <summary>
    /// Core VIP mission class
    /// Manages mission lifecycle and core mechanics
    /// </summary>
    public class VIPMission
    {
        private bool _isActive = false;
        private int _missionTimer = 0;
        private Logger _logger = new Logger("VIPMission");

        // Mission State
        private MissionState _currentState = MissionState.Inactive;
        private VIPProtection _vipProtection = null;
        private MissionEvents _missionEvents = null;

        // Mission objectives
        private List<string> _objectives = new List<string>();
        private int _objectiveIndex = 0;

        /// <summary>
        /// Mission states enumeration
        /// </summary>
        public enum MissionState
        {
            Inactive,
            Starting,
            Active,
            ObjectiveInProgress,
            Completed,
            Failed,
            Aborted
        }

        public bool IsActive
        {
            get { return _isActive; }
        }

        public MissionState CurrentState
        {
            get { return _currentState; }
        }

        /// <summary>
        /// Initializes the mission
        /// </summary>
        public VIPMission()
        {
            _logger.Info("VIPMission instance created");
        }

        /// <summary>
        /// Starts the mission
        /// </summary>
        public void Start()
        {
            try
            {
                _logger.Info("Starting VIP mission...");

                _isActive = true;
                _currentState = MissionState.Starting;
                _missionTimer = 0;

                // Initialize mission components
                _vipProtection = new VIPProtection();
                _missionEvents = new MissionEvents();

                // Setup objectives
                InitializeObjectives();

                // Setup events
                _missionEvents.RegisterEventHandlers();

                _currentState = MissionState.Active;
                _logger.Info("VIP mission started successfully");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to start mission: {ex.Message}");
                _isActive = false;
                _currentState = MissionState.Failed;
            }
        }

        /// <summary>
        /// Stops the mission
        /// </summary>
        public void Stop()
        {
            try
            {
                _logger.Info("Stopping mission...");

                if (_missionEvents != null)
                {
                    _missionEvents.UnregisterEventHandlers();
                }

                if (_vipProtection != null)
                {
                    _vipProtection.Cleanup();
                }

                _isActive = false;
                _currentState = MissionState.Aborted;
                _logger.Info("Mission stopped");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error stopping mission: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates mission logic every frame
        /// </summary>
        public void Update()
        {
            if (!_isActive)
                return;

            try
            {
                _missionTimer++;

                // Check for timeout
                if (_missionTimer > App.Config.MissionTimeout * 60) // Convert seconds to frames (assuming 60 FPS)
                {
                    FailMission("Mission timeout");
                    return;
                }

                // Update VIP protection
                if (_vipProtection != null)
                {
                    _vipProtection.Update();
                }

                // Update mission events
                if (_missionEvents != null)
                {
                    _missionEvents.Update();
                }

                // Check mission completion
                CheckMissionCompletion();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error during mission update: {ex.Message}");
            }
        }

        /// <summary>
        /// Initializes mission objectives
        /// </summary>
        private void InitializeObjectives()
        {
            _objectives.Clear();
            _objectives.Add("Protect the VIP");
            _objectives.Add("Eliminate threats");
            _objectives.Add("Reach the extraction point");
            _objectives.Add("Mission Complete!");

            _objectiveIndex = 0;
            _logger.Info($"Objectives initialized ({_objectives.Count} objectives)");
        }

        /// <summary>
        /// Gets the current objective
        /// </summary>
        public string GetCurrentObjective()
        {
            if (_objectiveIndex < _objectives.Count)
            {
                return _objectives[_objectiveIndex];
            }
            return "Mission Complete";
        }

        /// <summary>
        /// Advances to the next objective
        /// </summary>
        public void NextObjective()
        {
            if (_objectiveIndex < _objectives.Count - 1)
            {
                _objectiveIndex++;
                _logger.Info($"Objective updated: {GetCurrentObjective()}");
            }
        }

        /// <summary>
        /// Checks if mission should be completed
        /// </summary>
        private void CheckMissionCompletion()
        {
            if (_vipProtection != null && _vipProtection.IsVIPSafe && _objectiveIndex >= _objectives.Count - 1)
            {
                CompleteMission();
            }
        }

        /// <summary>
        /// Completes the mission successfully
        /// </summary>
        public void CompleteMission()
        {
            _logger.Info("Mission completed successfully!");
            _currentState = MissionState.Completed;
            _isActive = false;
        }

        /// <summary>
        /// Fails the mission
        /// </summary>
        public void FailMission(string reason)
        {
            _logger.Warning($"Mission failed: {reason}");
            _currentState = MissionState.Failed;
            _isActive = false;
        }

        /// <summary>
        /// Gets mission timer in seconds
        /// </summary>
        public int GetMissionTime()
        {
            return _missionTimer / 60; // Assuming 60 FPS
        }

        /// <summary>
        /// Gets VIP protection status
        /// </summary>
        public VIPProtection GetVIPProtection()
        {
            return _vipProtection;
        }

        /// <summary>
        /// Gets mission events handler
        /// </summary>
        public MissionEvents GetMissionEvents()
        {
            return _missionEvents;
        }
    }
}
