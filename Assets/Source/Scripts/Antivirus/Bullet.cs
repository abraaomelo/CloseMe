using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 1f;  // Destroy bullet after 3 seconds

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the bullet when touching any boxcollider..
        if (collision.gameObject.GetComponent<BoxCollider2D>() != null)
        {
           Destroy(gameObject);
        }

        // if (collision.gameObject.tag=="trojanvirus"){
        //     Destroy(gameObject);
        // }

    
    }

    
}