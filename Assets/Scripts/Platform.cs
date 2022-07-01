using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 10f);
    }
}
