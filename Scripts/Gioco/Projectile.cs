using UnityEngine;
public class Projectile : MonoBehaviour
{
    public Vector3 direction; //direzione del proiettile
    public float speed = 20.0f; //velocita
    public System.Action destroyed;

    private void Update()
    {
        // Sposta il proiettile
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.destroyed != null)
            this.destroyed.Invoke();
        Destroy(this.gameObject);
    }
}