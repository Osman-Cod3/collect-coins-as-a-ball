using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;

    private float xInput;
    private float yInput;

    private int score = 0;
    public int winScore;

    public GameObject winText;
    int countdown;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // fell off the map, restart the game
        if(transform.position.y < -5f)
        {
            restartGame();
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * speed, 0, yInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // collision with coins
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            score++;

            if (score >= winScore)
            {
                // gamewin
                WinGame();
            }
        }
    }

    private void WinGame() 
    {
        winText.SetActive(true);


        Invoke("restartGame", 5f);
    }

    // for restarting the game
    private void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
