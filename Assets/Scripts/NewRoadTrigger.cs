using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoadTrigger : MonoBehaviour
{
    public GameObject RoadPrefab;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(RoadPrefab, transform.position, Quaternion.identity);
        }
    }
}
