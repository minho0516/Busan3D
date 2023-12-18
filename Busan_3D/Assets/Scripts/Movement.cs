using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("value")]
    [SerializeField] public static float speed = 5f;
    [SerializeField] private float jumpPower = 10f;

    [Header("getCompernent")]
    private Rigidbody characterRigidbody;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
        Rotate();
        Running();
    }

    private void Move()
    {
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * Z + transform.right * X;

        move *= speed;

        move.y = characterRigidbody.velocity.y;

        characterRigidbody.velocity = move;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterRigidbody.velocity = Vector3.zero;
            characterRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void Rotate()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, CameraControl.instance.yRotate, transform.eulerAngles.z);
    }

    private void Running()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 7;
        }
        else
        {
            speed = 5;
        }
    }

    
}
