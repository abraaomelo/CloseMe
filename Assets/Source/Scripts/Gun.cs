using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
   public GameObject bulletPrefab;
   public GameObject gameOverInstance;
   //public float bulletSpeed = 15f;
      public float bulletSpeed = 40f; //for debug delete later

//    public float fireRate = 0.5f;
    public float fireRate = 0.1f; //for debug delete later
   public Transform firePoint;
  
    public ButtonSendEmailController emailController;

    void Start()
    {
        StartCoroutine(ShootRoutine());   
    }

    IEnumerator ShootRoutine(){
        while (true){
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }

    void Shoot(){
        if (bulletPrefab != null && firePoint != null && !gameOverInstance.activeInHierarchy && !emailController.emailSentBool){
            //Initiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null){
                Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 shootDirection = (targetPosition - (Vector2)firePoint.position).normalized;

                rb.velocity = shootDirection * bulletSpeed;
            }
        }
    }
}