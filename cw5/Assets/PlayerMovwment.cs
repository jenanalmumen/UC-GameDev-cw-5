using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovwment : MonoBehaviour
{
    public Transform Maxpos;
    public Transform Minpos;
    AudioSource scr;
    public float inc = 3;
    // Start is called before the first frame update
    void Start()
    {
        scr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + inc, Minpos.position.x, Maxpos.position.x), transform.position.y, transform.position.z);
        }
      else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - inc, Minpos.position.x, Maxpos.position.x), transform.position.y, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Audio();
            Invoke("Reastart", 1f);
        }
    }
    void restart()
    {
       
        SceneManager.LoadScene(0);
    }void Audio()
    {
        scr.Play();
     
    }
}
