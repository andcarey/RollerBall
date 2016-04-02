using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Rigidbody rigidBody;
    public Text countText;
    public Text winText;

    private int count;
    private float moveX = 0;
    private float moveZ = 0;
    private float moveY = 0;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        count = 0;
        SetCounter();
        winText.text = "";
    }

    void FixedUpdate()
    {

        if (SystemInfo.supportsAccelerometer)
        {
            moveX = Input.acceleration.x;
            moveY = Input.acceleration.y;
            moveZ = Input.acceleration.z;

        }
        else
        {
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");
        }

        Vector3 movement = new Vector3(moveX, 0, moveY);
        rigidBody.AddForce(movement * speed);
        SetCounter();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            //SetCounter();
        }
    }

    void SetCounter()
    {
        countText.text = "Count: " + count.ToString() + " ( " + moveX.ToString("F2") + ", " + moveY.ToString("F2") + ", " + moveZ.ToString("F2") + " )";
        if (count >= 12)
        {
            winText.text = "You Win!!";
        }
    }

}
