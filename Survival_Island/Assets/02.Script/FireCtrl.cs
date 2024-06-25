using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    [Header("���۳�Ʈ��")]
    //�Ѿ˿�����Ʈ
    public GameObject bulletPrefab; //�Ѿ� ������Ʈ
    public Transform firePos;   //�߻� ��ġ
    public Animation fireAni;   //�ִϸ��̼�
    public AudioSource source;
    public AudioClip clip;
    public ParticleSystem muzzleFlash;  //����Ʈ

    [Header("����������")]
    public float fireTime;
    public HandleCtrl hc;
    void Start()
    {
        hc = this.gameObject.GetComponent<HandleCtrl>();
        fireTime = Time.time;   //���� �ð��� ����

        muzzleFlash.Stop();
    }


    void Update()
    {
        #region ���콺 ���� ��ư Ŭ��
        if (Input.GetMouseButtonDown(0)&&hc.isRun==false)    //0�� ���� 1�� ������
            Fire();
        #endregion

        //�Ѿ� �߻� ����� �ϴ� ����
        //if (Input.GetMouseButton(0))
        //{
        //    if (Time.time - fireTime > 0.5f)
        //    {    //����ð����� ���Žð��� ���� �귯�� �ð��� �ȴ�.
        //        if (hc.isRun == false)
        //            Fire();

        //        fireTime = Time.time;
        //    }
        //}

        if(Input.GetMouseButtonUp(0))
            muzzleFlash.Stop();
    }

    void Fire() //�Ѿ� �߻� �Լ�
    {
        //object ����
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
                        //what          where          How rotation

        source.PlayOneShot(clip, 1.0f);

        muzzleFlash.Play();
    }

}