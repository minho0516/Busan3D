using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl instance;
    public float xRotate;
    public float yRotate;
    public float xRotateMove;
    private float yRotateMove;

    [SerializeField] private float rotateSpeed = 500.0f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        CameraController();
    }

    private void CameraController ()
    {
        xRotateMove = -Input.GetAxis("Mouse Y") * rotateSpeed;
        yRotateMove = Input.GetAxis("Mouse X") * rotateSpeed;

        yRotate = transform.eulerAngles.y + yRotateMove;
        //xRotate = transform.eulerAngles.x + xRotateMove; 
        xRotate = xRotate + xRotateMove;

        xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정

        transform.eulerAngles = new Vector3(xRotate, transform.eulerAngles.y, 0);
    }
}
