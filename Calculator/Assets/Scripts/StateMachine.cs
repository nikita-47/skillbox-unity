using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject calculatorScreen;
    [SerializeField] private GameObject compareNumbersScreen;
    [SerializeField] private GameObject arrayOperationsScreen;

    private GameObject _currentScreen;

    private void Start()
    {
        arrayOperationsScreen.SetActive(true);
        _currentScreen = arrayOperationsScreen;
    }

    public void OpenCalculator()
    {
        ChangeState(calculatorScreen);
    }
    
    public void OpenCompareNumbers()
    {
        ChangeState(compareNumbersScreen);
    }
    
    public void OpenArrayOperations()
    {
        ChangeState(arrayOperationsScreen);
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
