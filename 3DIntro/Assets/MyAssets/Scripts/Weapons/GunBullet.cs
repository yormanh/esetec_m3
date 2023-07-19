using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    [SerializeField] float tiempoVida = 3.0f;
    int damage;

    //Prpiedades
    public int GetDamage()
    {
        return damage;
    }
    public void SetDamage(int value)
    {
        damage = value;
    }


    void Start()
    {
        Destroy(this.gameObject, tiempoVida);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) //other.name == "Enemy"
        {
            //Destroy(other.gameObject);
            other.GetComponent<Enemy>().HacerDanyo();
        }

        Destroy(this.gameObject);
    }


}
