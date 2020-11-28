using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantalla : MonoBehaviour
{
    private WebCamTexture imagen;
    private bool estaParada;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Stop.pararReanudar += playPause;
        findWebCams();

        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.Log("webcam found");
        }
        else
        {
            Debug.Log("webcam not found");
        }
        imagen = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = imagen;
        imagen.Play();
        estaParada = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playPause() {
        Debug.Log("Evento pantalla");
        if (estaParada) {
            imagen.Play();
        } else {
            imagen.Pause();
        }
        estaParada = !estaParada;
    }

    void findWebCams()
    {
        foreach (var device in WebCamTexture.devices)
        {
            Debug.Log("Name: " + device.name);
        }
    }
}
