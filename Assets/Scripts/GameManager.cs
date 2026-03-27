using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController PlayerController;

    public GameObject GameOverText;
    public TextMeshProUGUI EnergyText;
    public TextMeshProUGUI ScoreText;

    [HideInInspector]
    public int currentScore = 0;

    public float Energy;
    [HideInInspector]
    public float Score;

    [HideInInspector]
    public bool isGameOver;
    public float scrollSpeed;


    void Awake()
    {
        if (Instance == null)
        {
            isGameOver = false;
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        if (isGameOver)
        {
            GameOverText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            return;
        }
        
        Energy -= Time.deltaTime;
        EnergyText.text = $"Energy : {new string('I', Mathf.Max(((int)Energy), 0))}";
        ScoreText.text = $"Score : {Score}";
        
        if (Energy <= 0)
        {
            PlayerController.animator.SetTrigger("Dead");
            isGameOver = true;
        }
    }
}
