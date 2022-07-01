using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnRandomPoints : MonoBehaviour
{
    [SerializeField]
    private GameObject Clone;
    private Transform[] Points;
    private void Start()
    {
        InvokeRepeating("InstantiateClone",0f,3f);
    }
    void InstantiateClone()
    {
        Points = gameObject.transform.GetComponentsInChildren<Transform>();
        Debug.Log(Points.Length + " Points " + gameObject.name);
       Destroy(Instantiate(Clone, Points[Random.Range(1, Points.Length)].position, Quaternion.identity),5f);
    }
}
