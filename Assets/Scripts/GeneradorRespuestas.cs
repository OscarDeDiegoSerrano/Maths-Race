using UnityEngine;

public class GeneradorRespuestas : MonoBehaviour
{
    public GameObject jugador;
    private float velocidadGeneracion;
    public bool haIniciado;
    public GameObject respuestaPrefab;

    private Vector2 posEsquerra;
    private Vector2 posCentre;
    private Vector2 posDreta;

    void Start()
    {
        velocidadGeneracion = 8;
        haIniciado = false;
        posEsquerra = new Vector2(-2.3f, 6);
        posCentre = new Vector2(0, 6);
        posDreta = new Vector2(2.3f, 6);
    }

    void Update()
    {

    }

    public void GenerarRespuestas()
    {
        GameObject operacioAleatoria = GameObject.Find("textOperacio");

        if (operacioAleatoria != null)
        {
            //Debug.Log("GenerarRespuestas");
            GameObject nuevaRespuesta1 = Instantiate(respuestaPrefab, posEsquerra, Quaternion.identity);
            GameObject nuevaRespuesta2 = Instantiate(respuestaPrefab, posCentre, Quaternion.identity);
            GameObject nuevaRespuesta3 = Instantiate(respuestaPrefab, posDreta, Quaternion.identity);

        

            int[] posiciones = { 0, 1, 2 };
            RandomizeArray(posiciones);

            int respuestaCorrecta = operacioAleatoria.GetComponent<OperacioAleatoria>().ObtenerResultado();
            int respuestaIncorrecta1 = respuestaCorrecta + Random.Range(-10, 10);
            int respuestaIncorrecta2 = respuestaCorrecta + Random.Range(-10, 10); // TODO
                                                                                //NumeroAleatorioRespuesta ne = nuevaRespuesta1.GetComponentInChildren<NumeroAleatorioRespuesta>();
            nuevaRespuesta1.GetComponentInChildren<TMPro.TextMeshPro>().text = respuestaIncorrecta1.ToString();
            nuevaRespuesta2.GetComponentInChildren<TMPro.TextMeshPro>().text = respuestaIncorrecta2.ToString();
            nuevaRespuesta3.GetComponentInChildren<TMPro.TextMeshPro>().text = respuestaCorrecta.ToString();
            nuevaRespuesta3.GetComponent<Respuesta>().hacerlaCorrecta();

            nuevaRespuesta1.transform.position = GetPosicion(posiciones[0]);
            nuevaRespuesta2.transform.position = GetPosicion(posiciones[1]);
            nuevaRespuesta3.transform.position = GetPosicion(posiciones[2]);
        }
        else
        {
            Debug.LogError("OperacioAleatoria script not found");
        }
    }

    Vector2 GetPosicion(int index)
    {
        switch (index)
        {
            case 0:
                return posEsquerra;

            case 1:
                return posCentre;

            case 2:
                return posDreta;

            default:
                return Vector2.zero;
        }
    }

    void RandomizeArray(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    // Nuevo m�todo para detener la generaci�n de respuestas
    public void PosarIniciFalse()
    {
        haIniciado = false;
        CancelInvoke("GenerarRespuestas");
    }

    public void SetRespuestaCorrecta(int respuestaCorrecta)
    {
        //Debug.Log("Respuesta correcta establecida: " + respuestaCorrecta);
        // Aqu� puedes hacer algo m�s con la respuesta correcta si es necesario
    }
}
