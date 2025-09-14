using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Invader : MonoBehaviour
{
    
    private SpriteRenderer _spriteRenderer;
    public Sprite[] animationSprites; //Gli sprite che si animano sull'invasore 
    public float animationTime; //il tempo in secondi per cambiare la sprite per fare l'animazione
    public System.Action killed;
    
    private int _animationFrame;

    private void Awake()
    {
        // Ottiene un riferimento allo sprite render in modo tale da animare lo sprite 
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = this.animationSprites[0];
    }

    private void Start()
    {
        // Avvia il ciclo di animazione per cambiare le sprite
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite()
    {
        //passa al frame successivo
        _animationFrame++;

        // Torna all'inizio se il frame supera la lunghezza
        if (_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }

        // Imposta lo sprite in base al frame di animazione corrente 
        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // L'invasore muore quando viene colpito dal laser 
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
