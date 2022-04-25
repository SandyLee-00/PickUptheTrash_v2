using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTrash : MonoBehaviour
{
    [SerializeField]
    private GameObject trash;
    private GameObject[] trashes;
    
    private bool mousePressed;
    Vector3 mousePosition;

    private GameObject trashbin;
    private string trashbinType;
    private string trashType;

    //소리 추가

    void Start()
    {
        
    }

    void Update()
    {
        mousePressed = Input.GetMouseButtonDown(0);
        if (mousePressed)
        {
            Debug.Log("mouse pressed");
            mousePosition = Input.mousePosition;
            //audioSource.Play();
        }

        //각 쓰레기 타입 받아오기
        trashType = trash.tag;
    }

    private void FixedUpdate()
    {
        //쓰레기통 클릭하면 쓰레기통 타입 받아오기
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (mousePressed && Physics.Raycast(ray, out hit, 2000))
        {
            trashbin = hit.collider.gameObject;
            trashbinType = hit.collider.gameObject.tag;
            Debug.Log("trashbinType : " + trashbinType);

            //쓰레기와 쓰레기통 태그 같으면 쓰레기 없애기
            if(trashbinType == trashType)
            {
                Destroy(trash);
                Debug.Log("Sucess!");
            }
            else
            {
                Debug.Log("Retry!");
            }

        }
    }
}
