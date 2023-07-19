using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    float tiempoVidaExplosion = 3.0f;

    public void HacerDanyo()
    {
        Destroy(this.gameObject);
        GameObject newExplosion = Instantiate(explosionPrefab, 
            this.transform.position, Quaternion.identity);
        Destroy(newExplosion, tiempoVidaExplosion);
    }

}
