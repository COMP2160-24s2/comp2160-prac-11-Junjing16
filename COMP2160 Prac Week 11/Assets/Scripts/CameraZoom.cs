using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; 
    // Zoom settings
    public float zoomSpeed = 10f;               
    public float minOrthographicSize = 2f;      
    public float maxOrthographicSize = 10f;     
    public float minFOV = 15f;                  
    public float maxFOV = 90f;                  

    private InputAction zoomAction;            

    void Awake()
    {
        var actions = new Actions();            
        zoomAction = actions.camera.zoom;        
    }

    void OnEnable()
    {
        zoomAction.Enable();                    
    }

    void OnDisable()
    {
        zoomAction.Disable();                   
    }

    void Update()
    {
        float zoomValue = zoomAction.ReadValue<float>();

        if (mainCamera.orthographic)
        {
            mainCamera.orthographicSize -= zoomValue * zoomSpeed * Time.deltaTime;
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minOrthographicSize, maxOrthographicSize);
        }
        else
        {
            mainCamera.fieldOfView -= zoomValue * zoomSpeed * Time.deltaTime;
            mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, minFOV, maxFOV);
        }
    }
}
