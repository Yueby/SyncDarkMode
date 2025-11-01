using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Yueby
{
    [InitializeOnLoad]
    public static class SyncDarkMode
    {
        private const string EDITOR_PREFS_KEY_ENABLED = "Yueby.SyncDarkMode.Enabled";

        static SyncDarkMode()
        {
            if (!PlatformHelper.IsSupportedPlatform())
            {
                if (IsEnabled())
                {
                    SetEnabled(false);
                }
                return;
            }

            WindowsThemeWatcher.OnThemeChanged += OnWindowsThemeChanged;
            if (IsEnabled())
            {
                SyncEditorTheme();
            }
        }

        public static bool IsEnabled()
        {
            return EditorPrefs.GetBool(EDITOR_PREFS_KEY_ENABLED, true);
        }

        public static void SetEnabled(bool enabled)
        {
            if (!PlatformHelper.IsSupportedPlatform())
            {
                enabled = false;
            }

            EditorPrefs.SetBool(EDITOR_PREFS_KEY_ENABLED, enabled);
            
            if (enabled)
            {
                SyncEditorTheme();
            }
        }

        private static void OnWindowsThemeChanged(bool isDarkMode)
        {
            if (IsEnabled())
            {
                SyncEditorTheme();
            }
        }

        private static void SyncEditorTheme()
        {
            if (WindowsThemeWatcher.IsDarkMode() != EditorGUIUtility.isProSkin)
            {
                InternalEditorUtility.SwitchSkinAndRepaintAllViews();
            }
        }
    }
}

