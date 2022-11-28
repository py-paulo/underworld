using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int Score;

    void Start()
    {
        this.sr = GetComponent<SpriteRenderer>();
        this.circle = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player")
        {
            return;
        }

        this.sr.enabled = false;
        this.circle.enabled = false;
        this.collected.SetActive(true);

        GameController.instance.Score += this.Score;
        GameController.instance.UpdateScoreText();

        Destroy(this.gameObject, 1f);
    }
}
