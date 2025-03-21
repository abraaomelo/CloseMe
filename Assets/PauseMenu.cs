using System.Collections;

using System.Collections.Generic;

using JetBrains.Annotations;

using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class PauseMenu : MonoBehaviour

{

public GameObject pausemenu;

public Button resumebdsm, restartb, menub;




void Start()
{
    Time.timeScale=0f;
}
public void Home ()
{

SceneManager.LoadScene(0);
}

public void Resume ()

{

pausemenu.SetActive(false);
Time.timeScale=1f;
resumebdsm.interactable=true;
}

public void Restart ()

{
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
}