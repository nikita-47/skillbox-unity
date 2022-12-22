using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text circleText;
    public TMP_Text lastCircleTimeText;
    
    private float currentLapTime = 0;
    private int lapsNumber = 0;
    private float lastLapTime = 0;
    private bool isGameStarted = false;
    private float gameStartTime;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            currentLapTime = Mathf.Round(Time.time - gameStartTime);
            timerText.text = currentLapTime.ToString();   
        }
    }

    public void StartGame()
    {
        if (!isGameStarted)
        {
            gameStartTime = Time.time;
            isGameStarted = true;
            currentLapTime = 0;
            timerText.text = currentLapTime.ToString();   
        }
    }
    
    public void LapFinishesButtonClick()
    {
        if (isGameStarted)
        {
            lapsNumber++;
            circleText.text = $"Laps count: {lapsNumber.ToString()}";

            var lastCircleTime = currentLapTime - lastLapTime;
            lastLapTime = currentLapTime;
            lastCircleTimeText.text = $"Last circe time: {lastCircleTime.ToString()}";   
        }
    }
}

