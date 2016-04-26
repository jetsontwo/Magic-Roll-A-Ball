using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private ParticleSystem ps;
    public Text countText;
    public Text winText;
    public float speed;
    private int count;
    private float y_level, distToGround;
    private bool isGrounded;
    private float angle;
    public Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ps = (GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>());
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        angle = Vector2.Angle(new Vector2(transform.position.x, transform.position.z), new Vector2(cam.transform.position.x, cam.transform.position.z));
        float moveHorizontal = 0;
        float moveVertical = 0;
        if (Input.GetKey("d"))
        {
            moveHorizontal += 1;
        }
        if (Input.GetKey("a"))
        {
            moveHorizontal -= 1;
        }
        if (Input.GetKey("w"))
        {
            moveVertical += 1;
        }
        if (Input.GetKey("s"))
        {
            moveVertical -= 1;
        }


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.drag = .01f;
        if(moveVertical == 0 && moveHorizontal == 0)
        {
            rb.drag = 1.4f;
        }

        if(rb.velocity.magnitude < 15)
        {
            rb.AddForce(movement * speed);
        }


        if (Input.GetKey("f"))
        {

            rb.useGravity = false;
            ps.enableEmission = true;
            if(transform.position.y < y_level)
            {
                Vector3 reset = new Vector3(0, 0, 0);
                if(rb.velocity.y < 0)
                {
                    reset = new Vector3(0, 5f, 0);
                }
                else if (rb.velocity.y < 3)
                {
                    reset = new Vector3(0, 2f, 0);
                }
                rb.AddForce(reset);
            }
            else
            {
                rb.MovePosition(new Vector3(transform.position.x, y_level, transform.position.z));
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }

        }
        else
        {
            rb.useGravity = true;
            ps.enableEmission = false;

        }

        if (rb.position.y < -100)
        {
            respawn();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            y_level = transform.position.y + 1;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 2)
        {
            winText.text = "You Win!";
        }


    }

    void respawn()
    {
        rb.MovePosition(new Vector3(0, 0.5f, 0));
        rb.velocity = new Vector3(0, 0, 0);
        rb.rotation = Quaternion.identity;
    }
}
