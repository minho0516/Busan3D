using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;
public class Gun : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    private Animator anime;
    private bool canShoot = true;
    private Vector3 cameraRotatation;
    private void Awake()
    {
        anime = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(CameraControl.instance.xRotate, transform.eulerAngles.y, transform.eulerAngles.z);

        if (Input.GetMouseButtonDown(0)&&canShoot)
        {
            StartCoroutine(Shoot());
        }
        
        IEnumerator Shoot()
        {
            anime.SetTrigger("Shoot");
            canShoot = false;

            cameraRotatation = CameraControl.instance.transform.localRotation.eulerAngles;

            Instantiate(Bullet, transform.GetChild(0).position, CameraControl.instance.transform.rotation);

            yield return new WaitForSeconds(0.35f);
            anime.SetTrigger("Shoot");
            canShoot = true;
        }
    }
}
