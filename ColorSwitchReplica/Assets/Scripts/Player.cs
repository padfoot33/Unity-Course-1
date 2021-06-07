using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce;

    public Color cyan;
    public Color yellow;
    public Color megenta;
    public Color red;

    private void Start()
    {
        SetRandomColor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene(0);
        }
        if (collision.CompareTag("ColorChanger"))
        {
            Destroy(collision.gameObject);
            SetRandomColor();
        }
        else if (!collision.CompareTag(tag))
        {
            SceneManager.LoadScene(0);
            Debug.Log("Game Over");
        }

    }
    private void SetRandomColor()
    {
        int randomeNumber = Random.Range(0, 4);

        switch (randomeNumber)
        {
            case 0:
                GetComponent<SpriteRenderer>().color = cyan;
                tag = "Cyan";
                break;
            case 1:
                GetComponent<SpriteRenderer>().color = yellow;
                tag = "Yellow";
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = megenta;
                tag = "Megenta";
                break;
            case 3:
                GetComponent<SpriteRenderer>().color = red;
                tag = "Red";
                break;
        }
    }
}