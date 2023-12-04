using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : Info
{
    void Start()
    {
        if (GameManager.I.isCheat == false)
        {
            MaxHp = 100;
            Hp = 100;
            Atk = 10;
            MoveSpeed = 5;
            BulletRpm = 2;
            Character = CharacterType.Player;
        }
        else
        {
            MaxHp = 999999;
            Hp = 999999;
            Atk = 100000;
            MoveSpeed = 500;
            BulletRpm = 300;
            Character = CharacterType.Player;
        }
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(ShootProjectiles());
        gameObject.SetActive(false);
    }
    IEnumerator ShootProjectiles()
    {
        while (true)
        {
            SpawnBullet();
            yield return new WaitForSeconds(60f / BulletRpm);
        }
    }
    void SpawnBullet()
    {
        // 몬스터가 탄알을 발사하는 스크립트 가져오기
        ShootManager bulletSpawner = GetComponent<ShootManager>();
        //List<ShootManager> shootList = new List<ShootManager>();
        //shootList.Add(new CircleShoot());
        //shootList.Add(new CircleShotGotoShoot());
        //shootList.Add(new HeartShoot());
        //shootList.Add(new ShapeShoot());
        //shootList.Add(new SpinShoot());
        //shootList.Add(new StraightShoot());
        //shootList[0].Shoot(Atk);
        if (bulletSpawner != null)
        {
            // Atk 값을 전달하여 탄알 발사
            bulletSpawner.Shoot(Atk);
            SoundManager.s.PlayFXSound(atkSound);
        }
    }


}
