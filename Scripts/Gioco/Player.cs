using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Projectile laserPrefabs;
    public float speed = 10.0f;
    private bool _laserActive;
    public GameObject gameover;
    public GameObject restart;
    public GameObject quit;
    public GameObject menu;
    public GameObject menu_sopra;
    public static bool isfinish;
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 position = this.transform.position;
        if (!isfinish) //è necessario controllare che la partita non sia finita
        {
            //spostare il player a destra o a sinistra
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                position.x -= this.speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                position.x += this.speed * Time.deltaTime;
            }

            // Blocca la posizione del player in modo che non esca dai bordi
            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
            position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

            // Imposta la posizione aggiornata del player
            this.transform.position = position;

            //richiama la funzione shoot quando viene premuto lo spazio e il tasto sinistro del mouse
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }  
    }

    private void Shoot()
    {
        // Solo un laser può essere attivo in un dato momento, quindi prima controlla che
        // non c'è già un laser attivo 

        if (!_laserActive)
        {   
            audioSource.PlayOneShot(audioClips[0]);

            // Crea un nuovo laser
            Projectile projectile = Instantiate(this.laserPrefabs, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        }
    }

    private void LaserDestroyed()
    {
        // Disattiva il laser così si può sparare di nuovo 
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!isfinish)//è necessario controllare che la partita non sia finita
        {
            //il player viene ucciso quando viene colpito da un missile degli inasori
            if (other.gameObject.layer == LayerMask.NameToLayer("Invader") || other.gameObject.layer == LayerMask.NameToLayer("Missile"))
            {
                audioSource.PlayOneShot(audioClips[1]);
                isfinish = true;
                gameover.SetActive(true);
                restart.SetActive(true);
                quit.SetActive(true);
                menu.SetActive(true);
                menu_sopra.SetActive(false);
            }
        } 
    }
}