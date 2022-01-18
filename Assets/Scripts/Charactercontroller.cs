using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class Charactercontroller : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 60f;
    public AudioSource pasos;
    public AudioSource segundosPasos;

    InputController inputController = null;
    private void Start()
    {
        inputController = GetComponent<InputController>();
    }

    void Update()
    {
        Move();
        StepsSounds();
    }

    void Move()
    {
        Vector2 input = inputController.MoveInput();
        transform.position += transform.forward * input.y * speed * Time.deltaTime;
        transform.Rotate(Vector3.up * input.x * rotationSpeed * Time.deltaTime);
    }

    void StepsSounds()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            pasos.Play();
        }
        if (Input.GetButtonDown("Vertical"))
        {
            segundosPasos.Play();
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            pasos.Pause();
        }
        if (Input.GetButtonUp("Vertical"))
        {
            segundosPasos.Pause();
        }
    }

}
