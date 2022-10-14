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
            switch (operation)
            {
                case Operation.Addition:
                    return (float.Parse(firstOperand.text) + float.Parse(secondOperand.text)).ToString();
                case Operation.Division:
                    return (float.Parse(firstOperand.text) / float.Parse(secondOperand.text)).ToString();
                case Operation.Subtraction:
                    return (float.Parse(firstOperand.text) - float.Parse(secondOperand.text)).ToString();
                case Operation.Multiplication:
                    return (float.Parse(firstOperand.text) * float.Parse(secondOperand.text)).ToString();
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
