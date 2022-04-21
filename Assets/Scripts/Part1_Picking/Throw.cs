using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{

    public AudioSource audio1; // when thouch the trahs -> sound play ~
    public LayerMask trash;
    GameObject currenthit;

    void Update()
    {
        //raycasting
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;


            Touch touch = Input.GetTouch(0);
            Debug.Log(Input.GetTouch(0));

            // Halve the size of the cube.

            // when cat hit
            if (touch.phase == TouchPhase.Began &&
                   Physics.Raycast(ray, out hit, Mathf.Infinity, trash))
            {
                    currenthit = hit.collider.gameObject;
                    Destroy(currenthit);
                    audio1.Play();
           
            }

         //   transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.World);
        }
    }
}
