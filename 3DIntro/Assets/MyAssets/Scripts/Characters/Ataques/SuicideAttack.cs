using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideAttack : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosionPrefab;
    [SerializeField] float distanciaAtaque = 2f;
    [SerializeField] int danyo = 10;
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
            //daño al jugador
            _player.GetComponent<Player>().HacerDanyo(danyo);

            ParticleSystem newExplosion = Instantiate(
                _explosionPrefab, this.transform.position, 
                Quaternion.identity);

            //Destroy(newExplosion.gameObject, newExplosion.main.duration);
            Destroy(newExplosion.gameObject, 1.0f);
            Destroy(this.gameObject);
        }
    }
}
