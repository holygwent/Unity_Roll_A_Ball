using UnityEngine;


using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

	
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

	private float movementX;
	private float movementY;

	private Rigidbody rb;
	private int count;
	private float jump = 0.0f;

	
	void Start()
	{
		
		rb = GetComponent<Rigidbody>();

		
		count = 0;

		SetCountText();


		winTextObject.SetActive(false);
	}
	void OnFire()
    {
		jump = 27;
		Debug.Log("jump");
    }

	void FixedUpdate()
	{
	
		Vector3 movement = new Vector3(movementX, jump, movementY);

		rb.AddForce(movement * speed);
		jump = 0.0f;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);

			count = count + 1;

			SetCountText();
		}
	}

	void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 7)
		{
			winTextObject.SetActive(true);
		}
	}
}
