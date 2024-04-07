using System;
using TMPro;
 
namespace UniRx.Extensions
{
    public static class UnityUIExtensions
    {
        public static IDisposable SubscribeToText(this IObservable<string> source, TextMeshProUGUI text)
        {
            return source.SubscribeWithState(text, (x, t) => t.text = x);
        }
 
        public static IDisposable SubscribeToText<T>(this IObservable<T> source, TextMeshProUGUI text)
        {
            return source.SubscribeWithState(text, (x, t) => t.text = x.ToString());
        }
        
        public static IDisposable SubscribeToText<T>(this IObservable<T> source, TextMeshProUGUI text, string prefix)
        {
            return source.SubscribeWithState(text, (x, t) => t.text = $"{prefix}{x.ToString()}");
        }
        
        public static IDisposable SubscribeToText(this IObservable<string> source, TMP_Text text)
        {
            return source.SubscribeWithState(text, (x, t) => t.text = x);
        }

        public static IDisposable SubscribeToText<T>(this IObservable<T> source, TMP_Text text)
        {
            return source.SubscribeWithState(text, (x, t) => t.text = x.ToString());
        }
        
        public static IDisposable SubscribeToText<T>(this IObservable<T> source, TMP_Text text, string prefix)
        {
            return source.SubscribeWithState(text, (x, t) => t.text = $"{prefix}{x.ToString()}");
        }
    }
}