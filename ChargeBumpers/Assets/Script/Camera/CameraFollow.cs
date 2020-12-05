using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private Vector3 cameraPosition;

    private void Awake()
    {
        cameraPosition = transform.localPosition;
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(target.transform.localPosition);

        Vector3 updatePos = new Vector3(cameraPosition.x,
            cameraPosition.y,
            cameraPosition.z + target.transform.localPosition.z);

        transform.localPosition = updatePos;
    }
}
