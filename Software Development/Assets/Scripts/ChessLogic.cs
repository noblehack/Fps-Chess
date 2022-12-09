using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessLogic : MonoBehaviour
{
    public GameObject[,] board = new GameObject[8,8];
    public GameObject[] tiles;
    public float knightXOffset;
    public float knightZOffset;
    public float queenXOffset;
    public float queenZOffset;

    // Start is called before the first frame update
    void Start()
    {
        //create starting board
        board[0,0] = GameObject.Find("BRo1");
        board[0,1] = GameObject.Find("BKn1");
        board[0,2] = GameObject.Find("BBi1");
        board[0,3] = GameObject.Find("BQu");
        board[0,4] = GameObject.Find("BKi");
        board[0,5] = GameObject.Find("BBi2");
        board[0,6] = GameObject.Find("BKn2");
        board[0,7] = GameObject.Find("BRo2");
        board[1,0] = GameObject.Find("BPa1");
        board[1,1] = GameObject.Find("BPa2");
        board[1,2] = GameObject.Find("BPa3");
        board[1,3] = GameObject.Find("BPa4");
        board[1,4] = GameObject.Find("BPa5");
        board[1,5] = GameObject.Find("BPa6");
        board[1,6] = GameObject.Find("BPa7");
        board[1,7] = GameObject.Find("BPa8");
        board[7,0] = GameObject.Find("WRo1");
        board[7,1] = GameObject.Find("WKn1");
        board[7,2] = GameObject.Find("WBi1");
        board[7,3] = GameObject.Find("WQu");
        board[7,4] = GameObject.Find("WKi");
        board[7,5] = GameObject.Find("WBi2");
        board[7,6] = GameObject.Find("WKn2");
        board[7,7] = GameObject.Find("WRo2");
        board[6,0] = GameObject.Find("WPa1");
        board[6,1] = GameObject.Find("WPa2");
        board[6,2] = GameObject.Find("WPa3");
        board[6,3] = GameObject.Find("WPa4");
        board[6,4] = GameObject.Find("WPa5");
        board[6,5] = GameObject.Find("WPa6");
        board[6,6] = GameObject.Find("WPa7");
        board[6,7] = GameObject.Find("WPa8");

        knightXOffset = tiles[15].transform.position.x - board[0,1].transform.position.x;
        knightZOffset = tiles[15].transform.position.z - board[0,1].transform.position.z;

        queenXOffset = tiles[31].transform.position.x - board[0,3].transform.position.x;
        queenZOffset = tiles[31].transform.position.z - board[0,3].transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckMove(GameObject piece, int startX, int startY, int endX, int endY) {
        bool isWhite = piece.name.Substring(0,1).Equals("W");
        Debug.Log("move was checked");
        //pawn
        if(piece.name.Substring(1,2).Equals("Pa")) {
            if(isWhite) {
                //white pawn
                if(startX - endX == 1 && endY == startY) {
                    if(board[endX, endY] == null) {
                        board[startX, startY] = null;
                        board[endX, endY] = piece;
                      // Debug.Log("option 1");
                        return true;
                       
                    }
                  // Debug.Log("option 2");
                    return false;
                } else if(startX - endX == 2 && endY == startY && startX == 6) {
                    if(board[endX, endY] == null && board[endX+1, endY] == null) {
                        board[startX, startY] = null;
                        board[endX, endY] = piece;
                        //Debug.Log("option 3");
                        return true;
                        
                    }
                    //Debug.Log("option 4");
                    return false;
                    }
                else if((startX - endX == 1 && Mathf.Abs(endY - startY) == 1)) {
                    if(board[endX, endY] != null) {
                        if(board[endX, endY].name.Substring(0,1).Equals("B")) {
                            Destroy(board[endX, endY]);
                            board[endX, endY] = piece;
                            board[startX, startY] = null;
                           // Debug.Log("option 5");
                            return true;
                             
                        }
                    }
                   // Debug.Log("option 6");
                    return false;
                }
            } else {
                //black pawn
                if(startX - endX == -1 && endY == startY) {
                    if(board[endX, endY] == null) {
                        board[startX, startY] = null;
                        board[endX, endY] = piece;
                        return true;
                    }
                    return false;
                } else if(startX - endX == -2 && endY == startY && startX == 1) {
                    if(board[endX, endY] == null && board[endX-1, endY] == null) {
                        board[startX, startY] = null;
                        board[endX, endY] = piece;
                        return true;
                    }
                    return false;
                } else if((startX - endX == -1 && Mathf.Abs(endY - startY) == 1)) {
                    if(board[endX, endY] != null) {
                        if(board[endX, endY].name.Substring(0,1).Equals("W")) {
                            Destroy(board[endX, endY]);
                            board[endX, endY] = piece;
                            board[startX, startY] = null;
                            return true;
                        }
                    }
                    return false;
                }
            }
        }   

        //rook
        else if(piece.name.Substring(1,2).Equals("Ro")) {
            if(startX == endX && startY != endY) {
                if(startY > endY) {
                    for(int i=startY-1; i>endY; i--) {
                        if(board[startX,i] != null)
                            return false;
                    }
                } else {
                    for(int i=startY+1; i<endY; i++) {
                        if(board[startX,i] != null)
                            return false;
                    }
                }
            } else if(startY == endY && startX != endX) {
                if(startX > endX) {
                    for(int i=startX-1; i>endX; i--) {
                        if(board[i,startY] != null)
                            return false;
                    }
                } else {
                    for(int i=startX+1; i<endX; i++) {
                        if(board[i,startY] != null)
                            return false;
                    }
                }
            } else {
                return false;
            }
            if(board[endX,endY] == null) {
                board[endX, endY] = piece;
                board[startX, startY] = null;
                return true;
            } else if(isWhite) {
                if(board[endX, endY].name.Substring(0,1).Equals("B")) {
                    Destroy(board[endX, endY]);
                    board[endX, endY] = piece;
                    board[startX, startY] = null;
                    return true;
                }
            } else {
                if(board[endX, endY].name.Substring(0,1).Equals("W")) {
                    Destroy(board[endX, endY]);
                    board[endX, endY] = piece;
                    board[startX, startY] = null;
                    return true;
                }
            }
        }

        //bishop
        else if(piece.name.Substring(1,2).Equals("Bi")) {
            if(Mathf.Abs(startX - endX) == Mathf.Abs(startY - endY) && startX - endX != 0) {
                if(endX < startX) {
                    //decrease X from start
                    if(endY < startY) {
                        //decrease Y from start
                        for(int i=1; i<startX-endX; i++) {
                            if(board[startX-i,startY-i] != null)
                                return false;
                        }
                    } else {
                        //increase Y from start
                        for(int i=1; i<startX-endX; i++) {
                            if(board[startX-i,startY+i] != null)
                                return false;
                        }
                    }
                } else {
                    //increase X from start
                    if(endY < startY) {
                        //decrease Y from start
                        for(int i=1; i<endX-startX; i++) {
                            if(board[startX+i,startY-i] != null)
                                return false;
                        }
                    } else {
                        //increase Y from start
                        for(int i=1; i<endX-startX; i++) {
                            if(board[startX+i,startY+i] != null)
                                return false;
                        }
                    }
                }
                if(board[endX, endY] == null) {
                    board[endX, endY] = piece;
                    board[startX, startY] = null;
                    return true;
                } else if(isWhite) {
                    if(board[endX, endY].name.Substring(0,1).Equals("B")) {
                        Destroy(board[endX, endY]);
                        board[endX, endY] = piece;
                        board[startX, startY] = null;
                        return true;
                    }
                } else {
                    if(board[endX, endY].name.Substring(0,1).Equals("W")) {
                        Destroy(board[endX, endY]);
                        board[endX, endY] = piece;
                        board[startX, startY] = null;
                        return true;
                    }
                }
            }
            return false;
        }

        //queen
        else if(piece.name.Substring(1,2).Equals("Qu")) {
            //bishop movement
            if(Mathf.Abs(startX - endX) == Mathf.Abs(startY - endY) && startX - endX != 0) {
                if(endX < startX) {
                    //decrease X from start
                    if(endY < startY) {
                        //decrease Y from start
                        for(int i=1; i<startX-endX; i++) {
                            if(board[startX-i,startY-i] != null)
                                return false;
                        }
                    } else {
                        //increase Y from start
                        for(int i=1; i<startX-endX; i++) {
                            if(board[startX-i,startY+i] != null)
                                return false;
                        }
                    }
                } else {
                    //increase X from start
                    if(endY < startY) {
                        //decrease Y from start
                        for(int i=1; i<endX-startX; i++) {
                            if(board[startX+i,startY-i] != null)
                                return false;
                        }
                    } else {
                        //increase Y from start
                        for(int i=1; i<endX-startX; i++) {
                            if(board[startX+i,startY+i] != null)
                                return false;
                        }
                    }
                }
                if(board[endX, endY] == null) {
                    board[endX, endY] = piece;
                    board[startX, startY] = null;
                    return true;
                } else if(isWhite) {
                    if(board[endX, endY].name.Substring(0,1).Equals("B")) {
                        Destroy(board[endX, endY]);
                        board[endX, endY] = piece;
                        board[startX, startY] = null;
                        return true;
                    }
                } else {
                    if(board[endX, endY].name.Substring(0,1).Equals("W")) {
                        Destroy(board[endX, endY]);
                        board[endX, endY] = piece;
                        board[startX, startY] = null;
                        return true;
                    }
                }
            }
            //rook movement
            else if(startX == endX && startY != endY) {
                if(startY > endY) {
                    for(int i=startY-1; i>endY; i--) {
                        if(board[startX,i] != null)
                            return false;
                    }
                } else {
                    for(int i=startY+1; i<endY; i++) {
                        if(board[startX,i] != null)
                            return false;
                    }
                }
            } else if(startY == endY && startX != endX) {
                if(startX > endX) {
                    for(int i=startX-1; i>endX; i--) {
                        if(board[i,startY] != null)
                            return false;
                    }
                } else {
                    for(int i=startX+1; i<endX; i++) {
                        if(board[i,startY] != null)
                            return false;
                    }
                }
            } else {
                return false;
            }
            if(board[endX,endY] == null) {
                board[endX, endY] = piece;
                board[startX, startY] = null;
                return true;
            } else if(isWhite) {
                if(board[endX, endY].name.Substring(0,1).Equals("B")) {
                    Destroy(board[endX, endY]);
                    board[endX, endY] = piece;
                    board[startX, startY] = null;
                    return true;
                }
            } else {
                if(board[endX, endY].name.Substring(0,1).Equals("W")) {
                    Destroy(board[endX, endY]);
                    board[endX, endY] = piece;
                    board[startX, startY] = null;
                    return true;
                }
            }
            return false;
        }
        
        //king
        else if(piece.name.Substring(1,2).Equals("Ki")) {
            if((Mathf.Abs(startX - endX) == 1 && startY == endY) || (Mathf.Abs(startY - endY) == 1 && startX == endX) || (Mathf.Abs(startX - endX) == Mathf.Abs(startY - endY) && Mathf.Abs(startX - endX) == 1)) {
                if(!(startX == endX && startY == endY)) {
                    if(board[endX,endY] == null) {
                        board[endX, endY] = piece;
                        board[startX, startY] = null;
                        return true;
                    } else if(isWhite) {
                        if(board[endX, endY].name.Substring(0,1).Equals("B")) {
                            Destroy(board[endX, endY]);
                            board[endX, endY] = piece;
                            board[startX, startY] = null;
                            return true;
                        }
                    } else {
                        if(board[endX, endY].name.Substring(0,1).Equals("W")) {
                            Destroy(board[endX, endY]);
                            board[endX, endY] = piece;
                            board[startX, startY] = null;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //knight
        else if(piece.name.Substring(1,2).Equals("Kn")) {
            if(Mathf.Abs(startX - endX) == 2 && Mathf.Abs(startY - endY) == 1) {
                if(board[endX,endY] == null) {
                    board[endX, endY] = piece;
                    board[startX, startY] = null;
                    return true;
                } else if(isWhite) {
                    if(board[endX, endY].name.Substring(0,1).Equals("B")) {
                        Destroy(board[endX, endY]);
                        board[endX, endY] = piece;
                        board[startX, startY] = null;
                        return true;
                    }
                } else {
                    if(board[endX, endY].name.Substring(0,1).Equals("W")) {
                        Destroy(board[endX, endY]);
                        board[endX, endY] = piece;
                        board[startX, startY] = null;
                        return true;
                    }
                }
                return false;
            } else if(Mathf.Abs(startX - endX) == 1 && Mathf.Abs(startY - endY) == 2) {
                if(board[endX,endY] == null) {
                    board[endX, endY] = piece;
                    board[startX, startY] = null;
                    return true;
                } else if(isWhite) {
                    if(board[endX, endY].name.Substring(0,1).Equals("B")) {
                        Destroy(board[endX, endY]);
                        board[endX, endY] = piece;
                        board[startX, startY] = null;
                        return true;
                    }
                } else {
                    if(board[endX, endY].name.Substring(0,1).Equals("W")) {
                        Destroy(board[endX, endY]);
                        board[endX, endY] = piece;
                        board[startX, startY] = null;
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        return false;
    }
}
