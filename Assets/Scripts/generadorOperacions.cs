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
        velocidadGeneracion = 12f;
        haIniciado = false;
    }

    void Update()
    {
       /* if (jugador.GetComponent<Player>().seHaMovido)
        {
            Debug.Log("GeneradorOperacions: Jugador s'ha mogut.");
            if (!haIniciado)
            {
                Debug.Log("GeneradorOperacions: Es crida el InvokeRepeating.");
                InvokeRepeating("GenerarOperacio", 0f, velocidadGeneracion);
                haIniciado = true;
                
            }
            
        }*/
    }

    public void IniciGeneracioOperacions()
    {
        InvokeRepeating("GenerarOperacio", 2f, velocidadGeneracion);
    }

    void GenerarOperacio()
    {
        // Crear una nueva instancia del prefab de operacion en la posición aleatoria
        GameObject nuevaOperacio = Instantiate(senalautopista, new Vector2(7.2f, 6), Quaternion.identity);
    }

    /*public void aturarGeneracioOperacio()
    {
        Debug.Log("escrida");
        CancelInvoke("GenerarOperacio");
       
    }*/

    public void PosarIniciarFalse()
    {
        haIniciado = false;
    }

    public void AturarGeneracioOperacions()
    {
        Debug.Log("GeneradorOperacions: CancelInvoke.");
        haIniciado = false;
        CancelInvoke("GenerarOperacio");
    }

}


