using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyVision : MonoBehaviour
{
    bool detectPlayer;
    public Transform player;
    public Text detectText;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        detectText.text = "Unseen";
    }
    //Based off code from https://learn.unity.com/tutorial/enemies-part-1-static-observers?projectId=5caf65ddedbc2a08d53c7acb#5caf91d9edbc2a0c0aee490e
    // Update is called once per frame
    void Update()
    {
        if (detectPlayer)
        {
            Vector3 dir = player.position - enemy.position + Vector3.up;
            Ray ray = new Ray(enemy.position, dir);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                detectText.text = "Detected";
            }
            else
            {
                detectText.text = "Hidden";
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            detectPlayer = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            detectPlayer = false;
            detectText.text = "Unseen";
        }
            
    }
}
