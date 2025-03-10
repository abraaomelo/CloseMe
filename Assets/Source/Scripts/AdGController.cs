using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGController : MonoBehaviour
{

    public HealthBarController healtBarOBJ;
    [SerializeField] private float maxHealth = 50f;
    private float currentHealth;
    public AntivirusApp antivirus;

    private void Start()
    {
      currentHealth=maxHealth;
      antivirus.InitialPercentCalc(currentHealth);
      healtBarOBJ = GetComponentInChildren<HealthBarController>();   
      antivirus.AddHP(maxHealth);
    }

    void Update()
    {
       // LifeCheck();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="bullet"){ 
            currentHealth -= 1;  

            healtBarOBJ.UpdateHealthBar(maxHealth,currentHealth);
            antivirus.AdHit();

            if (currentHealth <= 0){
                antivirus.Ad1stDestroyed();
                Destroy(gameObject);
            }
        }           
    }

   public void SetAntivirus(AntivirusApp app)
{
    antivirus = app;
}



}
