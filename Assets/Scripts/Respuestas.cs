using UnityEngine;

public class Respuesta : MonoBehaviour
{
    private int numeroAleatorio;
    private float velocidadDescenso = 2.0f; // Ajusta la velocidad de descenso seg�n tus necesidades.

    void Start()
    {
        // Generar un n�mero aleatorio entre 100 y 1000.
        numeroAleatorio = Random.Range(100, 1001);

        // Configurar el texto del objeto "Respuesta" con el n�mero aleatorio.
        TextMesh texto = GetComponent<TextMesh>();
        texto.text = numeroAleatorio.ToString();

        // Posicionar el objeto en la parte superior de la pantalla.
        Vector3 posicionInicial = transform.position;
        posicionInicial.y = 6.0f; // Ajusta la posici�n inicial en Y seg�n tus necesidades.
        transform.position = posicionInicial;
    }

    void Update()
    {
        // Hacer que el objeto descienda gradualmente.
        transform.Translate(Vector3.down * velocidadDescenso * Time.deltaTime);

        // Si el objeto sale de la pantalla, destruirlo.
        if (transform.position.y < -6.0f) // Ajusta el valor seg�n el tama�o de la pantalla.
        {
            Destroy(gameObject);
        }
    }
}
