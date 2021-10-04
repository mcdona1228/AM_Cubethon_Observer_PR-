using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public delegate void HitObstacle(Collision collisionInfo);
    public static event HitObstacle OnHitObstacle;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            if (OnHitObstacle != null)
            {
                collisionInfo.collider.GetComponent<MeshRenderer>().material.color = Color.cyan;
                OnHitObstacle(collisionInfo);
                gameObject.SetActive(false);
            }
        }
        
    }
    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.tag == "Trigger")
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            Debug.Log("Hit Trigger");
        }
    }
}
