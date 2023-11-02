using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorOperacions : MonoBehaviour
{
    public GameObject jugador;
    private float velocidadGeneracion;
    public bool haIniciado;
    public GameObject senalautopista; // Asigna el prefab de operacion en el inspector

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
                InvokeRepeating("GenerarOperacio", 0f, velocidadGeneracion);
                haIniciado = true;
            }
        }
    }

    void GenerarOperacio()
    {
        // Crear una nueva instancia del prefab de operacion en la posición aleatoria
        GameObject nuevaOperacio = Instantiate(senalautopista, new Vector3(7.2f, 6, 0), Quaternion.identity);
    }

    public void aturarGeneracioOperacio()
    {
        CancelInvoke("GenerarOperacio");
    }

}


