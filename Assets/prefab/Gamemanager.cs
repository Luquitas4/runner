using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // O using UnityEngine.UI; si usás el texto viejo

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public GameObject panelGameOver;
    public TMP_Text textoScore;
    public TMP_Text textoScoreFinal;

    [HideInInspector] public bool juegoTerminado = false;
    private float score = 0f;

    void Awake()
    {
        if (instance == null) instance = this;
        Time.timeScale = 1f; // Reanuda el tiempo por si se reinicia
    }

    void Update()
    {
        if (!juegoTerminado)
        {
            // Suma puntaje con el paso del tiempo
            score += Time.deltaTime * 10f;
            textoScore.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void GameOver()
    {
        juegoTerminado = true;
        Time.timeScale = 0f; // Congela el juego
        panelGameOver.SetActive(true);
        textoScoreFinal.text = "Puntaje Final: " + Mathf.FloorToInt(score).ToString();
    }

    public void ReiniciarJuego()
    {
        // Recarga la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}