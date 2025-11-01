using UnityEngine;

namespace Yueby
{
    public static class PlatformHelper
    {
        public static bool IsSupportedPlatform()
        {
            return Application.platform == RuntimePlatform.WindowsEditor;
        }
    }
}

