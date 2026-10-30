using UnityEngine;

public class MoverIzquierda : MonoBehaviour
{
    public float velocidad = 6f;
    public float limiteIzquierdo = -15f; 

    void Update()
    {
        // Se mueve a la izquierda constante
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);

        
        if (transform.position.x < limiteIzquierdo && CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }
    }
}