using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    private bool isGrounded;

    void Update()
    {
        // ��������M������J
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �p�Ⲿ�ʦV�q
        Vector3 horizontalMovement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        Vector3 verticalMovement = new Vector3(0f, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // �`�����ʦV�q
        Vector3 movement = horizontalMovement + verticalMovement;

        // �N���ʦV�q���Ψ쪫�骺��m
        transform.Translate(movement);

        // �˴��O�_�b�a���W
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // �B�z���D
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}






