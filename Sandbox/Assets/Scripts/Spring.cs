using UnityEngine;

public class Spring : MonoBehaviour {
    private Rigidbody SpringRigidbody;
    private float StartTimer;
    private float StartPush;
    private const float PeriodTimer = 1f;
    private const float PeriodPush = 0.5f;

    void Start() {
        StartTimer = PeriodTimer;
        SpringRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (StartTimer - Time.time < 0) {
            StartPush = Time.time + PeriodPush;
            StartTimer = Time.time + PeriodTimer;
            return;
        }

        if (StartPush - Time.time < 0) {
            SpringRigidbody.AddForce(0, -20000, 0);
        }
    }
}
