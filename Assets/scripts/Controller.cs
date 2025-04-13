using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private Rigidbody _rb;
    private Vector3 inputin;
    [SerializeField] public float speed;

    void Start()
    {
        _anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        GatherInput();
        Look();
        Animate(); 
    }

    void FixedUpdate()
    {
        Move();
    }

    void Look()
    {
        if (inputin != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
            var inputinputin = matrix.MultiplyPoint3x4(inputin);

            var relative = (transform.position + inputinputin) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = rot;
        }
    }

    void GatherInput()
    {
        inputin = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * inputin.magnitude) * speed * Time.deltaTime);
    }

    void Animate()
    {
        bool isMoving = inputin.magnitude > 0;

        _anim.SetBool("isWalk", isMoving);
    }
}
