using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void eventoStop();

public class Stop : MonoBehaviour
{
    public static event eventoStop pararReanudar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player")) {
            pararReanudar();
        }
    }
}
