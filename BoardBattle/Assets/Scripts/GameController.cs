using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Private Variables

    GameObject player;

    #endregion

    #region Public Variables

    [Header("Game Objects")]
    public GameObject Board;
    public GameObject Camera;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Board.GetComponent<BoardController>().GenerateBoard();

        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(CameraOnPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Public Methods

    #endregion

    #region Private Methods

    IEnumerator CameraOnPlayer()
    {
        yield return new WaitForSeconds(3);

        Camera.GetComponent<CameraController>().LookAtObject = player.transform;
    }

    #endregion
}
