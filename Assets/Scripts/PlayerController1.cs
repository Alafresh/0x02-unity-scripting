using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController1 : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameOver;
    public int health = 5;
    public int score = 0;
    [SerializeField]
    public float speed;
    public Rigidbody rb;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (health == 0)
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
            Debug.Log("Game Over!");
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
            rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("s"))
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        if (Input.GetKey("a"))
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("d"))
            rb.AddForce(speed * Time.deltaTime, 0, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            Destroy(other.gameObject);
            score += 1;
            Debug.Log("Score: " + score);
        }
        if (other.tag == "Trap")
        {
            health -= 1;
            Debug.Log("Health: " + health);
        }
        if (other.tag == "Goal" && score >= 20)
        {
            StartCoroutine(Win());
        }
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
        panel.SetActive(true);
        Debug.Log("You win!");
    }
}
