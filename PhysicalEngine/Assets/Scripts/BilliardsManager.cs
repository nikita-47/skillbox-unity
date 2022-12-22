using UnityEngine;
using UnityEngine.SceneManagement;

public class BilliardsManager : MonoBehaviour
{
    [SerializeField]
    private float force;

    [SerializeField] 
    private GameObject cueBall;
    
    private Rigidbody _rigidbodyCueBall;
    
    private void Start()
    {
        _rigidbodyCueBall = cueBall.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Ударить по красному шару
    /// </summary>
    public void HitCueBall()
    {
        _rigidbodyCueBall.AddForce(Vector3.right * force, ForceMode.Impulse);
    }

    public void Restart()
    {
        SceneManager.LoadScene("BilliardsScene");
    }
}
