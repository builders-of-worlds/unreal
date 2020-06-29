using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            Debug.Log("Hello");

        }


    }
}
