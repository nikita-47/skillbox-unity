using UnityEngine;

public class SuperRocket : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    
    [SerializeField]
    private float force;
    
    [SerializeField] 
    private Transform[] points;
    
    private bool _isForward;
    private int _nextTargetNumber;
    private Vector3 _targetPositionVector3;

    private void Start()
    {
        _isForward = true;
        transform.position = points[0].position;
        _targetPositionVector3 = points[_nextTargetNumber].position;
    }
    
    private void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition = Vector3.MoveTowards(currentPosition, _targetPositionVector3, Time.deltaTime * movementSpeed);
        transform.position = currentPosition;
        
        if (transform.position != _targetPositionVector3) return;

        ChangeNextTarget();
    }

    /// <summary>
    /// Столкновение с врагом
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody target = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 direction = collision.gameObject.transform.position- transform.position;
        Vector3 hitForce = direction.normalized * force;
        
        if (target != null)
        {
            target.AddForce(hitForce, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Смена направления рокеты
    /// </summary>
    private void ChangeNextTarget()
    {
        if (_isForward)
        {
            if (_nextTargetNumber != points.Length - 1)
            {
                _nextTargetNumber += 1;
            }
            else
            {
                _isForward = false;
                _nextTargetNumber -= 1;
            }
        }
        else
        {
            if (_nextTargetNumber == 0)
            {
                _isForward = true;
                _nextTargetNumber += 1;
            }
            else
            {
                _nextTargetNumber -= 1;
            }
        }

        _targetPositionVector3 = points[_nextTargetNumber].position;
        transform.LookAt(_targetPositionVector3, Vector3.left);
    }
}
