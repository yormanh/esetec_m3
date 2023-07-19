using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideAttack : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosionPrefab;
    [SerializeField] float distanciaAtaque = 2f;
    [SerializeField] float danyo = 10f;
    Transform _player;
 
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

 
    void Update()
    {
        float distancia = Vector3.Distance(this.transform.position,
            _player.position);

        if (distancia < distanciaAtaque)
        {
            //TODO daño al jugador

            ParticleSystem newExplosion = Instantiate(
                _explosionPrefab, this.transform.position, 
                Quaternion.identity);
        }
    }
}
