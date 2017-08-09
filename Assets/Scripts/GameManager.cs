using UnityEngine;
using System.Threading;


public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject Map, CurrentSign, Checker;
    public GameObject[] Sigantures = new GameObject[2];
    public Transform plateGO;

    [Range(2, 10)] public int amount = 3;
    [Range(1f, 1.3f)] public float spacing = 1;
    Vector2 plates;


    private void Awake()
    {
        instance = this;
        plates = new Vector2(amount, amount);
        Map = new GameObject("Map");
        generator();
    }
    //Always set current sign to index 0, for reason check Swap() comment
    void Update ()
    {
        Sigantures[0].SetActive(true);
        CurrentSign = Sigantures[0];
    }

    //Reverse signature array for each plate click
    public GameObject Swap(ref GameObject a,ref GameObject b)
    {
        GameObject temp = a;
        a = b;
        b = temp;
        return CurrentSign = a;
    }

    //Generate plates map and checkers
    void generator()
    {
        for (int i = 0; i < plates.x; i++)
        {
            for (int j = 0; j < plates.y; j++)
            {
                Vector2 position = new Vector2(-plates.x / 2 + 0.4f + i * spacing, -plates.y / 2 + 0.4f + j * spacing);
                Transform nextPlate = (Transform)Instantiate(plateGO, position, Quaternion.identity) ;
                nextPlate.parent = Map.transform;
                
            }
            Instantiate(Checker, new Vector2(0, i + 0.1f - 1), Quaternion.Euler(0, 0, 90));
            Instantiate(Checker, new Vector2(i + 0.1f - 1 ,0), Quaternion.identity);
        }
       
    }

    //Place sign at chosen plate
    public void PlaceSign(Transform plate, GameObject Current)
    {
        Instantiate(Current, plate);
    }

    //Reload scene after circle/cross won
    public void ReloadScene(int index)
    {
        Thread.Sleep(300);
        Application.LoadLevel(index);       
    }
}
