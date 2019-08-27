using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Door;

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
            Door.SetActive(false);
        }
    }
}
