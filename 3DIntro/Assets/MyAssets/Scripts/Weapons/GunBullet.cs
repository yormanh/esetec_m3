using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    [SerializeField] float tiempoVida = 3.0f;
    [SerializeField] int damage = 100;

    //identificar a quien vamos a disparar
    [SerializeField] string targetTag = "Enemy";

    //Propiedades
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
        if (other.CompareTag(targetTag)) //other.name == "Enemy"
        {
            if (other.GetComponent<DamageableCharacter>() != null)
            {
                //Destroy(other.gameObject);
                other.GetComponent<DamageableCharacter>().HacerDanyo(damage);
            }
            //ya que puede colisionar con el padre que si tenga el tag
            else if (other.GetComponentInParent<DamageableCharacter>() != null)
            {
                other.GetComponentInParent<DamageableCharacter>().HacerDanyo(damage);
            }

        }
        //detruimos la bala
        Destroy(this.gameObject);
    }


}
