using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Weapon : MonoBehaviour
{
    [SerializeField] Bullet _bullet;
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;

    private Transform _targetPosition;
    private bool isWork = true;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while (isWork)
        {
            Vector3 _direction = (_targetPosition.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_bullet, transform.position + _direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = _direction;
            newBullet.GetComponent<Rigidbody>().velocity = _direction * _speed * Time.deltaTime;

            yield return waitForSeconds;
        }
    }
}