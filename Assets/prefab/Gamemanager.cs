using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

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
        Time.timeScale = 1f; 
    }

    void Update()
    {
        if (!juegoTerminado)
        {
            
            score += Time.deltaTime * 10f;
            textoScore.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void GameOver()
    {
        juegoTerminado = true;
        Time.timeScale = 0f; 
        panelGameOver.SetActive(true);
        textoScoreFinal.text = "Puntaje Final: " + Mathf.FloorToInt(score).ToString();
    }

    public void ReiniciarJuego()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}