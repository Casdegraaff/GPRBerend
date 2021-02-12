using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public Animator anim;
    public Text textbox;
    public AudioSource oof;
    void Start()
    {
        oof = GetComponent<AudioSource>();
    }

    void takeDamage()
    {
        health -= 10;
        oof.Play();
    }

    void Update()
    {
        textbox.text = "" + health;
        if (health <= 1)
        {
            Destroy(gameObject);
            anim.SetBool("isDead", true);
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                if (hit.collider)
                {
                    if (hit.collider.tag == "Player")
                    {
                        if (health <= 1)
                        {
                            anim.SetBool("isDead", true);
                        }
                        else
                        {
                            takeDamage();
                        }
                    }
                }
            }
        }
    } 
}
