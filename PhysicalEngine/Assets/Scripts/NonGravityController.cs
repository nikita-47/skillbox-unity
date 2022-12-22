using UnityEngine;

/// <summary>
/// Шар отключения гравитации
/// </summary>
public class NonGravityController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody component = other.GetComponent<Rigidbody>();
        component.useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody component = other.GetComponent<Rigidbody>();
        component.useGravity = true;
    }
}
