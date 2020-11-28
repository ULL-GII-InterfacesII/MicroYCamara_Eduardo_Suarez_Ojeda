using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int velocidad;
    private Transform tf;
    private Renderer rd;
    private Vector3 ea;
    private bool pressedQ;
    private bool pressedE;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 3; 
        tf = GetComponent<Transform>();
        rd = GetComponent<Renderer>();
        rd.material.color = Color.blue;
        ea = tf.rotation.eulerAngles;
        pressedQ = false;
        pressedE = false;
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * velocidad);
        if (Input.GetKeyDown(KeyCode.E)) {
            pressedE = true;
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            pressedE = false;
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            pressedQ = true;
        }
        if (Input.GetKeyUp(KeyCode.Q)) {
            pressedQ = false;
        }
        if (pressedE) {
            tf.rotation = Quaternion.Euler(0, ea.y + 1f * Time.deltaTime, 0);
            ea.y += 1;
        }
        if (pressedQ) {
            tf.rotation = Quaternion.Euler(0, ea.y - 1f * Time.deltaTime, 0);
            ea.y -= 1;
        }
    }
}
