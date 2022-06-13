using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour{
    [SerializeField]private GameObject collectablesGameObject;
    [SerializeField]private GameObject [] collactables; //0-blue 1-green 2-red
    public int greenCnt = 0, redCnt = 0, blueCnt = 0;
    private int totalBrickAmountPerColor, totalPlayerAmount = 3;
    enum Colors{
        Blue,
        Green,
        Red
    }
    
    void Start(){
        totalBrickAmountPerColor = (int)Mathf.Ceil(collectablesGameObject.transform.childCount/ totalPlayerAmount);
        CreateRandomBricks();
        Debug.Log(totalBrickAmountPerColor);
    }

    public void CreateRandomBricks(){
        for (int i = 0; i < collectablesGameObject.transform.childCount; i++){
            CreateSameAmountOfRandomBricks(i);
        }
    }
public void CreateSameAmountOfRandomBricks(int i){
        int randomNumber = Random.Range(0, 3);
        
        if (blueCnt < totalBrickAmountPerColor  && randomNumber == 0){
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity);
            blueCnt++;
        }
        else if (blueCnt > totalBrickAmountPerColor){
            if (redCnt < totalBrickAmountPerColor){
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity);
                redCnt++;
            } 
            else if (redCnt > totalBrickAmountPerColor){
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
                greenCnt++;
            }
        }
        
        if (greenCnt < totalBrickAmountPerColor && randomNumber == 1){ 
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
            greenCnt++;
        } 
        else if (greenCnt > totalBrickAmountPerColor){ 
            if (redCnt < totalBrickAmountPerColor){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
                redCnt++;
            } 
            else if (redCnt > totalBrickAmountPerColor){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
                blueCnt++;
            }
        }
        
        if (redCnt < totalBrickAmountPerColor && randomNumber == 2){
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
            redCnt++;
        } 
        else if (redCnt > totalBrickAmountPerColor){ 
            if (greenCnt < totalBrickAmountPerColor){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
                greenCnt++;
            } 
            else if (greenCnt > totalBrickAmountPerColor){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], collectablesGameObject.transform.GetChild(i).position, Quaternion.identity); 
                blueCnt++;
            }
        }
    }


public void CheckAndCreateDelayedBricks(Vector3 pos){
        int randomNumber = Random.Range(0, 3);

        if (blueCnt < totalBrickAmountPerColor && randomNumber == 0){
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], pos, Quaternion.identity);
            blueCnt++;
        }
        else if (blueCnt > totalBrickAmountPerColor){
            if (redCnt < totalBrickAmountPerColor){
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], pos, Quaternion.identity);
                redCnt++;
            } 
            else if (redCnt > totalBrickAmountPerColor){
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], pos, Quaternion.identity); 
                greenCnt++;
            }
        }
        
        if (greenCnt < totalBrickAmountPerColor && randomNumber == 1){ 
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], pos, Quaternion.identity); 
            greenCnt++;
        } 
        else if (greenCnt > totalBrickAmountPerColor){ 
            if (redCnt < totalBrickAmountPerColor){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], pos, Quaternion.identity); 
                redCnt++;
            } 
            else if (redCnt > totalBrickAmountPerColor){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], pos, Quaternion.identity); 
                blueCnt++;
            }
        }
        
        if (redCnt < totalBrickAmountPerColor && randomNumber == 2){
            GameObject currentBrick = Instantiate(collactables[(int)Colors.Red], pos, Quaternion.identity); 
            redCnt++;
        } 
        else if (redCnt > totalBrickAmountPerColor){ 
            if (greenCnt < totalBrickAmountPerColor){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Green], pos, Quaternion.identity); 
                greenCnt++;
            } 
            else if (greenCnt > totalBrickAmountPerColor){ 
                GameObject currentBrick = Instantiate(collactables[(int)Colors.Blue], pos, Quaternion.identity); 
                blueCnt++;
            }
        }
    }

    
    
    void Update()
    {
        
    }
}
