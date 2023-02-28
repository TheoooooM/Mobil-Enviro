using System.Collections;
using System.Collections.Generic;
using Archi.Service.Interface;
using Attributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasUtilities : MonoBehaviour
{
    public IGameService m_Game;
    public IToolService m_Tool;

    public void ChangeScene(int sceneIndex)
    {
        m_Game.ChangeScene((Enums.SceneType)sceneIndex);
    }

    public void LaunchTool()
    {
        SceneManager.LoadScene("Tool");
        m_Tool.ShowTool();
    }
    
    public void ChangePrefab(int index)
    {
        m_Tool.ChangePrefab(index);
    }
}
