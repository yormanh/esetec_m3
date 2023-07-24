using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplitud : MonoBehaviour
{
    [SerializeField] float _frecuency = 1;
    [SerializeField] float _amplitud = 1;


    void Start()
    {
        
    }

    
    void Update()
    {
        //sin (x * p) + a
        float sin = Mathf.Sin(Time.time * _frecuency) + _amplitud;
        transform.position = new Vector3(transform.position.x, 
            sin, transform.position.z);
    }
}
