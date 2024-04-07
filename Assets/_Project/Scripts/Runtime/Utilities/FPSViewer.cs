using UnityEngine;

namespace VRConcepts.Runtime.Utilities
{
    public class FPSViewer : MonoBehaviour
    {
        [SerializeField] private bool _enable;

        private float _deltaTime = 0.0f;
        private GUIStyle _style = new GUIStyle();

        private void Start()
        {
            _style.alignment = TextAnchor.UpperLeft;
            _style.fontSize = 24;
            _style.normal.textColor = Color.white;
        }

        private void Update()
        {
            if (!_enable) return;
            _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
        }

        private void OnGUI()
        {
            if (!_enable) return;
            float fps = 1.0f / _deltaTime;
            string text = string.Format("FPS: {0:F0}", fps);
            GUI.Label(new Rect(10, 10, 200, 100), text, _style);
        }
    }
}