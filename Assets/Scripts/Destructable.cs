using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject _destroyedSprite;

    private void OnTriggerEnter2D (Collider2D other)
    {

        if (other.transform.CompareTag ("Player"))
        {
            if (gameObject.tag == "Food")
            {
                GameManager.instance.currentPlayerScore += GameManager.instance.foodScore;
            }
            AudioManager.Play (AudioClipName.FoodCollected);
            if (_destroyedSprite)
            {
                Instantiate (_destroyedSprite, transform.position, transform.rotation);
                Destroy (gameObject);
            }
            else
            {
                Destroy (gameObject);
            }
        }
    }

}