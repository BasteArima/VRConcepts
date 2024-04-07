using System.IO;
using UnityEngine;

namespace PhotoCamera.Behaviors
{
    public class ScreenshotCapturer : MonoBehaviour
    {
        [SerializeField] private Camera _captureCamera;
        [SerializeField] private RenderTexture _renderTexture;

        public string LastScreenshotPath { get; private set; }

        private void Awake()
        {
            Directory.CreateDirectory($"{Application.persistentDataPath}/{GameConstants.PHOTO_PHOLDERS_NAME}");
        }

        public void CaptureScreenshot()
        {
            _captureCamera.targetTexture = _renderTexture;
            var currentRT = RenderTexture.active;
            RenderTexture.active = _captureCamera.targetTexture;

            var screenshot = new Texture2D(_renderTexture.width, _renderTexture.height, TextureFormat.RGB24, false);
            screenshot.ReadPixels(new Rect(0, 0, _renderTexture.width, _renderTexture.height), 0, 0);
            screenshot.Apply();

            RenderTexture.active = currentRT;

            byte[] bytes = screenshot.EncodeToPNG();

            string filePath = $"{Application.persistentDataPath}/{GameConstants.PHOTO_PHOLDERS_NAME}/screenshot {System.DateTime.Now:MM-dd-yy (HH-mm-ss)}.png";
            LastScreenshotPath = filePath;
            File.WriteAllBytes(filePath, bytes);

            Destroy(screenshot);

            Debug.Log($"Screenshot saved to: " + filePath);
        }
    }
}