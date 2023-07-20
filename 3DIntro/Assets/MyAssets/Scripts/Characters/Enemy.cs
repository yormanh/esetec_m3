using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageableCharacter
{
    [SerializeField] GameObject explosionPrefab;
    float tiempoVidaExplosion = 3.0f;

    protected override void Morir()
    {
        base.Morir();

        Destroy(this.gameObject);
        GameObject newExplosion = Instantiate(explosionPrefab, 
            this.transform.position, Quaternion.identity);
        Destroy(newExplosion, tiempoVidaExplosion);
    }

}
