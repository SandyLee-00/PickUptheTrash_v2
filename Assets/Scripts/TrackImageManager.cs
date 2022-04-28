using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class TrackImageManager : MonoBehaviour
{
    private ARTrackedImageManager _trackedImgManager;

    void Awake()
    {
        _trackedImgManager = GetComponent<ARTrackedImageManager>();
        Debug.Log("MoveTeoRecycleScene1111111111");
    }

    public void OnEnable()
    {
        _trackedImgManager.trackedImagesChanged += OnImageChanged; // subscribe
    }
    public void OnDisable()
    {
        _trackedImgManager.trackedImagesChanged -= OnImageChanged; // unsubscribe
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImg in args.updated)
        {
            Debug.Log("MoveTeoRecycleScene2222222");
            moveToScene(trackedImg);
        }
    }
    private void moveToScene(ARTrackedImage trackedImg)
    {
        if (trackedImg.trackingState == TrackingState.Tracking)
        {
            Debug.Log("MoveTeoRecycleScene");
            SceneManager.LoadScene("Recycle");
        }
    }
}
