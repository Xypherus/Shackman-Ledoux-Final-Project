using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearing : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private GameObject enemy;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && player.GetComponent<PlayerController>().makingNoise == true) 
        {
            Debug.Log("Heard Player!!!");
            enemy.GetComponent<Enemy>().playernoiseLocation = player.transform.position;
            enemy.GetComponent<Enemy>().heardPlayer = true;
        }
    }
}
