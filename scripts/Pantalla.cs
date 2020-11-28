using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantalla : MonoBehaviour
{
    private WebCamTexture imagen;
    // Start is called before the first frame update
    IEnumerator Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void findWebCams()
    {
        foreach (var device in WebCamTexture.devices)
        {
            Debug.Log("Name: " + device.name);
        }
    }
}
