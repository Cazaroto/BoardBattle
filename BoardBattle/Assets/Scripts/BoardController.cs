using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    #region Private Variables

    int lines = 16, columns = 16;
    int[] playerSpwanTileNumbers = new int[2], targetSpawnTileNumbers = new int[2];

    #endregion

    #region Public Variables

    [Header("Game Objects")]
    public GameObject Player;
    public GameObject Target;
    public GameObject GrassTile;
    public GameObject PlayerSpawnTile;
    public GameObject TargetSpawnTile;
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Public Methods

    public void GenerateBoard()
    {
        RandomizeSpawns();

        int count = 0;

        for (int l = 0; l < lines;  l++)
        {
            for (int c = 0; c < columns; c++)
            {
                //Player Spawn Spot
                if (playerSpwanTileNumbers[0] == l && playerSpwanTileNumbers[1] == c)
                {
                    Instantiate(PlayerSpawnTile, new Vector3(l, 0f, c), Quaternion.identity, transform);
                    Instantiate(Player, new Vector3(l, 1f, c), Quaternion.identity, transform);
                }

                //Target Spawn Spot
                if (targetSpawnTileNumbers[0] == l && targetSpawnTileNumbers[1] == c)
                {
                    Instantiate(TargetSpawnTile, new Vector3(l, 0f, c), Quaternion.identity, transform);
                    Instantiate(Target, new Vector3(l, 1f, c), Quaternion.identity, transform);
                }

                Instantiate(GrassTile, new Vector3(l, 0f, c), Quaternion.identity, transform);
                count++;
            }
        }

        Debug.Log($"Numero de Blocos: {count}");
    }

    #endregion

    #region Private Methods

    private void RandomizeSpawns()
    {
        playerSpwanTileNumbers[0] = targetSpawnTileNumbers[0] = Random.Range(0, 16);
        playerSpwanTileNumbers[1] = targetSpawnTileNumbers[1] = Random.Range(0, 16);

        do
        {
            targetSpawnTileNumbers[0] = Random.Range(0, 16);
            targetSpawnTileNumbers[1] = Random.Range(0, 16);
        } while (playerSpwanTileNumbers[0] == targetSpawnTileNumbers[0] && playerSpwanTileNumbers[1] == targetSpawnTileNumbers[1]);

        Debug.Log($"Player spawn -  [{playerSpwanTileNumbers[0]},{playerSpwanTileNumbers[1]}]");
        Debug.Log($"Target spawn -  [{targetSpawnTileNumbers[0]},{targetSpawnTileNumbers[1]}]");
    }

    #endregion
}
