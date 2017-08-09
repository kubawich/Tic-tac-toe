using UnityEngine;

public class Checker : MonoBehaviour {

    int CircleIntersections, CrossIntersections = 0;
	
    //Reload Scene if there're 3 same signatures at row/column
	void Update () {
        if (CircleIntersections == 3)
        {
            GameManager.instance.ReloadScene(0);
        }
        else if (CrossIntersections == 3) GameManager.instance.ReloadScene(0);
        else return;
	}

    //Checks if checker is contaction' with circle plate or cross one
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Circle")
        {
            CircleIntersections++;
        }
        else if (collision.gameObject.tag == "Cross") CrossIntersections++;
    }
}
