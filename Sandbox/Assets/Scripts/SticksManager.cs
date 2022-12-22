using UnityEngine;
using UnityEngine.Animations;

public class SticksManager : MonoBehaviour {
    public GameObject LeftStick;
    public GameObject RightStick;
    private HingeJoint LeftStickJoint;
    private HingeJoint RightStickJoint;

    private void Awake() {
        RightStickJoint = RightStick.GetComponent<HingeJoint>();
        LeftStickJoint = LeftStick.GetComponent<HingeJoint>();
    }

    void Update() {
        LeftStickJoint.useMotor = Input.GetKey(KeyCode.LeftArrow);
        RightStickJoint.useMotor = Input.GetKey(KeyCode.RightArrow);
    }
}
