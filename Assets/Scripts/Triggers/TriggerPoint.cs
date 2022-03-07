using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    [Header("Player point Checker")]
    public Player player;

    [Header("Ball Tag Checker")]
    public string tagToCheck = "Ball";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == tagToCheck)
        {
            Debug.Log("Hit the Ball");
            CountPoint();
        }
    }

    private void CountPoint()
    {
        StateMachine.Instance.ResetPosition();
        player.AddPoint();
    }
}
