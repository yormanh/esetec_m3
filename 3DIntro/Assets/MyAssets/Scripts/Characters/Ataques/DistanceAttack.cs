using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] Transform turretPivot;
    [SerializeField] Rigidbody balaPrefab;
    [SerializeField] int danyo = 10;
    [SerializeField] float tiempoEntreDisparos = 3f;
    [SerializeField] float distanciaAtaque = 30f;
    [SerializeField] float fuerzaDisparo = 50f;

    Transform _player;
    bool isShooting;
    float tiempoParaDisparar;
    
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }


    
    void Update()
    {
        Vector3 playerPosition = _player.position;
        playerPosition.y = playerPosition.y + 1;

        turretPivot.LookAt(playerPosition);

        float distanciaAljugador = Vector3.Distance(
            this.transform.position, _player.transform.position );
        

        if (distanciaAljugador < distanciaAtaque)
        {
            if (Time.time > tiempoParaDisparar)
            {
                Rigidbody newBala = Instantiate(balaPrefab,
                    shootPoint.position, shootPoint.rotation);
                newBala.AddForce(shootPoint.forward * fuerzaDisparo,
                    ForceMode.Impulse);
                newBala.GetComponent<GunBullet>().SetDamage(danyo);

                tiempoParaDisparar = Time.time + tiempoEntreDisparos;
            }
        }

    }
}
