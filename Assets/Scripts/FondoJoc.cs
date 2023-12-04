using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoJoc : MonoBehaviour
{
    public float velocidadDesplazamiento = 1f;

    private float backgroundHeight;
    private Transform otroFondo;

    void Start()
    {
        // Obtén la altura del fondo
        backgroundHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        // Crea el otro fondo
        otroFondo = Instantiate(gameObject, new Vector3(0f, backgroundHeight, 5f), Quaternion.identity).transform;
    }

    void Update()
    {
        // Calcula el desplazamiento en base a la velocidad y el tiempo
        float desplazamiento = velocidadDesplazamiento * Time.deltaTime;

        // Mueve el fondo inferior hacia abajo
        transform.Translate(Vector3.down * desplazamiento);

        // Mueve el fondo superior hacia abajo
        otroFondo.Translate(Vector3.down * desplazamiento);

        // Si el fondo inferior ha salido completamente de la pantalla, reposiciónalo arriba del fondo superior
        if (transform.position.y < -backgroundHeight)
        {
            transform.position = new Vector3(transform.position.x, otroFondo.position.y + backgroundHeight, transform.position.z);
        }

        // Si el fondo superior ha salido completamente de la pantalla, reposiciónalo arriba del fondo inferior
        if (otroFondo.position.y < -backgroundHeight)
        {
            otroFondo.position = new Vector3(otroFondo.position.x, transform.position.y + backgroundHeight, otroFondo.position.z);
        }
    }
}
