using UnityEngine;

public class PathFinding : MonoBehaviour
{
    private Transform _allTargetPoints;
    private Transform[] _targetPoints;
    private float _speed;
    private int _numberPoint;

    private void Start()
    {
        _targetPoints = new Transform[_allTargetPoints.childCount];

        for (int i = 0; i < _allTargetPoints.childCount; i++)
            _targetPoints[i] = _allTargetPoints.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform _targetPoint = _targetPoints[_numberPoint];
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, _speed * Time.deltaTime);

        if (transform.position == _targetPoint.position)
            SetDirection();
    }

    private Vector3 SetDirection()
    {
        _numberPoint++;

        if (_numberPoint == _targetPoints.Length)
            _numberPoint = 0;

        Vector3 targetPosition = _targetPoints[_numberPoint].transform.position;
        transform.forward = targetPosition - transform.position;

        return targetPosition;
    }
}