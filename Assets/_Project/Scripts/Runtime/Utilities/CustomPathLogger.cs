using UnityEngine;

namespace VRConcepts.Runtime.Utilities
{
    public class CustomPathLogger : MonoBehaviour
    {
        private string _filename = "";

        private void OnEnable()
        {
            Application.logMessageReceived += Log;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= Log;
        }

        public void Log(string logString, string stackTrace, LogType type)
        {
            if (_filename == "")
            {
                string d = Application.dataPath + "/Logs";
                System.IO.Directory.CreateDirectory(d);
                _filename = d + "/Player.log";
            }

            try
            {
                System.IO.File.AppendAllText(_filename, logString + "\n");
            }
            catch
            {
            }
        }
    }
}