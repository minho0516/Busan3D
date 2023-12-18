using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float BulletSpeed = 10;
    private Rigidbody rd;
    private Vector3 move;

    private void OnEnable()
    {
        rd = GetComponent<Rigidbody>();
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        move = transform.forward;

        rd.velocity = move * BulletSpeed;
    }
}
