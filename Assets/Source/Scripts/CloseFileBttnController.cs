using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloseFileBttnController : MonoBehaviour
{
    public GameObject thisFObj;
    public void OnClickClose(){
    thisFObj.SetActive(false);
    }
}
