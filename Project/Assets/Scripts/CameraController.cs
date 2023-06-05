using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform igrac;


   private void Update()
    {
        transform.position = new Vector3(igrac.position.x,igrac.position.y,transform.position.z);
    }
}
