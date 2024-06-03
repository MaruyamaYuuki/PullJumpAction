using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody>();     //gameObject�͏ȗ��\

    }

    private Vector3 clickPositon;
    [SerializeField]
    private float jumpPower = 10;
    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        if (Input.GetMouseButtonDown(0))
        {
            clickPositon = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            // �N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clickPositon - Input.mousePosition;
            // �N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
            if (dist.sqrMagnitude == 0) { return; }
            // ������W�������AjumpPower���������킹���l���ړ��ʂƂ���
            rb.velocity = dist.normalized * jumpPower;
        }
    }
}
