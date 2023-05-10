using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 45, 45) * Time.deltaTime);
    }

}
