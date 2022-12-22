using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionCameraManager : MonoBehaviour
{
    [SerializeField] private Camera firstCamera;
    [SerializeField] private Camera secondCamera;

    /// <summary>
    /// Переключить камеру для наблюдения взрыва
    /// </summary>
    public void TogglerCamera()
    {
        firstCamera.enabled = !firstCamera.enabled;
        secondCamera.enabled = !secondCamera.enabled;
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("ExplosionScene");
    }
}
