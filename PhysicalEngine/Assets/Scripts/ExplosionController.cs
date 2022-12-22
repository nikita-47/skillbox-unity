using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionPower;

    /// <summary>
    /// Взорвать бомбу
    /// </summary>
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider block in colliders)
        {
            float distance = Vector3.Distance(transform.position, block.transform.position);
            Vector3 direction = block.transform.position - transform.position;
            Rigidbody attachedRigidbody = block.attachedRigidbody;
            
            if (attachedRigidbody != null)
            {
                attachedRigidbody.AddForce(direction.normalized * explosionPower * (explosionRadius - distance), ForceMode.Impulse);
            }
        }
    }
}
