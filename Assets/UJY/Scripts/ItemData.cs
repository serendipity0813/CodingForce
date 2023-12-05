using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using static Info;
using Color = UnityEngine.Color;

public class ItemData : MonoBehaviour
{
    public GameObject Apple;
    public GameObject Banana;
    public GameObject Kiwi;
    public GameObject Pineapple;
    public GameObject Melon;
    static GameObject Shield;
    public AudioClip getSound;

    private float changeSpeed = 60;
    float tt = 0;
    bool change = false;


    SpriteRenderer spriteRenderer;
    //public AudioClip ItemSound;


    void Start()
    {
        float x = Random.Range(-8f, 8f);
        float y = 4;
        transform.position = new Vector3(x, y, 0);
        if(Shield == null)
        {
            Shield = GameObject.FindGameObjectWithTag("Shield");
            spriteRenderer = Shield.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(200 / 255, 255 / 255, 255 / 255, 255 / 255);
            Shield.SetActive(false);
        }
    }   

    private void OnTriggerEnter2D(Collider2D other)
    {
        Info playerInfo = other.GetComponent<Info>();
        if (other != null && other.CompareTag("Player"))
        {
            if (getSound != null)
            {
                SoundManager.s.PlayFXSound(getSound);
            }
            else
            {
                Debug.Log("get Sound is Null");
            }

            if (playerInfo != null)
            {
                if (gameObject == Apple)
                {
                    other.GetComponent<Info>().Hp += 20;
                }
                else if (gameObject == Banana)
                {
                    other.GetComponent<Info>().Atk += 5;
                }
                else if (gameObject == Kiwi)
                {
                    other.GetComponent<Info>().BulletRpm += 5;
                    other.GetComponent<Info>().MoveSpeed += 5;
                }
                else if (gameObject == Pineapple)
                {
                    GameObject[] mbullet = GameObject.FindGameObjectsWithTag("Mbullet");
                    GameObject[] monster = GameObject.FindGameObjectsWithTag("Monster");

                    for (int i = 0; i < mbullet.Length; i++)
                    {
                        Destroy(mbullet[i]);
                    }

                    for (int i = 0; i < monster.Length; i++)
                    {
                        Destroy(monster[i]);
                    }
                }
                else if (gameObject == Melon)
                {
                    Debug.Log("�������");
                    Shield.SetActive(true);
                    Invoke("ChangeAlphaCoroution", 5f);
                    Invoke("ShieldOff", 10f);
                }

                Destroy(gameObject);

                Debug.Log("������ ȹ��");
            }
            else
            {
                Debug.LogError("'User' �±׸� ���� ��ü���� Info ������Ʈ�� ã�� �� �����ϴ�.");
            }
        }


    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Collision")
        {
            Destroy(gameObject);
        }

    }

        

    void ShieldOff()
    {
        Debug.Log("��������");
        Shield.SetActive(false);
    }

    IEnumerator ChangeAlphaCoroution()
    {
        while (true)
        {
            if (!change)
            {
                tt += 1;

                if (tt >= changeSpeed)
                {
                    change = true;
                }
            }
            else
            {
                tt -= 1;

                if (tt <= 0)
                {
                    change = false;
                }
            }

            spriteRenderer.color = new Color(200/255, 255/255, 255/255, tt / changeSpeed);

            yield return new WaitForSeconds(0.01f);
        }
    }


}