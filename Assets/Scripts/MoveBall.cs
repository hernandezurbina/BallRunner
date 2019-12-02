using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveBall : MonoBehaviour
{
    Rigidbody rb;
    public int ballSpeed;
    public int jumpSpeed;
    private bool isTouchingGround = true;
    private int counter;
    public Text coinText;
    private readonly int numCoins = 13;
    public AudioSource aSource;
    public AudioClip aClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        counter = numCoins;
        coinText.text = "COINS: " + counter; 
    }

    // Update is called once per frame
    void Update()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        Vector3 ballMove = new Vector3(hMove, 0.0f, vMove);

        rb.AddForce(ballMove * ballSpeed);

        if((Input.GetKey(KeyCode.Space)) && isTouchingGround == true) {
            Vector3 ballJump = new Vector3(0.0f, 6.0f, 0.0f);
            rb.AddForce(ballJump * jumpSpeed);
        }

        isTouchingGround = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        isTouchingGround = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CoinsTag")) {
            other.gameObject.SetActive(false);
            counter -= 1;
            coinText.text = "COINS: " + counter;
            aSource.PlayOneShot(aClip);

            if (counter == 0) {
                SceneManager.LoadScene("EndScene");
            }
        }
    }

}
