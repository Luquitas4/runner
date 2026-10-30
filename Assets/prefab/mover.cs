using UnityEngine;

public class MoverIzquierda : MonoBehaviour
{
    public float velocidad = 6f;
    public float limiteIzquierdo = -15f; // Cuando pasa este punto en X, se destruye

    void Update()
    {
        // Se mueve a la izquierda constante
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);

        // Si es un obstáculo y se fue de la pantalla, lo borramos para no saturar memoria
        if (transform.position.x < limiteIzquierdo && CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }
    }
}