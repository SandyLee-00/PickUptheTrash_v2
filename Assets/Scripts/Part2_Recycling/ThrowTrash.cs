using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTrash : MonoBehaviour
{
    public GameObject trash;

    public GameObject[] trashes;

    private bool mousePressed;
    Vector3 mousePosition;

    private GameObject trashbin;
    private string trashbinType;
    private Vector3 trashbinPos;

    private string trashType;
    private Vector3 trashPos;

    public float throwSpeed;

    private bool isthrow = false;

    float timer;

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

        //타이머 5초 작동
        if (isthrow == true)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer > 5)
            {
                isthrow = false;
                Destroy(trash);
                timer = 0;


            }
        }


    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        //쓰레기통 클릭하면 쓰레기통 타입 받아오기
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (mousePressed && Physics.Raycast(ray, out hit, 2000))
        {
            trashbin = hit.collider.gameObject;
            trashbinType = hit.collider.gameObject.tag;

            trashPos = trash.transform.position;
            trashbinPos = trashbin.transform.position;

            Debug.Log("trashbinType : " + trashbinType);

            //쓰레기와 쓰레기통 태그 같으면 쓰레기 없애기
            if (trashbinType == trashType)
            {
                isthrow = true;

                Debug.Log("TrashPos : " + trashPos);
                Debug.Log("TrashbinPos : " + trashbinPos);

                Debug.Log("Sucess!");

            }
            else
            {
                Debug.Log("Retry!");
            }

        }
        if (isthrow == true && trash != null)
        {
            trashToTrashbin(trashbinPos, trashPos);
            //위치 차이에 따라서 충돌 판
            //if((trashbinPos.x - trashPos.x) < 0.1 &&
            //    (trashbinPos.y - trashPos.y) < 0.1 &&
            //    (trashbinPos.z - trashPos.z) < 0.1)
            //{
            //    Destroy(trash);
            //    isthrow = false;

            //}


        }


    }
    //충돌해서 쓰레기 없앤 후 쓰레기 , 쓰레기통 위치 초기화 , 표시 해놓기

    private void trashToTrashbin(Vector3 trashbinPos, Vector3 trashPos)
    {

        Vector3 dir = trashbinPos - trashPos;
        dir = dir.normalized;
        Vector3 newPos = dir * throwSpeed;
        trash.transform.position += newPos * Time.deltaTime;
        //trash.transform.Translate(dir * throwSpeed * Time.deltaTime);

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject == trashbin)
    //    {
    //        Debug.Log("destory trash");
    //        Destroy(trash);
    //    }
    //    Debug.Log(collision.gameObject.name);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other.gameObject.name);
    //}
}
