using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giro : MonoBehaviour
{
    [SerializeField] float _velocidad = 30f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _velocidad,
            Space.World);
    }
}
