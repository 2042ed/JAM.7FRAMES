using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAMURR
{
    public class ParentalGate : MonoBehaviour
    {
        public GameObject ParentsPanel;
        public GameObject ParentalGatePanel;

        public TMPro.TextMeshProUGUI TxtOperation;
        public TMPro.TextMeshProUGUI TxtResult;

        int correctAnswer;
        int currentResultCharIndex;
        int currentResult;

        void OnEnable()
        {
            setupOperation();
        }

        void setupOperation()
        {
            int numberA = Random.Range(3, 9);
            int numberB = Random.Range(0, 9);
            correctAnswer = numberA * numberB;
            TxtOperation.text = numberA.ToString() + " x " + numberB.ToString() + " =";
            TxtResult.text = "";
            currentResultCharIndex = 0;
            currentResult = 0;
        }

        public void NumberClicked(int value)
        {
            if (currentResultCharIndex == 0) {
                currentResult = currentResult + value;
            }
            if (currentResultCharIndex == 1) {
                currentResult = currentResult * 10 + value;
            }

            TxtResult.text = currentResult.ToString("D2");

            if (currentResult == correctAnswer) {
                ParentsPanel.SetActive(true);
                ParentalGatePanel.SetActive(false);
            }

            currentResultCharIndex = currentResultCharIndex + 1;
            if (currentResultCharIndex > 1) {
                currentResultCharIndex = 0;
                currentResult = 0;
            }

        }
    }
}