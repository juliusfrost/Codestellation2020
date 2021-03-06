﻿using UnityEngine;

public class StompableEnemy : MonoBehaviour
{
    // if the velocity of the player is greater than this amount, then we say the player stomped on the enemy 
    [SerializeField] private float stompThreshold;
    private GameObject _player;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter(Collision other)
    {
        foreach (var contactPoint in other.contacts)
        {
            // continue only if otherCollider is from the player
            if (contactPoint.otherCollider.gameObject.layer != 8) continue;
            if (contactPoint.otherCollider.GetComponent<Rigidbody>().velocity.y < -stompThreshold)
            {
                Destroy(gameObject);
            }
            else
            {
                _player.GetComponent<Controls>().Death();
            }
        }
    }
}