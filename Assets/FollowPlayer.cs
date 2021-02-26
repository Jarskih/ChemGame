using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private static CinemachineVirtualCamera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }


    public static void SetFollow(Transform target)
    {
        _camera.Follow = target;
    }   
}
