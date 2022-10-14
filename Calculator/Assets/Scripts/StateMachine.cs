using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject calculatorScreen;
    [SerializeField] private GameObject compareNumbersScreen;

    private GameObject _currentScreen;

    private void Start()
    {
        calculatorScreen.SetActive(true);
        _currentScreen = calculatorScreen;
    }

    public void OpenCalculator()
    {
        ChangeState(calculatorScreen);
    }
    
    public void OpenCompareNumbers()
    {
        ChangeState(compareNumbersScreen);
    }

    private void ChangeState(GameObject state)
    {
        if (_currentScreen != null)
        {
            _currentScreen.SetActive(false);
            _currentScreen = state;
            _currentScreen.SetActive(true);
        }
    }
}
