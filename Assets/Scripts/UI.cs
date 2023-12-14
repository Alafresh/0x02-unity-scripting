using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text coins;
    public Text health;
    private void Awake()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController1 coin = player.GetComponent<PlayerController1>();
        coins.text = "Coins: " + coin.score.ToString();
        health.text = "Health: " + coin.health.ToString();
    }
    private void Update()
    {
        GameObject players = GameObject.Find("Player");
        PlayerController1 coin = players.GetComponent<PlayerController1>();
        coins.text = "Coins: " + coin.score.ToString();
        health.text = "Health: " + coin.health.ToString();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Laberinto");
    }
}
