using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{

    public float speed;
    Rigidbody rb;

    float xInput;
    float yInput;

    int score = 0;
    public int winScore;

    public GameObject winText;

    private void Update()
    {
        if(transform.position.y < -5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * speed, 0, yInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            score++;

            if (score >= winScore)
            {
                // gamewin
                winText.SetActive(true);
            }
        }
    }
}
