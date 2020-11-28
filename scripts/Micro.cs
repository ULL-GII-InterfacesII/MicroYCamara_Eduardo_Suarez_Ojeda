using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Micro : MonoBehaviour
{
    public int microActivo;
    public int tiempoGrabacion;
    private Renderer rd;
    private AudioSource audioo;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        tiempoGrabacion = 5;
        Play.botonPlay += playAudio;
        audioo = GetComponent<AudioSource>();
        rd = GetComponent<Renderer>();
        rd.material.color = Color.green;
        microActivo = 0;
        findMicrophones();

        yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            Debug.Log("Microphone found");
        }
        else
        {
            Debug.Log("Microphone not found");
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void findMicrophones()
    {
        int i = 0;
        foreach (var device in Microphone.devices)
        {
            i++;
            Debug.Log("Name #" + i.ToString() + ": " + device);
        }
    }

    public void startRecordingAudio ()
    {
        rd.material.color = Color.red;
        audioo.clip = Microphone.Start("", false, tiempoGrabacion, 44100);
    }

    IEnumerator cambiarColor() {
        yield return new WaitForSeconds(tiempoGrabacion);
        rd.material.color = Color.green;
    }

    void playAudio ()
    {
        Debug.Log("Reproduciendo");
        audioo.Play();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player")) {
            startRecordingAudio();
            StartCoroutine(cambiarColor());
        }
    }
}
