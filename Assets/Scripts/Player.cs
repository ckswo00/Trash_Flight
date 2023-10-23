using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject Weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInerval = 0.05f;
    private float lastShotTime = 0f;


    // Update is called once per frame
    void Update()
    {
        // 키보드 방식 1
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // 키보드 방식 2
        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // if(Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.position -= moveTo;
        // }
        // else if(Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.position += moveTo;
        // }

        // 마우스 포인터 방식
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.45f, 2.45f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);
        
        Shoot();
    }

    void Shoot()
    {
        if (Time.time - lastShotTime > shootInerval){
            Instantiate(Weapon, shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }
}
