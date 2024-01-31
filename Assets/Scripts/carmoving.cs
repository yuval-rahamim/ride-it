using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carmoving : MonoBehaviour
{
	public gameover gameover;

	bool move = false;
	bool isGrounded = false;

	private float upsideDown = 0f;

	public static int point;
	public int inarow = 0;
    float rotationCount = 0;
    float totalAngularDisplacement = 0;
    public Rigidbody2D rb;

	public float speed = 20f;
	public float rotationSpeed = 2f;

	public void Start()
	{
		point = 0;
	}
        private void Update()
	{
		
		if (Input.GetButtonDown("Fire1"))
		{
			move = true;
		}
		if (Input.GetButtonUp("Fire1"))
		{
			move = false;
		}
		
        
	}

	private void FixedUpdate()
	{
		upsideDown = Vector2.Dot(transform.up, Vector2.down);
		if (isGrounded && upsideDown > 0)
		{
			gameover.Setup(point);
		}
		if (move == true)
		{
			if (isGrounded)
			{
                if (totalAngularDisplacement > 360)
                {
                    point += 4 * inarow;
                }
				inarow = 0;
                totalAngularDisplacement = 0;
                rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
			}
			else
			{
                rotationCount = rotationSpeed * Time.fixedDeltaTime * 100f;
                rb.AddTorque(rotationCount, ForceMode2D.Force);
                totalAngularDisplacement += Mathf.Abs(rotationCount);
                if (totalAngularDisplacement > 360)
				{
					point += 2 * inarow;
                    totalAngularDisplacement = 0;
					inarow++;
                }
			}
		}
		
		
	}

	private void OnCollisionEnter2D(Collision2D collisioni)
	{
		isGrounded = true;
		
		if (collisioni.collider.tag == "ob")
		{
			gameover.Setup(point);
		}
	}

	private void OnCollisionExit2D()
	{
		isGrounded = false;
		
	}


}
