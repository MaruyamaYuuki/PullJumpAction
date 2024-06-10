using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PullingJump : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("衝突した");
    }

    private void OnCollisionStay(Collision collision)
    {
        // 衝突している点の情報が複数格納されている
        ContactPoint[] contacts = collision.contacts;
        // 0番目の衝突情報から、衝突している点の法線を取得
        Vector3 otherNormal = contacts[0].normal;
        // 上方向を示すベクトル。長さは1。
        Vector3 upVector = new Vector3(0, 1, 0);
        // 上方向と法線の内積
        float dotUN = Vector3.Dot(upVector, otherNormal);
        // 内積値ぶ逆三角形arccosを掛けて角度を算出
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        // 二つのベクトルがなす角度が45度より小さければ再びジャンプ可能にする
        if (dotDeg <= 45)
        {
            isCanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("離脱した");
        isCanJump = false;
    }
    private Rigidbody rb;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody>();     //gameObjectは省略可能
        audioSource = GetComponent<AudioSource>();

    }

    private Vector3 clickPositon;
    [SerializeField]
    private float jumpPower = 10;
    private bool isCanJump;

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        if (Input.GetMouseButtonDown(0))
        {
            clickPositon = Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            // クリックした座標と離した座標の差分を取得
            Vector3 dist = clickPositon - Input.mousePosition;
            // クリックとリリースが同じ座標ならば無視
            if (dist.sqrMagnitude == 0) { return; }
            // 差分を標準化し、jumpPowerをかけ合わせた値を移動量とする
            rb.velocity = dist.normalized * jumpPower;

            audioSource.Play();
        }
    }
}
