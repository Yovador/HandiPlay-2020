using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerController : MonoBehaviour
{
    public TileBase headUp;
    public TileBase headDown;
    public TileBase headRight;
    public TileBase headLeft;

    public TileBase tailUp;
    public TileBase tailDown;
    public TileBase tailRight;
    public TileBase tailLeft;

    public TileBase bodyHorizontal;
    public TileBase bodyVertical;

    public TileBase bodyUpLeft;
    public TileBase bodyUpRight;
    public TileBase bodyDownLeft;
    public TileBase bodyDownRight;

    public static bool isSnakeAlive = true;

    public int maxSnakeSize;

    private Tilemap playerTileMap;
    private Tilemap pointballTileMap;
    private Tilemap wallTileMap;

    private bool movingRoutineOn = false;
    private int directionState = 0; // 0: Up, 1: right, 2:down, 3:left
    private KeyCode lastKey = KeyCode.UpArrow;
    private List<Vector3Int> snakePosition = new List<Vector3Int>();


    private void Start()
    {
        playerTileMap = GameObject.FindGameObjectWithTag("PlayerTile").GetComponent<Tilemap>();
        wallTileMap = GameObject.FindGameObjectWithTag("Wall").GetComponent<Tilemap>();
        pointballTileMap = GameObject.FindGameObjectWithTag("PointBall").GetComponent<Tilemap>();
        PointBallSpawner.needPointBall = true;
        PlayerController.isSnakeAlive = true;
    }

    private void Update()
    {

        if (!movingRoutineOn)
        {
            if (!GameManager.gamePauseOn && isSnakeAlive)
            {
                StartCoroutine(MovingRoutine());
            }
            GetLastKey();
        }

    }


    private IEnumerator MovingRoutine()
    {
        movingRoutineOn = true;
        
        yield return new WaitForSecondsRealtime(PlayerPrefs.GetFloat("GameSpeed"));
        if (!GameManager.gamePauseOn)
        {
            Movement();
            SnakeCollide();
            if (isSnakeAlive)
            {
                CheckSnakeSize();
                SnakeDisplay();
            }
        }
        movingRoutineOn = false;

    }

    private void Movement()
    {
        if (lastKey == InputManager.Gup && directionState != 2)
        {
            directionState = 0;
        }
        if (lastKey == InputManager.Gdown && directionState != 0)
        {
            directionState = 2;
        }
        if (lastKey == InputManager.Gright && directionState != 3)
        {
            directionState = 1;
        }
        if (lastKey == InputManager.Gleft && directionState != 1)
        {
            directionState = 3;
        }


        switch (directionState)
        {
            case 0:
                transform.position += new Vector3(0, 1, 0);
                break;
            case 1:
                transform.position += new Vector3(1, 0, 0);
                break;
            case 2:
                transform.position += new Vector3(0, -1, 0);
                break;
            case 3:
                transform.position += new Vector3(-1, 0, 0);
                break;
            default:
                break;
        }
    }


    private void GetLastKey()
    {
        if (lastKey != InputManager.KeyPressed)
        {
            lastKey = InputManager.KeyPressed;
            Debug.Log("Input : " + lastKey);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PointBall")
        {
            pointballTileMap.SetTile(pointballTileMap.WorldToCell(collision.ClosestPoint(transform.position)), null);
            PointBallSpawner.needPointBall = true;
            AudioManager.PlayASound("PointBallTaken");
            ScoreDisplay.score++;
            ExtendSnake();
        }
    }

    private void SnakeCollide()
    {

        if (snakePosition.Contains(playerTileMap.WorldToCell(transform.position)) && playerTileMap.WorldToCell(transform.position) != snakePosition[snakePosition.Count -1])
        {
            isSnakeAlive = false;
        }
        if (wallTileMap.HasTile(playerTileMap.WorldToCell(transform.position)))
        {
            isSnakeAlive = false;
        }

    }



    private void CheckSnakeSize()
    {
        if (snakePosition.Count > maxSnakeSize)
        {
            playerTileMap.SetTile(snakePosition[0], null);
            snakePosition.RemoveAt(0);
        }
    }

    private void ExtendSnake()
    {
        maxSnakeSize ++;
    }

    private void SnakeDisplay()
    {

        snakePosition.Add(playerTileMap.WorldToCell(transform.position));

        for (int i = 0; i < snakePosition.Count; i++)
        {
            if (snakePosition[i] == snakePosition[snakePosition.Count - 1])
            {
                switch (directionState)
                {
                    case 0:
                        playerTileMap.SetTile(snakePosition[i], headUp);
                        break;
                    case 1:
                        playerTileMap.SetTile(snakePosition[i], headRight);
                        break;
                    case 2:
                        playerTileMap.SetTile(snakePosition[i], headDown);
                        break;
                    case 3:
                        playerTileMap.SetTile(snakePosition[i], headLeft);
                        break;
                    default:
                        playerTileMap.SetTile(snakePosition[i], headUp);
                        break;
                }
            }
            else if (snakePosition[i] == snakePosition[0])
            {
                int x = snakePosition[i].x;
                int y = snakePosition[i].y;
                int nextX = snakePosition[i + 1].x;
                int nextY = snakePosition[i + 1].y;

                if (nextX == x +1)
                {
                    playerTileMap.SetTile(snakePosition[0], tailRight);
                }

                if (nextX == x - 1)
                {
                    playerTileMap.SetTile(snakePosition[0], tailLeft);
                }

                if (nextY == y + 1)
                {
                    playerTileMap.SetTile(snakePosition[0], tailUp);
                }

                if (nextY == y - 1)
                {
                    playerTileMap.SetTile(snakePosition[0], tailDown);
                }

            }
            else
            {
                int previousX = snakePosition[i - 1].x;
                int previousY = snakePosition[i - 1].y;
                int nextX = snakePosition[i + 1].x;
                int nextY = snakePosition[i + 1].y;
                int x = snakePosition[i].x;
                int y = snakePosition[i].y;

                if (previousX == x && nextX == x && ((previousY == y - 1 && nextY == y + 1) || (previousY == y + 1 && nextY == y - 1)))
                {
                    playerTileMap.SetTile(snakePosition[i], bodyVertical);
                }

                if (previousY == y && nextY == y && ((previousX == x - 1 && nextX == x + 1) || (previousX == x + 1 && nextX == x - 1)))
                {
                    playerTileMap.SetTile(snakePosition[i], bodyHorizontal);
                }

                if ( (x == previousX && y == nextY && nextX == x + 1 && previousY == y - 1) || (x == nextX && y == previousY && previousX == x + 1 && nextY == y - 1) )
                {
                    playerTileMap.SetTile(snakePosition[i], bodyDownRight);
                }

                if ((x == previousX && y == nextY && nextX == x - 1 && previousY == y - 1) || (x == nextX && y == previousY && previousX == x - 1 && nextY == y - 1))
                {
                    playerTileMap.SetTile(snakePosition[i], bodyDownLeft);
                }


                if ((x == previousX && y == nextY && nextX == x + 1 && previousY == y + 1) || (x == nextX && y == previousY && previousX == x + 1 && nextY == y + 1))
                {
                    playerTileMap.SetTile(snakePosition[i], bodyUpRight);
                }


                if ((x == previousX && y == nextY && nextX == x - 1 && previousY == y + 1) || (x == nextX && y == previousY && previousX == x - 1 && nextY == y + 1))
                {
                    playerTileMap.SetTile(snakePosition[i], bodyUpLeft);
                }

            }

        }

    }

}
