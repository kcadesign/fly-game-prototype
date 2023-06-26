using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChangeTrigger : MonoBehaviour
{
    private Renderer _renderer;
    private Color _originalColour;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _originalColour = _renderer.material.GetColor("_BaseColor");
    }


    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Human")
        {
            _renderer.material.SetColor("_BaseColor", Color.green);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _renderer.material.SetColor("_BaseColor", Color.yellow);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _renderer.material.SetColor("_BaseColor", _originalColour);
            //StartCoroutine(ButtonPrimedTimer());
        }
    }
    
}
