using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState:byte {Stopped,Playing };

    private GameState _state ;
    public GameState gameState
    {
        get { return _state; }
        set 
        {
           _state = value;
            switch (_state)
            {
                case GameState.Stopped:
                    GamePlayOrStop(0);
                    break;
                case GameState.Playing:
                    GamePlayOrStop(1);
                    break;
                default:
                    break;
            }
        }
    }
    private void Start()
    {
        gameState = GameState.Playing;
        mainPlayer = GameObject.FindGameObjectWithTag("PlayerParent");
        mainPlayerMove = mainPlayer.GetComponent<MainPlayerMove>();
        Coin = _coin;
        Health = _health;
        Panels[1].SetActive(false);
        Debug.Log(gameState);
    }
    // GAMEOBJECTS
    private GameObject mainPlayer;
    private MainPlayerMove mainPlayerMove;
    // UI GAMEOBJECTS

    public Text ScoreUI;
    public Text HealthUI;
    public Text CoinUI;
    public Text StatusUI;
    [SerializeField]
    private GameObject[] Panels;
    //GAME VARIABLES
    private float baseSpeed = 100;
    public float Speed
    {
        get { return mainPlayer.GetComponent<MainPlayerMove>().speed; }
        set { if (value<=500) mainPlayerMove.speed = value; }
    }
   
    private float _coin = 0;
    private float Coin
    {
        get { return _coin; }
        set
        {
            _coin = value;
            CoinUI.text = "Coin :" + _coin;
        }
    }
    [Range(0f, 100f)]
    private float _health = 100;
    private float Health { get { return _health; } set { SetHealth(value); } }
    void SetHealth(float health)
    {
        if (health <= 0)
        {
            health = 0;
            gameState= GameState.Stopped;
            StatusUI.text = "YOU ARE DEAD";
        }
        _health = health;

        HealthUI.text = "Health :" + _health;
    }
    private float score;

 

    public void CollectCoin()
    {
        Coin++;
    }
    public void SpeedChange(float speedChange)
    {
        Speed += speedChange;
        StopAllCoroutines();
        StartCoroutine(SpeedAdjusment());
    }
    IEnumerator SpeedAdjusment()
    {

        Debug.Log(Speed);
        yield return new WaitForSeconds(2f);

        Speed = baseSpeed;
        Debug.Log(Speed);
    }
    public void Damage(float damage)
    {
        Health -= damage;
    }
    private void UpdateUI()
    {
        ScoreUI.text = "Score :" + score;
    }   
     public void GamePlayOrStop(float timeScale)
    {
        Time.timeScale = timeScale;
    }
    public void Pause(float gameStateStatus)
    {
        gameState =(GameState)gameStateStatus;
        Panels[0].SetActive(!Panels[0].activeSelf);
        Panels[1].SetActive(!Panels[1].activeSelf);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
