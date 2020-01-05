using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private BoxCollider2D rightWall;
    private BoxCollider2D leftWall;
    private BoxCollider2D upWall;
    private BoxCollider2D downWall;

    public Transform player1;
    public Transform player2;

    private int score1;
    private int score2;
    public Text Score1;
    public Text Score2;

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    
    void Start()
    {
        ResetWall();
        ResetPlayer();
    }

    // Update is called once per frame
    void Update()
    {      
    }

    void ResetWall()
    {
        rightWall = transform.Find("rightWall").GetComponent<BoxCollider2D>();
        leftWall = transform.Find("leftWall").GetComponent<BoxCollider2D>();
        upWall = transform.Find("upWall").GetComponent<BoxCollider2D>();
        downWall = transform.Find("downWall").GetComponent<BoxCollider2D>();

        float width = Screen.width;
        float height = Screen.height;
        Vector3 upRightPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        upWall.transform.position = new Vector3(0, upRightPosition.y + 0.5f, 0);
        upWall.size = new Vector2(upRightPosition.x*2, 1);

        downWall.transform.position = new Vector3(0, -upRightPosition.y - 0.5f, 0);
        downWall.size = new Vector2(upRightPosition.x * 2, 1);

        rightWall.transform.position = new Vector3(upRightPosition.x + 0.5f, 0, 0);
        rightWall.size = new Vector2(1, upRightPosition.y * 2);

        leftWall.transform.position = new Vector3(-upRightPosition.x - 0.5f, 0, 0);
        leftWall.size = new Vector2(1, upRightPosition.y * 2);
        
    }

    void ResetPlayer()
    {
        Vector3 p1Position = Camera.main.ScreenToWorldPoint(new Vector2(100, Screen.height / 2));
        player1.position = new Vector3(p1Position.x, p1Position.y, 0);
        Vector3 p2Position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width  - 100, Screen.height / 2));
        player2.position = new Vector3(p2Position.x, p2Position.y, 0);
    }

    public void ChangeScore(string wallName)
    {
        if(wallName == "rightWall")
        {
            score1++;
        }
        else if(wallName == "leftWall")
        {
            score2++;
        }
        Score1.text = score1.ToString();
        Score2.text = score2.ToString(); 
    }

    public void Reset()
    {
        score1 = 0;
        score2 = 0;
        Score1.text = score1.ToString();
        Score2.text = score2.ToString();
        ResetPlayer();
        GameObject.Find("newball").SendMessage("Reset");
    }

}
