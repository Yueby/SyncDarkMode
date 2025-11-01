using System;
using Microsoft.Win32;
using UnityEditor;
using UnityEngine;

namespace Yueby
{
    [InitializeOnLoad]
    public static class WindowsThemeWatcher
    {
        public static event Action<bool> OnThemeChanged;

        private static bool m_LastIsDarkMode;

        private const string REGISTRY_THEME_PATH = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        private const string REGISTRY_APPS_USE_LIGHT_THEME = "AppsUseLightTheme";

        static WindowsThemeWatcher()
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                m_LastIsDarkMode = IsWindowsDarkMode();
                EditorApplication.update += CheckWindowsTheme;
            }
        }

        public static bool IsDarkMode() => IsWindowsDarkMode();

        private static void CheckWindowsTheme()
        {
            bool currentIsDarkMode = IsWindowsDarkMode();

            if (currentIsDarkMode != m_LastIsDarkMode)
            {
                m_LastIsDarkMode = currentIsDarkMode;
                OnThemeChanged?.Invoke(currentIsDarkMode);
            }
        }

        private static bool IsWindowsDarkMode()
        {
            if (Application.platform != RuntimePlatform.WindowsEditor)
            {
                return false;
            }

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_THEME_PATH))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(REGISTRY_APPS_USE_LIGHT_THEME);
                        if (value != null)
                        {
                            int appsUseLightTheme = (int)value;
                            return appsUseLightTheme == 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"Failed to read Windows theme from registry: {ex.Message}");
            }

            return false;
        }
    }
}

