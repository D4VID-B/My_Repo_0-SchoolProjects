using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject collectible;

    public int collectibleNumber = 10;
    int itemsCollected = 0;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        InitCubes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitCubes()
    {

        GameObject cubeHolder = new GameObject();

        cubeHolder.name = "Cube_Holder";

        for(int i = 0; i < collectibleNumber; i++)
        {
            GameObject cube = Instantiate(collectible, cubeHolder.transform);

            cube.name = "Cube_" + i;

            cube.transform.position = getAPosition();
        }
    }

    Vector3 getAPosition()
    {
        Vector3 position = Vector3.zero;

        int randX = Random.Range(-7, 8);
        int randY = Random.Range(-3, 6);
        int randZ = 0;

        position.x = randX;
        position.y = randY;

        return position;
    }

    public void Collect(GameObject cube)
    {
        cube.SetActive(false);

        itemsCollected++;

        scoreText.text = itemsCollected.ToString();
    }

}
