using UnityEngine;
using TMPro;

public class TwoNumbersComparer : MonoBehaviour
{
    [SerializeField] private TMP_Text result;
    [SerializeField] private TMP_InputField firstOperand;
    [SerializeField] private TMP_InputField secondOperand;
    [SerializeField] private TMP_InputField resultMax;
    
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
            resultMax.text = $"Наибольшее число {firstVariable}";
        } else if (firstVariable < secondVariable)
        {
            result.text = "<";
            resultMax.text = $"Наибольшее число {secondVariable}";
        }
        else
        {
            resultMax.text = "Значения равны";
            result.text = "=";
        }
    }
}
