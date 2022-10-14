using System;
using UnityEngine;
using TMPro;

public class TwoNumbersComparer : MonoBehaviour
{
    [SerializeField] private TMP_Text result;
    [SerializeField] private TMP_InputField firstOperand;
    [SerializeField] private TMP_InputField secondOperand;
    
    private void Start()
    {
        result.text = "";
    }
    
    public void OnCompareClick()
    {
        float firstVariable = float.Parse(firstOperand.text);
        float secondVariable = float.Parse(secondOperand.text);

        if (firstVariable > secondVariable)
        {
            result.text = ">";
        } else if (firstVariable < secondVariable)
        {
            result.text = "<";
        }
        else
        {
            result.text = "=";
        }
    }
}
