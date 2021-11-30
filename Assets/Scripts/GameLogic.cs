using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    Vector2 characterPositionInPercent;

    Vector2 characterVelocityInPercent;

    const float CharacterSpeed = 0.25f;

    float HalfCharacterSpeed = Mathf.Sqrt(CharacterSpeed * CharacterSpeed + CharacterSpeed * CharacterSpeed / 2f);

    void Start()
    {
        NetworkedServerProcessing.SetGameLogic(this);
    }

    void Update()
    {
        characterPositionInPercent += (characterVelocityInPercent * Time.deltaTime);

        Debug.Log(" characterPositionInPercent : " + characterPositionInPercent);
    }

    public void UpdateDirectionalInput(int d, int ClinetID)
    {
        characterVelocityInPercent = Vector2.zero;

       if ( d ==  KeyBoardInputDirection.Upright)
       {
          characterVelocityInPercent.x = HalfCharacterSpeed;
           characterVelocityInPercent.y = HalfCharacterSpeed;
       }
       else if ( d == KeyBoardInputDirection.Upleft)
       {
          characterVelocityInPercent.x = -HalfCharacterSpeed;
          characterVelocityInPercent.y = HalfCharacterSpeed;
       }
       else if (d == KeyBoardInputDirection.DownRight)
       {
         characterVelocityInPercent.x = HalfCharacterSpeed;
         characterVelocityInPercent.y = -HalfCharacterSpeed;
       }
       else if ( d == KeyBoardInputDirection.Downleft)
       {
        characterVelocityInPercent.x = -HalfCharacterSpeed;
        characterVelocityInPercent.y = -HalfCharacterSpeed;
       }
       else if ( d == KeyBoardInputDirection.right)
       {
         characterVelocityInPercent.x = CharacterSpeed;
       }
       else if (d == KeyBoardInputDirection.left)
       {
         characterVelocityInPercent.x = -CharacterSpeed;
       }
       else if (d == KeyBoardInputDirection.Up)
       {
         characterVelocityInPercent.y = CharacterSpeed;
       }
       else if (d == KeyBoardInputDirection.Down)
       {
         characterVelocityInPercent.y = -CharacterSpeed;
       }
       else if (d == KeyBoardInputDirection.Nothing)
       {
           
       }

        NetworkedServerProcessing.SendMessageToClientWithSimulatedLatency(ServerToClientSignifiers.VelocityAndPosition
            + "," + characterVelocityInPercent.x +
            "," + characterVelocityInPercent.y + ","
            + characterPositionInPercent.x 
            + "," + characterPositionInPercent.y , ClinetID);

    }
}