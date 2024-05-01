using UnityEngine;
using Zenject;

public class BootInstaller : MonoInstaller
{
        [SerializeField] private GameStateMachine _stateMachine;
        [SerializeField] private SoundSystem _soundSystem;
        public override void InstallBindings()
        {
            Container.Bind<IPersistentData>().To<PersistentData>().FromNew().AsSingle();
            Container.Bind<DataLocalProvider>().FromNew().AsSingle();

            Container.Bind<InitializeGame>().FromNew().AsSingle();
            Container.Bind<LoadLevel>().FromNew().AsSingle();      
            Container.Bind<GameStateFactory>().FromNew().AsSingle();
            Container.Bind<GameStateMachine>().FromInstance(_stateMachine).AsSingle();


            Container.BindInterfacesAndSelfTo<WalletRepository>().AsSingle();
            Container.Bind<SoundSystem>().FromInstance(_soundSystem).AsSingle();
            Container.Bind<InputPlayer>().AsSingle();
        }
}


