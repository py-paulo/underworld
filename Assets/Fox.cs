using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool directRight = true;
    private float timer = 0f;

    void Update()
    {
        if (directRight)
        {
            transform.Translate(Vector2.right * this.speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        } else
        {
            transform.Translate(Vector2.left * this.speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        this.timer += Time.deltaTime;
        if (this.timer >= this.moveTime)
        {
            this.directRight = !this.directRight;
            this.timer = 0f;
        }
    }
}
