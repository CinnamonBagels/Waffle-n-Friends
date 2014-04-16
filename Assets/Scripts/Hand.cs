using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
    public float speed = 2f;

    private GameObject Carrying;
    private bool AbleToCarry = true;

    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
        // Get the user's input
        var x = Input.GetAxis( "Horizontal" ) * speed;
        var y = Input.GetAxis( "Vertical" ) * speed;

        Vector2 velocity = new Vector2( x, y );

        rigidbody2D.velocity = velocity;

        // if pressed space, release object
        if (Input.GetKeyDown(KeyCode.Space) && Carrying)
        {
            Carrying.transform.parent = null;
            StartCoroutine(ForceOffMe(Carrying));
            Carrying = null;
            AbleToCarry = false;
            StartCoroutine(MakeAbleToCarry());
        }
    }

    IEnumerator ForceOffMe(GameObject obj)
    {
        obj.AddComponent<Rigidbody2D>();
        yield return new WaitForFixedUpdate();
        obj.GetComponent<Rigidbody2D>().AddForce(100000 * (obj.transform.position - transform.position));
    }

    IEnumerator MakeAbleToCarry()
    {
        yield return new WaitForSeconds(1.0f);
        AbleToCarry = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!Carrying && col.gameObject.tag == "Ingredient" && AbleToCarry)
        {
            Debug.Log(gameObject.name);
            col.gameObject.transform.parent = gameObject.transform;
            Carrying = col.gameObject;
            Destroy(Carrying.GetComponent<Rigidbody2D>());
            //Destroy(Carrying.GetComponent<Collider2D>());
            //Carrying.GetComponent<Collider2D>().enabled = false;
        }
    }
}
