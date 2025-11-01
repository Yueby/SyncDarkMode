using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Yueby
{
    public class SyncDarkModeEditorWindow : EditorWindow
    {
        [SerializeField]
        private VisualTreeAsset m_VisualTreeAsset = default;

        [MenuItem("Tools/YuebyTools/SyncDarkMode")]
        public static void ShowExample()
        {
            SyncDarkModeEditorWindow wnd = GetWindow<SyncDarkModeEditorWindow>();
            wnd.titleContent = new GUIContent("SyncDarkMode");
            wnd.maxSize = new Vector2(400, 300);
        }

        public void CreateGUI()
        {
            rootVisualElement.Add(m_VisualTreeAsset.Instantiate());
            UpdateToggleState();
        }

        private void UpdateToggleState()
        {
            VisualElement customToggle = rootVisualElement?.Q<VisualElement>("custom-toggle");
            if (customToggle == null) return;

            bool isSupported = PlatformHelper.IsSupportedPlatform();
            bool isEnabled = SyncDarkMode.IsEnabled();

            if (isEnabled && isSupported)
            {
                customToggle.AddToClassList("on");
            }
            else
            {
                customToggle.RemoveFromClassList("on");
            }

            customToggle.SetEnabled(isSupported);
            customToggle.UnregisterCallback<ClickEvent>(OnToggleClicked);
            if (isSupported)
            {
                customToggle.RegisterCallback<ClickEvent>(OnToggleClicked);
            }
        }

        private void OnToggleClicked(ClickEvent evt)
        {
            SyncDarkMode.SetEnabled(!SyncDarkMode.IsEnabled());
            UpdateToggleState();
        }
    }
}
