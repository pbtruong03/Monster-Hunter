using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public string tagTarget = "PlayerBody";
    public List<Collider2D> detectedObjs = new List<Collider2D>();
    public Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col.GetComponent<Collider2D>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagTarget)
        {
            detectedObjs.Add(collision);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == tagTarget)
        {
            detectedObjs.Remove(collision);
        }
    }

}
