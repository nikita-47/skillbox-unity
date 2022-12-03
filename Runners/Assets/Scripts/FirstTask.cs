using UnityEngine;

public class FirstTask : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField] 
    private Vector3[] points;
    
    [SerializeField] 
    private GameObject mainObject;

    private bool _isForward;
    private int _nextTargetNumber;
    private Vector3 _targetPositionVector3;

    private void Start()
    {
        _isForward = true;
        mainObject.transform.position = points[0];
        _targetPositionVector3 = points[_nextTargetNumber];
    }
    
    private void Update()
    {
        Vector3 currentPosition = mainObject.transform.position;
        currentPosition = Vector3.MoveTowards(currentPosition, _targetPositionVector3, Time.deltaTime * movementSpeed);
        mainObject.transform.position = currentPosition;
        
        if (mainObject.transform.position != _targetPositionVector3) return;

        ChangeNextTarget();
    }

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

        _targetPositionVector3 = points[_nextTargetNumber];
    }
}
