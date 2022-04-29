using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public int score = 0;

    void Start()
    {
        Debug.Log("Start");

        //???? ???? ???? - ??????
        /*if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }*/
    }

    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Pickingroad_Sieun");
    }

    public void InfoButton()
    {
        SceneManager.LoadScene("Information");
    }
}
