using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera firstTaskCamera;
    [SerializeField] private Camera secondTaskCamera;
    
    private void Start()
    {
        ShowSecondTask(); // со второго интереснее
    }

    public void ShowFirstTask()
    {
        firstTaskCamera.enabled = true;
        secondTaskCamera.enabled = false;
    }
    
    public void ShowSecondTask()
    {
        firstTaskCamera.enabled = false;
        secondTaskCamera.enabled = true;
    }
}
