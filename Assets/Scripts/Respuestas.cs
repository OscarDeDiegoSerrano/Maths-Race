using UnityEngine;

public class Respuesta : MonoBehaviour
{
    private int numeroAleatorio;
    private float velocidadDescenso = 2.0f; // Ajusta la velocidad de descenso según tus necesidades.

    void Start()
    {
        // Generar un número aleatorio entre 100 y 1000.
        numeroAleatorio = Random.Range(100, 1001);

        // Configurar el texto del objeto "Respuesta" con el número aleatorio.
        TextMesh texto = GetComponent<TextMesh>();
        texto.text = numeroAleatorio.ToString();

        // Posicionar el objeto en la parte superior de la pantalla.
        Vector3 posicionInicial = transform.position;
        posicionInicial.y = 6.0f; // Ajusta la posición inicial en Y según tus necesidades.
        transform.position = posicionInicial;
    }

    void Update()
    {
        // Hacer que el objeto descienda gradualmente.
        transform.Translate(Vector3.down * velocidadDescenso * Time.deltaTime);

        // Si el objeto sale de la pantalla, destruirlo.
        if (transform.position.y < -6.0f) // Ajusta el valor según el tamaño de la pantalla.
        {
            Destroy(gameObject);
        }
    }
}
