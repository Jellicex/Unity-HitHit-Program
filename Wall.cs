using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D()
    {
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
