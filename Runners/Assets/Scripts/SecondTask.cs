using UnityEngine;

public class SecondTask : MonoBehaviour
{
    [SerializeField] private Transform[] runnersTransforms;

    [SerializeField] private float movementSpeed;

    [SerializeField] private float passDistance;

    private int _nextRunnerNumber;
    private Transform _currentRunnerTransform;
    private Transform _targetRunnerTransform;
    
    private void Start()
    {
        _currentRunnerTransform = runnersTransforms[0];
        _nextRunnerNumber = 1;
        _targetRunnerTransform = runnersTransforms[_nextRunnerNumber];
        _currentRunnerTransform.LookAt(_targetRunnerTransform);
        _currentRunnerTransform.transform.Rotate( 0, 180, 0);
    }

    private void Update()
    {
        Transform newRunner = _targetRunnerTransform;
        Vector3 currentRunnerPosition = _currentRunnerTransform.position;
        currentRunnerPosition = Vector3.MoveTowards(currentRunnerPosition, newRunner.position, Time.deltaTime * movementSpeed);
        _currentRunnerTransform.position = currentRunnerPosition;

        if (Vector3.Distance(currentRunnerPosition, newRunner.position) < passDistance)
        {
            ChangeRunner();       
        }
    }
    
    private void ChangeRunner()
    {
        if (_nextRunnerNumber + 1 == runnersTransforms.Length)
        {
            _currentRunnerTransform = runnersTransforms[_nextRunnerNumber];
            _nextRunnerNumber = 0;
            _targetRunnerTransform = runnersTransforms[_nextRunnerNumber];
        }
        else
        {
            _currentRunnerTransform = runnersTransforms[_nextRunnerNumber];
            _nextRunnerNumber++;
            _targetRunnerTransform = runnersTransforms[_nextRunnerNumber];
        }

        _currentRunnerTransform.LookAt(_targetRunnerTransform);
        _currentRunnerTransform.transform.Rotate( 0, 180, 0);
    }
}
