using System;

namespace VIPTestMission
{
    /// <summary>
    /// Helper utilities for common operations
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Calculates the distance between two 3D points
        /// </summary>
        public static float Distance(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float dz = z2 - z1;

            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        /// <summary>
        /// Clamps a value between min and max
        /// </summary>
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        /// <summary>
        /// Clamps a value between min and max (integer version)
        /// </summary>
        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        /// <summary>
        /// Converts degrees to radians
        /// </summary>
        public static float DegreesToRadians(float degrees)
        {
            return degrees * (float)Math.PI / 180f;
        }

        /// <summary>
        /// Converts radians to degrees
        /// </summary>
        public static float RadiansToDegrees(float radians)
        {
            return radians * 180f / (float)Math.PI;
        }

        /// <summary>
        /// Lerp between two values
        /// </summary>
        public static float Lerp(float a, float b, float t)
        {
            t = Clamp(t, 0f, 1f);
            return a + (b - a) * t;
        }

        /// <summary>
        /// Returns a random value between min and max (exclusive)
        /// </summary>
        public static int RandomInt(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }

        /// <summary>
        /// Returns a random value between min and max (inclusive)
        /// </summary>
        public static float RandomFloat(float min, float max)
        {
            Random rand = new Random();
            return min + (float)rand.NextDouble() * (max - min);
        }

        /// <summary>
        /// Checks if a string is null or empty
        /// </summary>
        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Formats a timespan to a readable string
        /// </summary>
        public static string FormatTime(int seconds)
        {
            int hours = seconds / 3600;
            int minutes = (seconds % 3600) / 60;
            int secs = seconds % 60;

            if (hours > 0)
                return $"{hours}h {minutes}m {secs}s";
            else if (minutes > 0)
                return $"{minutes}m {secs}s";
            else
                return $"{secs}s";
        }

        /// <summary>
        /// Gets a percentage value as a formatted string
        /// </summary>
        public static string FormatPercentage(float value)
        {
            return $"{Clamp(value, 0f, 100f):F1}%";
        }

        /// <summary>
        /// Checks if a value is within range
        /// </summary>
        public static bool IsInRange(float value, float min, float max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Returns a safe division result (avoids divide by zero)
        /// </summary>
        public static float SafeDivide(float numerator, float denominator, float defaultValue = 0f)
        {
            if (denominator == 0f)
                return defaultValue;

            return numerator / denominator;
        }
    }
}
