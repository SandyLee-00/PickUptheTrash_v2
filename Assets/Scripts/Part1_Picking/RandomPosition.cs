using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector3 pos;

    void Start()
    {
        x = Random.Range(-3, 3);
        y = -2.615177f;
        z = Random.Range(-3, 3);
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 40, 0) * Time.deltaTime);
    }
}
