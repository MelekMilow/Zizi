using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int lubenice = 0;

    [SerializeField] private Text lubeniceText;
    [SerializeField] private AudioSource collectionAudioEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Lubenica"))
        {
            collectionAudioEffect.Play();
            Destroy(collision.gameObject);
            lubenice++;
            lubeniceText.text = "Broj lubenica: " + lubenice;
        }
    }
}
