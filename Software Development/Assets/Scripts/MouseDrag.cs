using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{

    private Vector3 mOffset;
    private float mZCoord;
    private bool dragging = false;
    private int startX;
    private int startY;

    private Vector3 startPos;
    
    public bool isKnight;
    public bool isQueen;
    public GameObject Reset;

     void Start()
    {
        Reset = GameObject.Find("Reset");
    }
    void update(){
        
    }
    

    void OnMouseDown() {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
       // Debug.Log(gameObject.name);
    }

    void OnMouseUp() {
        PlayerMovement playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if(playerScript.animating && ValidForMove(gameObject)) {
        dragging = false;
        ChessLogic chessScript = GameObject.Find("Board").GetComponent<ChessLogic>();

        float xPos = gameObject.transform.position.x;
        float zPos = gameObject.transform.position.z;

        if(isKnight) {
            xPos += chessScript.knightXOffset;
            zPos += chessScript.knightZOffset;
        }

        if(isQueen) {
            xPos += chessScript.queenXOffset;
            zPos += chessScript.queenZOffset;
        }

        GameObject closestSquare = chessScript.tiles[0];
        float closestDis = Mathf.Sqrt(((closestSquare.transform.position.x - xPos) * (closestSquare.transform.position.x - xPos)) + ((closestSquare.transform.position.z - zPos) * (closestSquare.transform.position.z - zPos)));
        int index = 0;
        
        for(int i=0; i<64; i++) {
            GameObject refSquare = chessScript.tiles[i];
            float distance = Mathf.Sqrt(((refSquare.transform.position.x - xPos) * (refSquare.transform.position.x - xPos)) + ((refSquare.transform.position.z - zPos) * (refSquare.transform.position.z - zPos)));
            if(distance < closestDis) {
                closestDis = distance;
                closestSquare = refSquare;
                index = i;
            }
        }
        int row = 7 - index%8;
        int col = index/8;

        if(chessScript.CheckMove(gameObject, startX, startY, row, col)) { 
            if(isKnight) {
                gameObject.transform.position = new Vector3(closestSquare.transform.position.x - chessScript.knightXOffset, gameObject.transform.position.y, closestSquare.transform.position.z - chessScript.knightZOffset);
            } else if(isQueen) {
                gameObject.transform.position = new Vector3(closestSquare.transform.position.x - chessScript.queenXOffset, gameObject.transform.position.y, closestSquare.transform.position.z - chessScript.queenZOffset);
            } else {
                gameObject.transform.position = new Vector3(closestSquare.transform.position.x, gameObject.transform.position.y, closestSquare.transform.position.z);
            }

          // ResetAll.Reset();
          Reset.SetActive(false);
           
            //Transition back to FPS
            PlayerMovement playerS = GameObject.Find("Player").GetComponent<PlayerMovement>();

            playerS.animating = false;
            playerS.frameCount = 0;

            Camera.main.orthographic = false;
            Cursor.lockState = CursorLockMode.Locked;

            //Check For Win

            bool blackWin = true;
            bool whiteWin = true;

            for(int i=0; i<8; i++) {
                for(int j=0; j<8; j++) {
                    if(chessScript.board[i,j] != null) {
                        if(chessScript.board[i,j].name == "BKi")
                            whiteWin = false;
                        if(chessScript.board[i,j].name == "WKi")
                            blackWin = false;
                    }
                }
            }

            if(blackWin)
                Debug.Log("Black Wins!");
            if(whiteWin)
                Debug.Log("White Wins!");

        } else {
            gameObject.transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
        }

        }
    }

    void OnMouseDrag() {
        PlayerMovement playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        ChessLogic chessScript = GameObject.Find("Board").GetComponent<ChessLogic>();
        if(playerScript.animating && ValidForMove(gameObject)) {
            if(!dragging) {
                for(int i=0; i<8; i++) {
                    for(int j=0; j<8; j++) {
                        if(GameObject.ReferenceEquals(chessScript.board[i,j], gameObject)) {
                            startX = i;
                            startY = j;
                            i+=8;
                            j+=8;
                        }
                    }
                }
                dragging = true;
            }
            transform.position = GetMouseWorldPos() + mOffset;
        }
    }

    private Vector3 GetMouseWorldPos() {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private bool ValidForMove(GameObject piece) {
        Debug.Log("the object sub 0 to 1 is " +piece.name.Substring(0,1) );
        PlayerMovement playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
            if ((piece.name.Substring(0,1) == "W") && playerScript.whiteTurn){
        return true;
            } 
         if ((piece.name.Substring(0,1) == "B") && !playerScript.whiteTurn){
        return true;
         } 

        return false;
    }
}

