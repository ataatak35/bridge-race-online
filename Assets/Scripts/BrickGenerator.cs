using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour{
    [SerializeField]private GameObject collectablesGameObject;
    [SerializeField]private GameObject [] collactables; //0-blue 1-green 2-red
    private int greenCnt = 0, redCnt = 0, blueCnt = 0;

    enum Colors{
        Blue,
        Green,
        Red
    }
    
    void Start(){
        CreateRandomBricks();
    }

    public void CreateRandomBricks(){
        for (int i = 0; i < collectablesGameObject.transform.childCount; i++){
            CreateSameAmountOfRandomBricks(i);
        }
    }
public void CreateSameAmountOfRandomBricks(int i){
        int randomNumber = Random.Range(0, 3);
        
        if (randomNumber == 0 && blueCnt < 12){
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity);
            blueCnt++;
        }
        else if (blueCnt > 12){
            if (redCnt < 12){
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity);
                redCnt++;
            } 
            else if (redCnt > 12){
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
                greenCnt++;
            }
        }
        
        if (randomNumber == 1 && greenCnt < 12){ 
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
            greenCnt++;
        } 
        else if (greenCnt > 12){ 
            if (redCnt < 12){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
                redCnt++;
            } 
            else if (redCnt > 12){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
                blueCnt++;
            }
        }
        
        if (randomNumber == 2 && redCnt < 12){
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
            redCnt++;
        } 
        else if (redCnt > 12){ 
            if (greenCnt < 12){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
                greenCnt++;
            } 
            else if (greenCnt > 12){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
                blueCnt++;
            }
        }
    }


public void CheckAndCreateDelayedBricks(Vector3 pos){
    int randomNumber = Random.Range(0, 3);

    if (randomNumber == 0 && blueCnt < 12){
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], pos, Quaternion.identity);
            blueCnt++;
        }
        else if (blueCnt > 12){
            if (redCnt < 12){
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], pos, Quaternion.identity);
                redCnt++;
            } 
            else if (redCnt > 12){
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], pos, Quaternion.identity); 
                greenCnt++;
            }
        }
        
        if (randomNumber == 1 && greenCnt < 12){ 
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], pos, Quaternion.identity); 
            greenCnt++;
        } 
        else if (greenCnt > 12){ 
            if (redCnt < 12){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], pos, Quaternion.identity); 
                redCnt++;
            } 
            else if (redCnt > 12){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], pos, Quaternion.identity); 
                blueCnt++;
            }
        }
        
        if (randomNumber == 2 && redCnt < 12){
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], pos, Quaternion.identity); 
            redCnt++;
        } 
        else if (redCnt > 12){ 
            if (greenCnt < 12){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], pos, Quaternion.identity); 
                greenCnt++;
            } 
            else if (greenCnt > 12){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], pos, Quaternion.identity); 
                blueCnt++;
            }
        }
    }

    
    
    void Update()
    {
        
    }
}
