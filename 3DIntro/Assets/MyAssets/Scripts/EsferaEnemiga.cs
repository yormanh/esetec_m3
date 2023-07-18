using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaEnemiga : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private GameObject _player;
    [SerializeField] private float distanciaMinima;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //this.transform.LookAt(_player.transform, Vector3.up); 

        //a quien quiero mirar - desde donde quiero mirar (desde donde estoy)
        Vector3 direction = _player.transform.position - this.transform.position;
        //direction.Normalize();
        transform.rotation = Quaternion.LookRotation(direction);

        //Si queremos que avanza en z
        //transform.position += new Vector3(0,0,1);
        //transform.position += direction.normalized * velocidad * Time.deltaTime;

        if (direction.magnitude > distanciaMinima)
        {
            transform.position += direction.normalized * velocidad * Time.deltaTime;
        }


    }
}
