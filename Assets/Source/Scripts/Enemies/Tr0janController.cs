using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

public class Tr0janController : MonoBehaviour
{
       [SerializeField] private float moveSpeed = 2f;
       private List<Transform> pathPoints = new List<Transform>();
       private int currentTargetIndex = 0;
       private int direction = 1;
       private bool gotKey=false;
       

    void Start()
    {
        
        int randompath = Random.Range(1,3);
        Debug.Log("RANDOM PATH: "+randompath);
        GameObject[] pathObjects = GameObject.FindGameObjectsWithTag("path1");

        if(randompath==2){
         pathObjects = GameObject.FindGameObjectsWithTag("path2");
        }

        foreach(GameObject obj in pathObjects){
            pathPoints.Add(obj.transform);
        }

        pathPoints.Sort((a,b) => a.name.CompareTo(b.name));

        if (pathPoints.Count > 0){
            transform.position = pathPoints[0].position;
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
        {

            Debug.Log("O primeiro colision funciona");
            if (collision.gameObject.tag == "bullet")
            {
                Debug.Log("Fui acertado");
                Destroy(gameObject);
                //Destroy(collision.gameObject);               
            }
        }

    void Update()
    {
        Transform keygen = transform.Find("KeygenTr0jan");
        if (pathPoints.Count == 0) return;

        // Move towards the current target
        transform.position = Vector2.MoveTowards(transform.position, pathPoints[currentTargetIndex].position, moveSpeed * Time.deltaTime);

        // Check if reached the current target
        if (Vector2.Distance(transform.position, pathPoints[currentTargetIndex].position) < 0.1f)
        {
            // If at the last point, reverse direction
            if (currentTargetIndex == pathPoints.Count - 1)
            {
                direction = -1; // Move backward
                gotKey = true;
                keygen.gameObject.SetActive(true);
            }
            // If at the first point, reverse direction
            else if (currentTargetIndex == 0)
            {
                direction = 1; // Move forward
            }

            if (gotKey && currentTargetIndex==0){
                Destroy(gameObject);
                ReachedStartPoint();

            }

            // Update the target index
            currentTargetIndex += direction;

    }
}
      void ReachedStartPoint(){
          BrowserController brow = FindAnyObjectByType<BrowserController>();
            brow.CreateRandomAd();
            brow.CreateRandomAd();
            brow.CreateRandomAd();
        }

       
}

