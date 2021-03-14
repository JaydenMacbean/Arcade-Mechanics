using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    protected Rigidbody2D _rb2D;
    public float JumpForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I) && Mathf.Abs(_rb2D.velocity.y) < 0.001f)
        {
            _rb2D.velocity = new Vector2(0, JumpForce);

        }

    }
}
