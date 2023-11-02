using System;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorRespuestas : MonoBehaviour
{
    public GameObject jugador;
    private float velocidadGeneracion;
    public bool haIniciado;
    public GameObject respuestaPrefab; // Asigna el prefab de Respuestas en el inspector

    void Start()
    {
        velocidadGeneracion = 8;
        haIniciado = false;
    }

    void Update()
    {
        if (jugador.GetComponent<Player>().seHaMovido)
        {
            if (!haIniciado)
            {
                InvokeRepeating("GenerarRespuestas", 0f, velocidadGeneracion);
                haIniciado = true;
            }
        }
    }

    void GenerarRespuestas()
    {
        // Crear una nueva instancia del prefab de Respuestas en la posición aleatoria
        GameObject nuevaRespuesta1 = Instantiate(respuestaPrefab, new Vector3(-2.3f, 6,0), Quaternion.identity);
        GameObject nuevaRespuesta2 = Instantiate(respuestaPrefab, new Vector3(0, 6, 0), Quaternion.identity);
        GameObject nuevaRespuesta3 = Instantiate(respuestaPrefab, new Vector3(2.3f, 6, 0), Quaternion.identity);
    }

    public void aturarGeneracioRespostes()
    {
        CancelInvoke("GenerarRespuestas");
    }

}


