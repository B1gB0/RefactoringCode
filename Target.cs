using UnityEngine;

public class Target : MonoBehaviour
{
    private Transform _target;
    private Transform[] _targetPoints;
    private float _speed;
    private int _numberPoint;

    private void Start()
    {
        _targetPoints = new Transform[_target.childCount];

        for (int i = 0; i < _target.childCount; i++)
            _targetPoints[i] = _target.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform targetPoint = _targetPoints[_numberPoint];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        if (transform.position == targetPoint.position)
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