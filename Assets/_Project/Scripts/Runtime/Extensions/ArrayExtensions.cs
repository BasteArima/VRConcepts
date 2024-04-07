using System;
using System.Collections.Generic;
using System.Linq;

namespace VRConcepts.Runtime.Extensions
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this Array target)
        {
            foreach (var item in target)
                yield return (T)item;
        }

        public static T GetRandomElement<T>(this T[] array)
        {
            int random = UnityEngine.Random.Range(0, array.Length);
            return array[random];
        }

        public static T[] GetRandomElements<T>(this T[] array, int count)
        {
            if (array.Length < count)
                throw new ArgumentException($"Count less then array length. Count: {count}, Lenght: {array.Length}");
            T[] randoms = new T[count];
            var heap = array.ToList();
            for (int i = 0; i < count; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, heap.Count);
                randoms[i] = heap[randomIndex];
                heap.Remove(heap[randomIndex]);
            }

            return randoms;
        }

        public static T GetRandomElementWithChances<T>(this IChanceObject[] array) where T : IChanceObject
        {
            if (array == null || array.Length == 0)
                return default(T);

            float totalChance = 0;
            foreach (var objectWithChance in array)
                totalChance += objectWithChance.Chance;

            if (totalChance == 0)
                return default(T);

            float randomValue = UnityEngine.Random.Range(0, totalChance);

            float cumulativeChance = 0;
            foreach (var objectWithChance in array)
            {
                cumulativeChance += objectWithChance.Chance;
                if (randomValue <= cumulativeChance)
                {
                    return (T)objectWithChance;
                }
            }

            return default(T);
        }
    }
}