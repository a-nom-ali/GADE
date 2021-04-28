using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            Right();
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            Left();
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            Forward();
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            Backward();
        }
    }

    private void Backward()
    {
        _rigidbody.AddForce(Vector3.back);
    }

    private void Forward()
    {
        _rigidbody.AddForce(Vector3.forward);
    }

    private void Left()
    {
        _rigidbody.AddForce(Vector3.left);
    }

    private void Right()
    {
        _rigidbody.AddForce(Vector3.right);
    }
}
