using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private Text timerText;

    private float _timePassed;
    private bool _isTimerInProgress;
    private float _raidCycleTime;
    
    public delegate void TimerFinished();
    public static event TimerFinished OnFinished;

    private void Start()
    {
        _isTimerInProgress = false;
    }


    /// <summary>
    /// Запуска таймера текущемуго рейда
    /// </summary>
    /// <param name="raidCycleTime">Время рейда</param>
    public void StartTimer(float raidCycleTime)
    {
        _raidCycleTime = raidCycleTime;
        _isTimerInProgress = true;
        _timePassed = 0;
    }

    private void Update()
    {
        if (!_isTimerInProgress) return;

        _timePassed += Time.deltaTime;
        if (_raidCycleTime - _timePassed <= 0)
        {
            timerText.text = "0";
            _isTimerInProgress = false;
            OnFinished?.Invoke();
        }
        else if (timerText.text != (_raidCycleTime - _timePassed).ToString("00"))
        {
            timerText.text = (_raidCycleTime - _timePassed).ToString("00");
        }
    }
}
