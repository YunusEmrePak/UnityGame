using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public float speed = 5f;
    public float minX = 0f;
    public float maxX = 0f;
    public float minZ = 0f;
    public float maxZ = 0f;
    private int direction = 1;
    public string axis;

    void Start() {
        minX = transform.position.x - 6f;
        maxX = transform.position.x + 6f;
        minZ = transform.position.z - 6f;
        maxZ = transform.position.z + 6f;
    }

    void Update()
    {
        if (axis == "x") {
            float newX = transform.position.x + (direction * speed * Time.deltaTime * 1.5f);
            if (newX <= minX)
            {
                direction = 1;
                newX = minX;
            }
            else if (newX >= maxX)
            {
                direction = -1;
                newX = maxX;
            }

            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
        else {
            float newZ = transform.position.z + (direction * speed * Time.deltaTime * 1.5f);
            if (newZ <= minZ)
            {
                direction = 1;
                newZ = minZ;
            }
            else if (newZ >= maxZ)
            {
                direction = -1;
                newZ = maxZ;
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
            }
        
    }
}
