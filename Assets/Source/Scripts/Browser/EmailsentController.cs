using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmailsentController : MonoBehaviour
{
    
    public void MenuButtonEmailSent(){
        Time.timeScale=1f;
        SceneManager.LoadScene(0);
    }
}
