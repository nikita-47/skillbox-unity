using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private int force; 
    
    private Rigidbody _springRigidbody;
    private float _startTimer;
    private float _startPush;
    private const float PeriodTimer = 1f;
    private const float PeriodPush = 0.5f;

    private void Start() {
        if (force == 0)
        {
            force = 50000;
        }
        _startTimer = PeriodTimer;
        _springRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (_startTimer - Time.time < 0) {
            _startPush = Time.time + PeriodPush;
            _startTimer = Time.time + PeriodTimer;
            return;
        }

        if (_startPush - Time.time < 0) {
            _springRigidbody.AddForce(0, -force, 0);
        }
    }
}
