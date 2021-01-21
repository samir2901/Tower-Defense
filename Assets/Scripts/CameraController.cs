using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed = 20f;
    //[SerializeField] private float panBorderThickness = 10f;
    [SerializeField] private float zoomSpeed = 400f;
    [SerializeField] private float maxScrollOffset = 40f;
    [SerializeField] private Vector3 limit; 
    
    void Update()
    {
        Vector3 pos = transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        pos.z += verticalInput * panSpeed * Time.deltaTime;
        pos.x += horizontalInput * panSpeed * Time.deltaTime;      

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * zoomSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, limit.y - maxScrollOffset, limit.y);
        pos.x = Mathf.Clamp(pos.x, -limit.x, limit.x);
        pos.z = Mathf.Clamp(pos.z, -limit.z, limit.z);
        transform.position = pos;
    }
}
