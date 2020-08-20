using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    private int score = 0;

    public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hori_movement = Input.GetAxis("Horizontal");
        float verti_movement = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(hori_movement, 0.0f, verti_movement);

        rb.AddForce(force * speed);

    }

    void FixedUpdate()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("maze");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            ++score;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap"))
        {
            --health;
            Debug.Log($"Health: {health}");


        }
        else if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
}
