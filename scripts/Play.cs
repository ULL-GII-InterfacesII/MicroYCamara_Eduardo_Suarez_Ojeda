using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void eventoPlay();

public class Play : MonoBehaviour
{
    public static event eventoPlay botonPlay;
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
            botonPlay();
        }
    }
}
