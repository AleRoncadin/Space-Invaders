using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs; //Il prefab che viene clonato per ogni fila di invasori
    public int rows = 4; //il numero di righe di invasori
    public int columns = 15; //il numero di colonne di invasori
    public AnimationCurve speed;
    /*La velocità con cui si muovono gli invasori (asse y) rispetto
    alla percentuale di invasori uccisi (asse x). In genere gli invasori
    si muovono più velocemente meno ci sono vivi.*/

    public Projectile missilePrefab;//Il prefab che viene clonato per ogni missile sparato dall'invasore
    public float missileAttackRate = 2.0f; //il tempo tra gli attacchi dei missili 
    public int amountkilled { get; private set; } //quanti invasori sono stati uccisi
    public int amounAlive => this.totalInvaders - this.amountkilled; //quanti invasori sono ancora vivi
    public int totalInvaders => rows * columns; //il numero totale di invasori
    public float percentKilled => (float)this.amountkilled / (float)this.totalInvaders;
    //percentuale di invasori uccisi

    private Vector3 _direction = Vector2.right;

    public GameObject gamewin;
    public GameObject restart;
    public GameObject quit;
    public GameObject menu;
    public GameObject menu_sopra;

    public AudioClip[] audioClips;
    public AudioSource audioSource;

    private void Awake()
    {
        if(!Player.isfinish) //controlla che la partita non sia finita
        {
            Vector3 rowPosition;
            //forma tutta la griglia degli invasori
            for (int row = 0; row < rows; row++)
            {
                //calcola la posizione della riga
                float width = 2.0f * (columns - 1);
                float height = 2.0f * (rows - 1);
                Vector3 centering = new Vector2(-width / 2, -height / 2);
                rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);
                for (int col = 0; col < columns; col++)
                {
                    // Crea un invasore e lo abbina a quella transform 
                    Invader invader = Instantiate(this.prefabs[row], this.transform);
                    invader.killed += InvaderKilled;

                    // Calcola e imposta la posizione dell'invasore nella riga 
                    Vector3 position = rowPosition;
                    position.x += col * 2.0f;
                    invader.transform.localPosition = position;
                }
            }
        } 
    }

    public void Start()
    {
        // Richiama il missile dopo un certo numero di secondi 
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);
    }

    private void Update()
    {
        if(!Player.isfinish) //controlla che la partita non sia finita
        {
            // Sposta tutti gli invasori nella direzione attuale 
            this.transform.position += _direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;

            //necessari per non fare andare gli invasori oltre il bordo dello schermo
            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

            // Gli invasori avanzeranno alla riga successiva dopo aver raggiunto il bordo di
            // lo schermo 
            foreach (Transform invader in this.transform)
            {
                // Salta tutti gli invasori che sono stati uccisi 
                if (!invader.gameObject.activeInHierarchy)
                    continue;

                // Controlla il bordo sinistro o il bordo destro in base alla direzione corrente 
                if (this._direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
                {
                    AdvanceRow();
                    break;
                }
                else if (this._direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
                {
                    AdvanceRow();
                    break;
                }
            }
        }  
    }

    private void AdvanceRow()
    {
        if (!Player.isfinish) //controlla che la partita non sia finita
        {
            // Inverte la direzione in cui si stanno muovendo gli invasori 
            this._direction = new Vector3(-this._direction.x, 0.0f, 0.0f);

            // Sposta l'intera griglia di invasori in basso di una riga 
            Vector3 position = this.transform.position;
            position.y -= 1.0f;
            this.transform.position = position;
        }
        
    }

    private void MissileAttack()
    {
        if(!Player.isfinish) //controlla che la partita non sia finita
        {
            foreach (Transform invader in this.transform)
            {
                // Tutti gli invasori che vengono uccisi non possono sparare missili 
                if (!invader.gameObject.activeInHierarchy)
                    continue;

                // Possibilità casuale di generare un missile in base al numero di invasori
                // vivi (più invasori sono vivi, minore è la possibilità)
                if (Random.value < (1.0f / (float)this.amounAlive))
                {
                    audioSource.PlayOneShot(audioClips[1]);
                    Instantiate(this.missilePrefab, invader.position, Quaternion.identity);
                    break;
                }

            }
        }
       
    }

    private void InvaderKilled()
    {
        if (!Player.isfinish) //controlla che la partita non sia finita
        {
            audioSource.PlayOneShot(audioClips[0]);
            this.amountkilled++; //aumenta il numero di invasori uccisi
            Punti_Nemici.valorePunti += 10; //aumenta i punti

            if (this.amountkilled >= this.totalInvaders) //se tutti vengono uccisi
            {
                //la partita finisce
                audioSource.PlayOneShot(audioClips[2]);
                Player.isfinish = true;
                gamewin.SetActive(true);
                restart.SetActive(true);
                quit.SetActive(true);
                menu.SetActive(true);
                menu_sopra.SetActive(false);
            }
        }    
    }
}