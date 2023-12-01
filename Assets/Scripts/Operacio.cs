using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operacio : MonoBehaviour
{
    // Start is called before the first frame update
    public int Numero { get; set; }
    public string ImagenFondo { get; set; }

    // Puedes ajustar esta variable para controlar la velocidad de descenso

    private void Start()
    {
        ImagenFondo = "IMGoperacion"; // Establecer el fondo de imagen como "imagen1"
    }

    private void Update()
    {
        // Mover hacia abajo con una velocidad mayor
        transform.Translate(Vector2.down * Time.deltaTime);

        // Obtener el tamaño de la pantalla en unidades del mundo
        float screenHeight = Camera.main.orthographicSize;

        // Si el objeto sale de la pantalla, destruirlo
        if (transform.position.y < -screenHeight)
        {
            Destroy(gameObject);
        }
    }
}
