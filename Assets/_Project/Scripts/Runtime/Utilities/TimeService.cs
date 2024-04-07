using UnityEngine;
using System;
using System.Globalization;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace VRConcepts.Runtime.Utilities
{
    public static class TimeService
    {
        public static bool IsTimeGotFromServer { get; private set; }

        private static DateTime _utcStartTime = DateTime.UtcNow;

        public static DateTime LevelStartTime { get; set; }

        public static void InitializeTime()
        {
            GetTimeFromServerAsync();
        }

        private static async UniTask GetTimeFromServerAsync()
        {
            var url = "https://srv.baste.ru/php_game_scripts/get_time.php";

            using (UnityWebRequest www = UnityWebRequest.Get(url))
            {
                await www.SendWebRequest().ToUniTask();
                if (www.isNetworkError || www.isHttpError)
                {
                    IsTimeGotFromServer = false;
                    Debug.Log("GetTimeFromServerAsync Error: " + www.error);
                }
                else
                {
                    try
                    {
                        var responseJson = www.downloadHandler.text;
                        TimeResponse timeResponse = JsonConvert.DeserializeObject<TimeResponse>(responseJson);
                        _utcStartTime = DateTime.ParseExact(timeResponse.time, "yyyy-MM-dd HH:mm:ss",
                            CultureInfo.InvariantCulture);
                        IsTimeGotFromServer = true;
                    }
                    catch (Exception ex)
                    {
                        IsTimeGotFromServer = false;
                        Debug.LogError("GetTimeFromServerAsync Parse DateTime Error: " + ex);
                    }
                }
            }
        }

        public static DateTime GetCurrentTime()
        {
            return _utcStartTime.AddSeconds(Time.realtimeSinceStartup);
        }

        [Serializable]
        private class TimeResponse
        {
            public string time;
        }
    }
}