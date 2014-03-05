using UnityEngine;

public class Hand : MonoBehaviour {
    public float speed = 2f;

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
    }
}
