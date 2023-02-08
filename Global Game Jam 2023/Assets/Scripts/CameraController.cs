using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float moveSpeed;
    [SerializeField] float zoomSpeed;
    [SerializeField] float zoomLevel;
    [SerializeField] float zoomMin;
    [SerializeField] float zoomMax;
    [SerializeField] MapSystem map;

    // Update is called once per frame
    void Update()
    {
        move();
        zoom();
    }

    void zoom()
    {
        if (Input.GetKey(KeyCode.E) && zoomLevel < zoomMax)
        {
            zoomLevel += zoomSpeed;
        }
        else if (Input.GetKey(KeyCode.Q) && zoomLevel > zoomMin)
        {
            zoomLevel -= zoomSpeed;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            zoomLevel += zoomSpeed * 3;
            if (zoomLevel > zoomMax)
            {
                zoomLevel = zoomMax;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            zoomLevel -= zoomSpeed * 3;
            if (zoomLevel < zoomMin)
            {
                zoomLevel = zoomMin;
            }
        }

        camera.orthographicSize = zoomLevel;
    }

    void move()
    {
        Vector3 moveDirection = new Vector3();

        if (Input.GetKey(KeyCode.W) && camera.transform.position.y < map.maxHeight)
        {
            moveDirection.y = moveSpeed / zoomLevel;
        }
        if (Input.GetKey(KeyCode.S) && camera.transform.position.y > 0f)
        {
            moveDirection.y -= moveSpeed / zoomLevel;
        }
        if (Input.GetKey(KeyCode.A) && camera.transform.position.x > 0)
        {
            moveDirection.x -= moveSpeed / zoomLevel;
        }
        if (Input.GetKey(KeyCode.D) && camera.transform.position.x < map.mapX)
        {
            moveDirection.x = moveSpeed / zoomLevel;
        }


        camera.transform.position += moveDirection;
    }
}
