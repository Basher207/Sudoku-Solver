using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SudokuGame
{
    public static class Extentions
    {
        public static float RoundDecimalPlace(this float number, int decimalPlaces)
        {
            float multiplier = Mathf.Pow(10.0f, decimalPlaces);
            return Mathf.Round(number * multiplier) / multiplier;
        }

        /// <summary>
        /// Destroys all children of a transform using DestroyImmediate
        /// </summary>
        /// <param name="parent"></param>
        public static void DestroyChildrenImmediate(this Transform parent)
        {
            int childCount = parent.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                GameObject child = parent.GetChild(i).gameObject;
                Object.DestroyImmediate(child);
            }
        }
    }
}