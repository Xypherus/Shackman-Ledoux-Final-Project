﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    // Start is called before the first frame update

    //public bool playerInSight;
    public Vector2 lastSeen;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("On Trigger Enter");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("In Compare Tag");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position);
            if(hit.collider.tag == "Player")
            {
                Debug.Log("In Raycast Check");
                GetComponentInParent<Enemy>().seePlayer = true;
            }
        }
    }
}
