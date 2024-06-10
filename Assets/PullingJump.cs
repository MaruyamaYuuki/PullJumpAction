using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PullingJump : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�Փ˂���");
    }

    private void OnCollisionStay(Collision collision)
    {
        // �Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;
        // 0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾
        Vector3 otherNormal = contacts[0].normal;
        // ������������x�N�g���B������1�B
        Vector3 upVector = new Vector3(0, 1, 0);
        // ������Ɩ@���̓���
        float dotUN = Vector3.Dot(upVector, otherNormal);
        // ���ϒl�ԋt�O�p�`arccos���|���Ċp�x���Z�o
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        // ��̃x�N�g�����Ȃ��p�x��45�x��菬������΍ĂуW�����v�\�ɂ���
        if (dotDeg <= 45)
        {
            isCanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("���E����");
        isCanJump = false;
    }
    private Rigidbody rb;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody>();     //gameObject�͏ȗ��\
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
            // �N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clickPositon - Input.mousePosition;
            // �N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
            if (dist.sqrMagnitude == 0) { return; }
            // ������W�������AjumpPower���������킹���l���ړ��ʂƂ���
            rb.velocity = dist.normalized * jumpPower;

            audioSource.Play();
        }
    }
}
