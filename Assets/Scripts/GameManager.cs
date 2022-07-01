using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text ScoreUI;
    public Text HealthUI;
    public Text CoinUI;
    public Text StatusUI;
    private float baseSpeed = 100;
    public float Speed
    {
        get { return mainPlayer.GetComponent<MainPlayerMove>().speed; }
        set { if (value<=500) mainPlayerMove.speed = value; }
    }
    private GameObject mainPlayer;
    private MainPlayerMove mainPlayerMove;
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
            Time.timeScale = 0;
            StatusUI.text = "YOU ARE DEAD";
        }
        _health = health;

        HealthUI.text = "Health :" + _health;
    }
    private float score;

    private void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("PlayerParent");
        mainPlayerMove = mainPlayer.GetComponent<MainPlayerMove>();
        Coin = _coin;
        Health = _health;
    }

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
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
