using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    // Start is called before the first frame update

    public bool playerInSight;
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
        if (collision.CompareTag("Player"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position);
            if(hit.collider.tag == "Player")
            {
                GetComponentInParent<Enemy>().seePlayer = true;
            }
        }
    }
}
