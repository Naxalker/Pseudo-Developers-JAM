using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ScenesController : IInitializable
{
    private string ScenesDataPath = "Scenes";

    private Scene _scene;

    private List<SceneSO> _scenesData = new List<SceneSO>();

    public ScenesController(Scene scene)
    {
        _scene = scene;
    }

    public void Initialize()
    {
        LoadScenes();

        _scene.SetScene(GetSceneWithIndex(0));
    }

    public void SetScene(int id)
    {
        _scene.ClearScene();
        //_scene.SetScene(GetSceneWithIndex(id));
    }

    private SceneSO GetSceneWithIndex(int id)
    {
        if (id < 0)
            throw new ArgumentException("id должен быть больше 0");

        try
        {
            return _scenesData.First(scene => scene.Id == id);
        } catch (InvalidOperationException)
        {
            throw new ArgumentException($"ID {id} не найден");
        }
    }

    private void LoadScenes()
    {
        foreach(object obj in Resources.LoadAll(ScenesDataPath))
        {
            _scenesData.Add(obj as SceneSO);
        }
    }
}
