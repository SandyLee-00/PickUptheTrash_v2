using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeSceneBtn()
    {
        if(SceneManager.GetActiveScene().name == "Recycle")
        {
            SceneManager.LoadScene("Pickingroad");
        }
        if(SceneManager.GetActiveScene().name == "Pickingroad")
        {
            SceneManager.LoadScene("Recycle");
        }

    }
}
