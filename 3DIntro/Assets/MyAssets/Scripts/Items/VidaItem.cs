using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaItem : MonoBehaviour
{
    [SerializeField] int vida = 50;
    [SerializeField] AudioClip pickAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //compareTag
        {
            other.gameObject.GetComponent<Player>().SetVida(vida);
            AudioSource.PlayClipAtPoint(pickAudio,
                this.transform.position);
            Destroy(this.gameObject);

        }
    }
}
