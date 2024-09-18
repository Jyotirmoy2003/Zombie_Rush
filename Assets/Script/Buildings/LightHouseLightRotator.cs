using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseLightRotator : MonoBehaviour
{
    [SerializeField] Transform root;
    [SerializeField] float rotationSpeed=3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        root.Rotate(Vector3.forward*rotationSpeed*Time.deltaTime);
    }
}
