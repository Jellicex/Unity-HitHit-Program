using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartBall();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
        {
            Vector2 velocity = rigidbody2D.velocity;
            velocity.y = velocity.y / 2f + col.rigidbody.velocity.y/2;
            
            if(velocity.x < 7 && velocity.x >-7)
            {
                velocity.x = velocity.x > 0 ? 10 : -10; 
            }
            rigidbody2D.velocity = velocity;
        }

        if(col.gameObject.name == "rightWall" || col.gameObject.name == "leftWall")
        {
            GameManager.Instance.ChangeScore(col.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        StartBall();
    }

    void StartBall()
    {
        int num = Random.Range(0, 2);
        if (num == 1)
        {
            rigidbody2D.AddForce(new Vector2(100, 0));
        }
        else
        {
            rigidbody2D.AddForce(new Vector2(100, 0));
        }

    }

}
