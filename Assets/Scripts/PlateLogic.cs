using UnityEngine;

public class PlateLogic : MonoBehaviour {

    public static PlateLogic instance;
    public GameObject highlight;
    bool used, joypad;
    Collider2D col;
    string[] joypadName;
    public int PlateIndex;

	void Start () {
        instance = this;
        col = GetComponent<Collider2D>();
        joypadName = Input.GetJoystickNames();
        if (joypadName == null) joypad = false; else joypad = true;
    }

#if UNITY_ANDROID || UNITY_IPHONE
    //Mostly touch input
    void Update () {
        if (Input.touchCount > 0)
        {
            Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (col == Physics2D.OverlapPoint(WorldPoint))
            {
                if (!used)
                {
                    GameManager.instance.PlaceSign(this.transform, GameManager.instance.CurrentSign);
                    GameManager.instance.Swap(ref GameManager.instance.Sigantures[0], ref GameManager.instance.Sigantures[1]);
                    //print(this.transform.position);
                    used = true;
                }
                else return;
            }
        }
    }
#endif

#if UNITY_EDITOR || UNITY_STANDALONE
    //Mouse/joypad logic
    private void OnMouseEnter()
    {
        Instantiate(highlight, this.transform.position, Quaternion.identity);
    }

    private void OnMouseDown()
    {
        PlaceSignature();
    }
    private void OnMouseExit()
    {
        GameObject destroy = GameObject.Find("Highlight(Clone)");
        Destroy(destroy);
    }

#endif
    //Place sign at given plate and set it as used, so u cannot place another sign at this place
    void PlaceSignature()
    {
        if (!used)
        {
            GameManager.instance.PlaceSign(this.transform, GameManager.instance.CurrentSign);
            GameManager.instance.Swap(ref GameManager.instance.Sigantures[0], ref GameManager.instance.Sigantures[1]);
            //print(this.transform.position);
            used = true;
        }
        else return;
    }

}
