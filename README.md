# MicroYCamara_Eduardo_Suarez_Ojeda

### Enlace al github:

https://github.com/ULL-GII-InterfacesII/MicroYCamara_Eduardo_Suarez_Ojeda.git

### Introducción:

Para la realización de esta práctica he optado por una escena 3D en la cual el usuario mueve un cubo que hace de "Jugador" con el que mediante colisiones trigger puede interactuar con los diferentes elementos.

### Escena:
![](ii1.JPEG)

Tenemos un rectángulo que actúa como pantalla de la imágen que llega desde la cámara, un cubo, en principio verde, que sirve para comenzar la grabación mediante el micrófono por defecto del sistema, un elemento con forma de cápsula que al colisionar con el jugador lanza el audio grabado anteriormente y por último una esfera que al colisionar con el jugador detienee/reanuda la grabación de la cámara.

### Ejemplo Grabación:

![](ii2.gif)

### Ejemplo Pausar cámara:

![](ii3.gif)

### Código:

Para empezar, desde los elementos que simbolizan la cámara y el micro se usarán las funciones para buscar dichos dispositivos y en mostrar el nombre de los mismos por el log de la consola, o mostrar que no se han encontrado si ese es el caso.

El jugador será un cubo sencillo al que se le ha añadido un character controller para que se pueda desplazar por la escena mediante las teclas 'aswd' o las flechas. También puede rotar con las teclas 'e' y 'q'.

#### Micrófono:

En el caso del micro, he guardado la configuración y las funciones de micro en el cubo verde, que al ser tocado por el jugador cambia de color a rojo y graba por el micrófono default durante 5 segundos y a continuación vuelve a su color original. Para realizar el lapsus de tiempo llamo a una función StartCoroutine con una función especial como parámetros que espera 5 segundos y después modifica el color del objeto.

El valor 5 está puesto por defecto y se puede modificar mediante una variable pública en el inspector del objeto micro.

```c#
IEnumerator cambiarColor() {
    yield return new WaitForSeconds(tiempoGrabacion);
    rd.material.color = Color.green;
}
```

Para poder usar el elemento en forma de cápsula como botón de play he creado un delegado de evento en el script de la cápsula y al colisionar con el jugador lanza el evento al que previamente se le ha asignado la función correspondiente en el script del micro para lanzar el audio.

#### Cámara:

Para la cámara he usado la clase WebCamTexture para guardar la imagen obtenida por ella y se la he asignado como textura al render del rectángulo proyector.

Dado que es un caso similar el anterior he realizado lo mismo con los eventos creando uno en el script de la esfera y añadiendole la función del scrip de la pantalla que pausa/reanuda la grabación.
