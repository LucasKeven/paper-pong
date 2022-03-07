using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Points")]
    public int maxPoints = 2;

    public float speed = 15f;
    public Image uiPlayer;
    public string playerName;

    [Header("Key Setup")]
    public KeyCode KeyCodeMoveUp;
    public KeyCode KeyCodeMoveDown;

    public Rigidbody2D myRigidbody2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    private void Awake()
    {
        ResetPlayer();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCodeMoveUp))
            myRigidbody2D.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.up * speed);
        //transform.Translate(transform.up * speed);
        else if (Input.GetKey(KeyCodeMoveDown))
            myRigidbody2D.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.up * - speed);
        //transform.Translate(transform.up * speed * -1);
    }
    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
        Debug.Log(gameObject.name + " scored " + currentPoints + " points ");
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if(currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighscoreManager.Instance.SavePlayerWin(this);
        }
    }

    
}