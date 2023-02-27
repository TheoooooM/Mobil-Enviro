using System.Collections;
using System.Collections.Generic;
using Archi.Service.Interface;
using UnityEngine;

public class CanvasUtilities : MonoBehaviour
{
    public IGameService m_Game;
    
    public void ChangeScene(int sceneIndex)
    {
        m_Game.ChangeScene((Enums.SceneType)sceneIndex);
    }
}
