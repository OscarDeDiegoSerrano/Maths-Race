using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumeroAleatorioRespuesta : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabRespuesta; // Cambia el nombre de la variable al correspondiente prefab.
    
    
    //desde el resultat consultar del generadorOperacions el resultat correcte.
    //Amb aquest resultta correcte el numero consultat

    void Start()
    {
        gameObject.GetComponent<TMPro.TextMeshPro>().text = "";
    }

    public void setNumber(int number) {
        gameObject.GetComponent<TMPro.TextMeshPro>().text = number.ToString();
        Debug.Log(number + "..........");
    }
}