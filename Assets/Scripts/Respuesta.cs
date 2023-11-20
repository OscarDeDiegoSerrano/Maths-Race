using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respuestas : MonoBehaviour
{
    public int Numero { get; set; }
    public string ImagenFondo { get; set; }

    private void Start()
    {
        Numero = UnityEngine.Random.Range(20, 101); // Generar n�mero aleatorio entre 20 y 100
        ImagenFondo = "IMGrespuesta"; // Establecer el fondo de imagen como "imagen1"
    }

    private void Update()
    {
        // Mover hacia abajo
        transform.Translate(Vector3.down * Time.deltaTime);

        // Obtener el tama�o de la pantalla en unidades del mundo
        float screenHeight = Camera.main.orthographicSize;

        // Si el objeto sale de la pantalla, destruirlo
        if (transform.position.y < -screenHeight)
        {
            Destroy(gameObject);

            // Adem�s, si deseas realizar alguna acci�n adicional al destruir el objeto, puedes llamar al m�todo correspondiente en GeneradorRespuestas
            GeneradorRespuestas generadorRespuestas = FindObjectOfType<GeneradorRespuestas>();
            if (generadorRespuestas != null)
            {
                generadorRespuestas.PosarIniciFalse();
            }
        }
    }
}



