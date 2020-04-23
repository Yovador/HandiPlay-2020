using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PointBallSpawner : MonoBehaviour
{
    public TileBase pointBallUp;
    public TileBase pointBallDown;
    public TileBase pointBallRight;
    public TileBase pointBallLeft;

    public static bool needPointBall = true;
    private int rdmY;
    private int rdmX;
    private bool isSpaceEmpty = false;
    private Tilemap pointBallTile;
    private Tilemap playerTile;
    private Tilemap wallTile;
    private Camera mainCamera;
    private int cameraHeight;
    private int cameraWidth;
    private float resolution = Mathf.Round((1920f / 1080f) * 10f) / 10f;

    private void Start()
    {

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        pointBallTile = GameObject.FindGameObjectWithTag("PointBall").GetComponent<Tilemap>();
        playerTile = GameObject.FindGameObjectWithTag("PlayerTile").GetComponent<Tilemap>();
        wallTile = GameObject.FindGameObjectWithTag("Wall").GetComponent<Tilemap>();
        cameraHeight = (int)mainCamera.orthographicSize;
        cameraWidth = (int)Mathf.Round(cameraHeight* resolution);
        //Debug.Log("Rez : " + resolution);
        //Debug.Log("cameraHeight : " + cameraHeight + " cameraWidth : " + cameraWidth + " Expected width : " + (cameraHeight * resolution) + "Expected heigth : " + mainCamera.orthographicSize);
    }

    private void Update()
    {
        if (needPointBall)
        {
            SpawnSequence();
        }

    }
    private void SpawnSequence()
    {
        int infBreak = 0;
        while (!isSpaceEmpty)
        {
            infBreak++;
            rdmY = Random.Range(-cameraHeight, cameraHeight);
            rdmX = Random.Range(-cameraWidth, cameraWidth);
            CheckIfThereIsSomethingHere(rdmX, rdmY);
            if (infBreak > cameraHeight * cameraWidth)
            {
                isSpaceEmpty = true;
            }
        }
        infBreak = 0;
        int rdmPball = Random.Range(1, 5);
        transform.position = new Vector2(rdmX, rdmY);

        switch (rdmPball)
        {
            case 1:
                pointBallTile.SetTile(pointBallTile.WorldToCell(transform.position), pointBallUp);
                break;
            case 2:
                pointBallTile.SetTile(pointBallTile.WorldToCell(transform.position), pointBallDown);
                break;
            case 3:
                pointBallTile.SetTile(pointBallTile.WorldToCell(transform.position), pointBallRight);
                break;
            case 4:
                pointBallTile.SetTile(pointBallTile.WorldToCell(transform.position), pointBallLeft);
                break;
            default:
                break;
        }
       
        needPointBall = false;
        isSpaceEmpty = false;
    }

    private void CheckIfThereIsSomethingHere(int rdmX, int rdmY)
    {
        Vector3 pos = new Vector3(rdmX, rdmY, 0);
        if (playerTile.HasTile(playerTile.WorldToCell(pos)) || wallTile.HasTile(playerTile.WorldToCell(pos)) || pointBallTile.HasTile(playerTile.WorldToCell(pos)))
        {
            isSpaceEmpty = false;
        }
        else
        {
            isSpaceEmpty = true;
        }
    }

}
