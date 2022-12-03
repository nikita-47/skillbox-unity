using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHandlerScript : MonoBehaviour
{
    private PinsState _pinsState;

    [SerializeField] private int firstPinStartValue;

    [SerializeField] private int secondPinStartValue;

    [SerializeField] private int thirdPinStartValue;

    [SerializeField] private TMP_Text firstPin;

    [SerializeField] private TMP_Text secondPin;

    [SerializeField] private TMP_Text thirdPin;

    [SerializeField] private TMP_Text timerText;

    [SerializeField] private string intsSecondVals;

    [SerializeField] private string intsFirstVals;

    [SerializeField] private string intsThirdVals;

    [SerializeField] private TMP_Text intsFirstValsTMPText;

    [SerializeField] private TMP_Text intsSecondValsTMPText;

    [SerializeField] private TMP_Text intsThirdValsTMPText;

    [SerializeField] private int timeForGame;

    [SerializeField] private Button startButton;

    [SerializeField] private Button restartButton;

    [SerializeField] private TMP_Text winText;

    [SerializeField] private GameObject winPanel;

    [SerializeField] private TMP_Text answerText;

    [SerializeField] private int answerValue;

    private List<int> _changesFirst;
    private List<int> _changesSecond;
    private List<int> _changesThird;
    
    private PinsState _initialPinsState;
    private bool _isGameInProgress;
    private float _timePassed;
    private bool _isUserWin;

    // Start is called before the first frame update
    void Start()
    {
        intsFirstValsTMPText.text = intsFirstVals;
        intsSecondValsTMPText.text = intsSecondVals;
        intsThirdValsTMPText.text = intsThirdVals;

        answerText.text = answerValue.ToString();
        _isGameInProgress = false;
        _isUserWin = false;
        _pinsState = new PinsState(firstPinStartValue, secondPinStartValue, thirdPinStartValue);
        _initialPinsState = _pinsState;
        _changesFirst = intsFirstVals.Split(',').ToList().ConvertAll(n => Convert.ToInt32(n.Trim()));
        _changesSecond = intsSecondVals.Split(',').ToList().ConvertAll(n => Convert.ToInt32(n.Trim()));
        _changesThird = intsThirdVals.Split(',').ToList().ConvertAll(n => Convert.ToInt32(n.Trim()));
        UpdatePinsAndWinCondition();
    }

    /// <summary>
    /// Клик на первый инструмент
    /// </summary>
    public void FirstInstrumentClick()
    {
        if (!_isGameInProgress)
        {
            return;
        }

        _pinsState.UpdatePins(_changesFirst[0], _changesFirst[1], _changesFirst[2]);
        UpdatePinsAndWinCondition();
    }

    /// <summary>
    /// Клик на второй инструмент
    /// </summary>
    public void SecondInstrumentClick()
    {
        if (!_isGameInProgress)
        {
            return;
        }

        _pinsState.UpdatePins(_changesSecond[0], _changesSecond[1], _changesSecond[2]);
        UpdatePinsAndWinCondition();
    }

    /// <summary>
    /// Клик на третий инструмент
    /// </summary>
    public void ThirdInstrumentClick()
    {
        if (!_isGameInProgress)
        {
            return;
        }

        _pinsState.UpdatePins(_changesThird[0], _changesThird[1], _changesThird[2]);
        UpdatePinsAndWinCondition();
    }

    void Update()
    {
        if (!_isGameInProgress)
        {
            return;
        }

        _timePassed += Time.deltaTime;

        if (Math.Round(timeForGame - _timePassed, 0) == 0)
        {
            StopGame();
            _isUserWin = false;
            return;
        }

        if (timerText.text != (timeForGame - _timePassed).ToString("00.0").Replace(".", ":"))
        {
            timerText.text = (timeForGame - _timePassed).ToString("00.0").Replace(".", ":");
        }
    }

    /// <summary>
    /// Остановка игры
    /// </summary>
    private void StopGame()
    {
        winPanel.SetActive(true);
        winText.text = _isUserWin ? "Вы выиграли!" : "Вы проиграли!";
        _isGameInProgress = false;
        timerText.text = "00:00";
    }

    /// <summary>
    /// Сброс игры для init значений
    /// </summary>
    public void RestartGame()
    {
        winPanel.SetActive(false);
        _isUserWin = false;
        _pinsState = _initialPinsState;
        UpdatePinsAndWinCondition();
        _isGameInProgress = true;
        _timePassed = 0;
    }

    /// <summary>
    /// Первый старт игры. Сброс до init значений
    /// </summary>
    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        RestartGame();
    }

    /// <summary>
    /// Обновить значения пинов и проверить условия выигрыша
    /// </summary>
    private void UpdatePinsAndWinCondition()
    {
        firstPin.text = _pinsState.First.ToString();
        secondPin.text = _pinsState.Second.ToString();
        thirdPin.text = _pinsState.Third.ToString();

        if (_pinsState.First == answerValue && _pinsState.Second == answerValue && _pinsState.Third == answerValue)
        {
            _isUserWin = true;
            StopGame();
        }
    }
}
