using System;
using TMPro;
using UnityEngine;

enum Operation
{
    Addition, 
    Subtraction, 
    Multiplication, 
    Division
}

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_InputField result;
    [SerializeField] private TMP_InputField firstOperand;
    [SerializeField] private TMP_InputField secondOperand;

    private void Start()
    {
        result.text = "=";
    }

    private String GetCalculationResult(Operation operation)
    {
        try
        {
            float firstNumber = float.Parse(firstOperand.text);
            float secondNumber = float.Parse(secondOperand.text);
            
            switch (operation)
            {
                case Operation.Addition:
                    float additionResult = firstNumber + secondNumber;
                    return additionResult.ToString();
                case Operation.Division:
                    float divisionResult= firstNumber / secondNumber;
                    return divisionResult.ToString();
                case Operation.Subtraction:
                    float subtractionResult = firstNumber - secondNumber;
                    return subtractionResult.ToString();
                case Operation.Multiplication:
                    float multiplicationResult = firstNumber * secondNumber;
                    return multiplicationResult.ToString();
                default:
                    return "Error";
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return "Error";
        }
    }

    public void OnPlusClick()
    {
        result.text = "= " + GetCalculationResult(Operation.Addition);
    }
    
    public void OnMinusClick()
    {
        result.text = "= " + GetCalculationResult(Operation.Subtraction);
    }
    
    public void OnMultiplyClick()
    {
        result.text = "= " + GetCalculationResult(Operation.Multiplication);
    }
    
    public void OnDivideClick()
    {
        result.text = "= " + GetCalculationResult(Operation.Division);
    }
}
