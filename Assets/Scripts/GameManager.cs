using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameState currentState;

    public GameObject gameOverUI;
    public GameObject victoryUI;
    public GameObject startUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeState(new StartState(this));
    }

    private void Update()
    {
        if (currentState != null)
            currentState.UpdateState();
    }

    public void ChangeState(GameState newState)
    {
        if (currentState != null)
            currentState.ExitState();

        currentState = newState;
        currentState.EnterState();
    }

    public void StartGame()
    {
        ChangeState(new PlayingState(this));
    }

    public void GameOver()
    {
        ChangeState(new GameOverState(this));
    }

    public void Victory()
    {
        ChangeState(new VictoryState(this));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ChangeState(new PlayingState(this));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
