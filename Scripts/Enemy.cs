using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    private float sizeIncrease = 0.5f;

    private Renderer rendererPlayer;
    public Texture2D texPlayerNew;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        rendererPlayer = player.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            player.transform.localScale = transform.localScale + new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);
            rendererPlayer.material.SetTexture("_MainTex", texPlayerNew);
        }
    }
}
