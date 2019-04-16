using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _panSpeed = 30f;
    [SerializeField] private float _borderOffset = 10f;
    [SerializeField] private float _zoomSpeed = 60f;
    [SerializeField] private float minY = 20f;
    [SerializeField] private float maxY = 70f;

    private float _zoom;
    private bool doMove = false;
    private void Update() 
    {
        if (Input.GetKey(KeyCode.Space))
            doMove = !doMove;
        
        if(!doMove)
            return;
        
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - _borderOffset)
            CameraUp();

        
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= _borderOffset)
            CameraDown();
  
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= _borderOffset)
            CameraLeft();

        
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - _borderOffset)
        {
            CameraRight();
        }
        
        _zoom = Input.GetAxis("Mouse ScrollWheel");

        CameraZoom(_zoom);
    }

    public void CameraUp()
    {
        transform.Translate( Vector3.left * _panSpeed * Time.deltaTime, Space.World);
    }
    
    public void CameraDown()
    {
        transform.Translate(Vector3.right * _panSpeed * Time.deltaTime, Space.World);
    }
    
    public void CameraLeft()
    {
        transform.Translate(Vector3.back * _panSpeed * Time.deltaTime, Space.World);
    }

    public void CameraRight()
    {
        transform.Translate(Vector3.forward * _panSpeed * Time.deltaTime, Space.World);
    }

    public void CameraZoom(float coeffZoom)
    {
        var pos = transform.position;

        pos.y -= coeffZoom * _zoomSpeed * 100f * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

}
