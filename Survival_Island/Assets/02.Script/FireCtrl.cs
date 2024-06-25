using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    [Header("컴퍼넌트들")]
    //총알오브젝트
    public GameObject bulletPrefab; //총알 오브젝트
    public Transform firePos;   //발사 위치
    public Animation fireAni;   //애니메이션
    public AudioSource source;
    public AudioClip clip;
    public ParticleSystem muzzleFlash;  //이팩트

    [Header("각종변수들")]
    public float fireTime;
    public HandleCtrl hc;
    void Start()
    {
        hc = this.gameObject.GetComponent<HandleCtrl>();
        fireTime = Time.time;   //현재 시간을 대입

        muzzleFlash.Stop();
    }


    void Update()
    {
        #region 마우스 왼쪽 버튼 클릭
        if (Input.GetMouseButtonDown(0)&&hc.isRun==false)    //0은 왼쪽 1은 오른쪽
            Fire();
        #endregion

        //총알 발사 연사로 하는 로직
        //if (Input.GetMouseButton(0))
        //{
        //    if (Time.time - fireTime > 0.5f)
        //    {    //현재시간에서 과거시간을 빼면 흘러간 시간이 된다.
        //        if (hc.isRun == false)
        //            Fire();

        //        fireTime = Time.time;
        //    }
        //}

        if(Input.GetMouseButtonUp(0))
            muzzleFlash.Stop();
    }

    void Fire() //총알 발사 함수
    {
        //object 생성
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
                        //what          where          How rotation

        source.PlayOneShot(clip, 1.0f);

        muzzleFlash.Play();
    }

}