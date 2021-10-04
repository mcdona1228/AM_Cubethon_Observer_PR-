using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public string display;
    public TextMeshProUGUI text;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    void FixedUpdate()
    {
        rb.AddForce(0, 0, 2000 * Time.deltaTime);    
        if (Input.GetKey("d"))
        {
            //rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            Command moveRight = new MoveRight(rb, sidewaysForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveRight);
            invoker.ExecuteCommand();
            Display(moveRight.ToString());

        }
        if (Input.GetKey("a"))
        {
            //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            Command moveLeft = new MoveLeft(rb, sidewaysForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveLeft);
            invoker.ExecuteCommand();
            Display(moveLeft.ToString());
        }
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame(null);
        }
    }
    void Display(string show)
    {
        display = show;
        text.text = display;

    }
}
