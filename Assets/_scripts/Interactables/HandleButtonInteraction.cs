using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleButtonInteraction : MonoBehaviour
{
    private Renderer _buttonRenderer;
    private Color _originalColour;

    private void Awake()
    {
        _buttonRenderer = GetComponent<Renderer>();
        _originalColour = _buttonRenderer.material.GetColor("_BaseColor");
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        print($"{collider.gameObject.tag} entered trigger");

        if (collider.gameObject.tag == "Human")
        {
            _buttonRenderer.material.SetColor("_BaseColor", Color.green);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _buttonRenderer.material.SetColor("_BaseColor", Color.yellow);
        }
    }

    /*
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _buttonRenderer.material.SetColor("_BaseColor", Color.yellow);
        }
    }
    */

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _buttonRenderer.material.SetColor("_BaseColor", _originalColour);
            //StartCoroutine(ButtonPrimedTimer());
        }
    }
    
    /*
    private IEnumerator ButtonPrimedTimer()
    {
        yield return new WaitForSeconds(2f);
        _buttonRenderer.material.SetColor("_BaseColor", _originalColour);

    }
    */
}
