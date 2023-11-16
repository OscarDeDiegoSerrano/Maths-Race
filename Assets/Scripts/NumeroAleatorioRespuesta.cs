using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumeroAleatorioRespuesta : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabRespuesta; // Cambia el nombre de la variable al correspondiente prefab.

    void Start()
    {
        GenerarNumeroAleatorio();
    }

    void GenerarNumeroAleatorio()
    {
        // Genera un número aleatorio entre 20 y 100.
        int numeroAleatorio = Random.Range(20, 101);

        gameObject.GetComponent<TMPro.TextMeshPro>().text = numeroAleatorio.ToString();

    }
}