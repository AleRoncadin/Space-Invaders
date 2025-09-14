using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MysteryShip : MonoBehaviour
{
    public Projectile razzoPrefabs;
    public int shipColpita = 0;
    private float speed = 7.0f;

    private Vector3 direction = Vector2.right;

    AudioSource audioNave;

    private void Start()
    {
        audioNave = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(!Player.isfinish)
        {
            this.transform.position += direction * this.speed * Time.deltaTime;
            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

            if (this.direction == Vector3.right && this.transform.position.x >= (rightEdge.x - 1.0f))
                this.direction = new Vector3(-this.direction.x, 0.0f, 0.0f);

            else if (this.direction == Vector3.left && this.transform.position.x <= (leftEdge.x + 1.0f))
                this.direction = new Vector3(-this.direction.x, 0.0f, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Player.isfinish)
        {
            // The ship dies when hit by the laser
            if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
            {
                audioNave.Play();
                this.shipColpita++;
                Punti_Navi.puntiNavi = shipColpita;
                Punti_Nemici.valorePunti += 100; //colpire la nave vale ben 100 punti
            }
        }  
    }
}