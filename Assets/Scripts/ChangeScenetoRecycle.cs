using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenetoRecycle : MonoBehaviour
{
   
    public void ChangeSceneBtn()
    {
        if (SceneManager.GetActiveScene().name == "Pickingroad_Sieun")
        {
            SceneManager.LoadScene("Recycle");
        }
    }
}
