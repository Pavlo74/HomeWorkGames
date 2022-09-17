using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float force;//сила стрибка
    Rigidbody2D BirdRigid;
    // Start is called before the first frame update
    public GameObject RestartButton;
    void Start()
    {
        Time.timeScale = 1;
        BirdRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//якщо нажати мишою, відбудеться сторибок
        {
            BirdRigid.velocity = Vector2.up * force;//velocity - сила

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Destroy(gameObject);
            Time.timeScale = 0;//якщо телефон вдаряється, то час зупиняється
            RestartButton.SetActive(true);//при зіткненні буде з'являтися
        }
    }
}
