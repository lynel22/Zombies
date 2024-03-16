using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    Animation animation;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            animation.wrapMode = WrapMode.Once;
            animation.Play();
        }
    }
}
