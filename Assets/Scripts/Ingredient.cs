using UnityEngine;

public class Ingredient : MonoBehaviour {
    private static int ingredientCount = 0;
    public GameObject waffle;

	// Use this for initialization
	void Start () {
        ingredientCount++;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Bowl")
        {
            Destroy(gameObject);
            coll.GetComponent<Bowl>().ingredients++;
            if(coll.GetComponent<Bowl>().ingredients >= ingredientCount)
            {
                Instantiate(waffle);
            }
        }
    }
}
