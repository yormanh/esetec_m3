using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] float tiempoEntreOleadas = 10f;
    [SerializeField] float enemigosPorOleada = 5;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float radioSpawn = 50;

    void Start()
    {
        InvokeRepeating("GenerarOleada", tiempoEntreOleadas, tiempoEntreOleadas);
    }

    void GenerarOleada()
    {
        for (int i = 0; i < enemigosPorOleada; i++)
        {
            Vector2 puntoAleatorio2D = Random.insideUnitCircle;

            Vector3 puntoAleatorio = new Vector3(
                puntoAleatorio2D.x, 0f, puntoAleatorio2D.y);
           

            puntoAleatorio.Normalize();

            Vector3 puntoSpawn = this.transform.position +
                puntoAleatorio * radioSpawn;

            Instantiate(enemyPrefab, puntoSpawn, Quaternion.identity);

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, radioSpawn);
    }





    void Update()
    {
        
    }
}
