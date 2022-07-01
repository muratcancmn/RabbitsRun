using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitTrigger : MonoBehaviour
{
    private float Damage=10;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        transform.rotation=Quaternion.Euler(0,180,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.Damage(Damage);
        }
    }
}
