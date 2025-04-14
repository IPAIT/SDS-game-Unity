using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rb; //RigidBody
    Vector3 _input; // вектор дл€ управлени€
    public float speed; // скорость движени€
    public float speedTurn; // скорость поворота
    public bool matrix = false; // ѕреобразование поворота дл€ изометрии
    Vector3 relative;

    private Animator _anim;




    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        InputGet();
        Look();
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        _anim.SetBool("isWalk", moveInput.magnitude > 0.1f); // вызываем

    }
    private void FixedUpdate()
    {
        if (_input != Vector3.zero)
        {
            Move();
        }
    }
    void InputGet()
    {
        _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // получаем данные с клавиатуры
        if (Input.GetKey(KeyCode.LeftShift)) // ускорение при шифте
        {
            speed = 5f;
        }
        else
        {
            speed = 3f;
        }

    }
    void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * speed * Time.deltaTime); // сообственно само движение
    }
    void Look()
    {
        if (_input != Vector3.zero)
        {
            if (matrix == false) // требуетс€ ли доп поворот
            {
                relative = (transform.position + _input) - transform.position;
            }
            else
            {
                relative = (transform.position + _input.ToIso()) - transform.position;
            }
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, speedTurn * Time.deltaTime);
            GetComponent<PlayerAnimationCon>().Run(speed, true); // включаем анимации 
        }
        else
        {
            GetComponent<PlayerAnimationCon>().Run(speed, false);
        }
    }
}