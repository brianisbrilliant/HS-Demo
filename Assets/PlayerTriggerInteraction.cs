using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerInteraction : MonoBehaviour
{
    public int totalKeys = 0;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Door")) {
            if(totalKeys > 0) {
                Destroy(other.gameObject);
                totalKeys -= 1;
            }
            else {
                Debug.Log("You need a key!");
            }
        }
        if(other.gameObject.CompareTag("Key")) {
            Destroy(other.gameObject);
            totalKeys += 1;
        }
        if(other.gameObject.CompareTag("AI")) {
            Application.LoadLevel(0);
        }
    }
}
