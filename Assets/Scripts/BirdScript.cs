using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour {

    public float jumpForce = 200f;
    private Rigidbody2D rb;
    public Text scoreText;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        //scoreText = GetComponent<Text>();
    }
	
	void Update () {
        if (GameController.instance.gameOver == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);
            }
            Debug.Log("Sus puntos son: " + GameController.instance.score.ToString());
            scoreText.text = "SCORE: " + GameController.instance.score.ToString();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.instance.score++;
        if (collision.gameObject.tag == "coin")
        {
            Debug.Log("Monedita :)");
            GameController.instance.score += 2;
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameController.instance.gameOver = true;
    }
}
