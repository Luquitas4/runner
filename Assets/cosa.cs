using UnityEngine;

public class PlayerControlle : MonoBehaviour
{
    public float fuerzaSalto = 10f;
    private Rigidbody2D rb;
    private bool enSuelo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Salta con Espacio o Flecha Arriba solo si está en el suelo
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            enSuelo = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si toca el suelo, puede volver a saltar
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }

        // Si choca con un obstáculo, Game Over
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            GameManager.instance.GameOver();
        }
    }
}