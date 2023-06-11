using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.AssetManagement
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private const string PlayerPathPrefab = "Infrastructure/Player";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string name)
        {
            _sceneLoader.Load(name, OnLoaded);
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        private void OnLoaded()
        {
            var playerInitailPoint = GameObject.FindObjectOfType<PlayerInitailPoint>();
            GameObject player = Instantiate(PlayerPathPrefab, playerInitailPoint.transform.position);
        }               

        private GameObject Instantiate(string path, Vector3 position)
        {
            var heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab, position, heroPrefab.transform.rotation);
        }

        private GameObject Instantiate(string path)
        {
            var heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab);
        }
    }
}