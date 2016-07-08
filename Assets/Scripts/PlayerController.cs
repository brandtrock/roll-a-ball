using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Allows it to show up in the editor
	public float speed;
    public Text countText;
    public Text winText;

	private Rigidbody rb;
    private int count; // track collectible game objects

	// Runs on the first frame of the game
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
        count = 0;
        SetCountText();
        winText.text = "";
	}

	// Physics Code Goes Here
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

    // SphereCollider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    // Display text for the number of collected items
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }

}