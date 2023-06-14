using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace SudokuGame
{
    [RequireComponent(typeof(RectTransform))]
    public class SudokuNumber : MonoBehaviour
    {
        public RectTransform rectTransform => transform as RectTransform;
        [SerializeField] private TextMeshProUGUI numberText;
        
        /// <summary>
        /// Update the number in the cell
        /// </summary>
        public void SetNumber(string number)
        {
            numberText.text = number;
        }
    }
}
