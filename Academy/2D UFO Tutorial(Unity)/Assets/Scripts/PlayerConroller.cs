using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConroller : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text WinText;

    private Rigidbody2D rb2d;
    private int count;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        WinText.text = "";
        SetCountText();
    }

  void FixedUpdate() {
        //모르는 부분 드래그하고 ctrl+' key 설명 나옴.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement*speed);
   }
   
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUP"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    } 

    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= 5)
        {
            WinText.text = "You Win";
        }
    }

}
