using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth){
        image.fillAmount = currentHealth/maxHealth;
    }

}
