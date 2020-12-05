using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    [SerializeField] private float currentSpeed = 5f;
    private bool pressed = false;
    private bool rotated = false;
    void Start()
    {
        
    }

    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * currentSpeed * verticalInput * Time.deltaTime);
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotated = true;
            transform.Rotate(new Vector3(0, -1, 0)); ;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }


    }
}
