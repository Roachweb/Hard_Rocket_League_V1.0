using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cam : MonoBehaviour
{

    GameObject Target;

    private float mx = 0.0f;

    private float my = 0.0f;

    //sensitivity
    private int mxSpeed = 5;



    public float MaxViewDistance = 35f;
    public float MinViewDistance = 15f;
    public int ZoomRate = 20;
    private int lerpRate = 5;
    private float distance = 8f;
    private float desireDistance;

    private float currentDistance;

    protected float cameraTargetHeight = -2.37f;

   

    void Awake()
    {
        
            if (!Target)
            {
                Target = GameObject.FindGameObjectWithTag("Player");
            }
       
      
    }

    void Start()
    {
        Vector3 Angles = transform.eulerAngles;
        mx = Angles.x;
        my = Angles.y;
        currentDistance = distance;
        desireDistance = distance;

    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            mx += Input.GetAxis("Mouse X") * mxSpeed;
            //my += Input.GetAxis("Mouse Y") * mySpeed;
        }
        else if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            float targetRotantionAngle = Target.transform.eulerAngles.y;
            float cameraRotationAngle = transform.eulerAngles.y;
            mx = Mathf.LerpAngle(cameraRotationAngle, targetRotantionAngle, lerpRate * Time.deltaTime);
        }

        my = ClampAngle(my, -15, 85);
        Quaternion rotation = Quaternion.Euler(my + 20, mx, 0);

       /// desireDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * ZoomRate * Mathf.Abs(desireDistance);
        ////desireDistance = Mathf.Clamp(desireDistance, MinViewDistance, MaxViewDistance);
        

        Vector3 position = Target.transform.position - (rotation * Vector3.forward * desireDistance);

        position = Target.transform.position - (rotation * Vector3.forward * currentDistance + new Vector3(0, cameraTargetHeight, 0));

        transform.rotation = rotation;
        transform.position = position;

        float cameraX = transform.rotation.x;

        // Right click drag to control the camera's rotation.
        if (Input.GetMouseButton(1))
        {
            Target.transform.eulerAngles = new Vector3(cameraX, transform.eulerAngles.y, transform.eulerAngles.z);
        }


    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}

