using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSpawnedTrashName : MonoBehaviour
{
    public Text spawnedTrashName;
    public GameObject spawnedTrash;
    private GameObject spawnedTrashChild;

    void Start()
    {
        
    }

    void Update()
    {
        spawnedTrashChild = spawnedTrash.transform.GetChild(0).gameObject;
        spawnedTrashName.text = spawnedTrashChild.name;
    }
}
