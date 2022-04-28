using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour
{
    //메인 카메라에서 z축으로 쓰레기가 떨어진 정도
    public float cameraDistanceZ;
    private Vector3 spawnPos;

    //쓰레기 배열로 프리팹 넣어놓기 
    [SerializeField]
    public GameObject[] trashes;
    private int spawnTrashNum;

    private GameObject spawnedTrash;

    //새로운 쓰레기 랜덤하게 생성하기

    //클릭 확인
    private bool mousePressed;
    Vector3 mousePosition;

    //________쓰레기 던지기 ______
    private GameObject trashbin;
    private string trashbinType;
    private Vector3 trashbinPos;

    private string trashType;
    private Vector3 trashPos;

    public float throwSpeed;

    private bool isthrow = false;

    //float timer;

    //소리 추가 

    void Start()
    {
        spawnTrash();

    }

    void Update()
    {
        //클릭 체크
        mousePressed = Input.GetMouseButtonDown(0);
        if (mousePressed)
        {
            mousePosition = Input.mousePosition;

            //쓰레기 있으면 기존 쓰레기 없애기
            if (spawnedTrash != null && isthrow == true)
            {
                GameManager.score -= 1;
            }
        }
        //쓰레기 없으면 새로 만들기
        if (spawnedTrash == null)
        {
            spawnTrash();
            isthrow = false;
            //맞으면 점수 +2
            GameManager.score += 2;
        }

        //if (isthrow == true)
        //{
        //    timer += Time.deltaTime;
        //    Debug.Log(timer);
        //    if (timer > 5)
        //    {
        //        isthrow = false;
        //        Destroy(spawnedTrash);
        //        timer = 0;
        //    }
        //}
    }
    private void FixedUpdate()
    {
        //쓰레기통 클릭하면 쓰레기통 타입 받아오기
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (mousePressed && Physics.Raycast(ray, out hit, 200))
        {
            trashbin = hit.collider.gameObject;
            trashbinType = hit.collider.gameObject.tag;
            trashbinPos = trashbin.transform.position;

            Debug.Log("trashbinType : " + trashbinType);
            Debug.Log("spawnedTrashType : " + trashbinType);

            //쓰레기와 쓰레기통 태그 같으면 쓰레기 없애기
            if (trashbinType == trashType)
            {
                isthrow = true;
                //Debug.Log("TrashPos : " + trashPos);
                //Debug.Log("TrashbinPos : " + trashbinPos);
                Debug.Log("Sucess!");
                Destroy(spawnedTrash);
                                
            }
            else
            {
                isthrow = true;
                Debug.Log("Retry!");
            }
        }
        //if (isthrow == true && spawnedTrash != null)
        //{
        //    trashToTrashbin(trashbinPos, trashPos);
        //    //위치 차이에 따라서 충돌 판정 
        //    //if((trashbinPos.x - trashPos.x) < 0.1 &&
        //    //    (trashbinPos.y - trashPos.y) < 0.1 &&
        //    //    (trashbinPos.z - trashPos.z) < 0.1)
        //    //{
        //    //    Destroy(trash);
        //    //    isthrow = false;
        //    //}
        //}

    }

    private void spawnTrash()
    {
        //메인 카메라 위치 가져오기
        Vector3 cameraPos = Camera.main.transform.position;
        spawnPos = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z + cameraDistanceZ);

        //전체 쓰레기 길이 가져와서 랜덤하게 선택하기
        int totalTrashNum = trashes.Length;
        spawnTrashNum = Random.Range(0, totalTrashNum);
        spawnedTrash = Instantiate(trashes[spawnTrashNum], spawnPos, Quaternion.identity);

        trashType = spawnedTrash.tag;
        trashPos = spawnedTrash.transform.position;
        
    }

    private void trashToTrashbin(Vector3 trashbinPos, Vector3 trashPos)
    {

        Vector3 dir = trashbinPos - trashPos;
        dir = dir.normalized;
        Vector3 newPos = dir * throwSpeed;
        spawnedTrash.transform.position += newPos * Time.deltaTime;
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
