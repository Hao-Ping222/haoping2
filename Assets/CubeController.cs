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
        // 獲取水平和垂直輸入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 計算移動向量
        Vector3 horizontalMovement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        Vector3 verticalMovement = new Vector3(0f, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // 總的移動向量
        Vector3 movement = horizontalMovement + verticalMovement;

        // 將移動向量應用到物體的位置
        transform.Translate(movement);

        // 檢測是否在地面上
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // 處理跳躍
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}






