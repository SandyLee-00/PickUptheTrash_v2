using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        //위치 권한 요청 - 송시은
        /*if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartButton()
    {
        SceneManager.LoadScene("Game01_Pick");
    }
}
