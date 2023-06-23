using Furu.InGame.Domain.UseCase;
using Furu.InGame.Presentation.Controller;
using Furu.InGame.Presentation.Presenter;
using Furu.InGame.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Furu.InGame.Installer
{
    public sealed class InGameInstaller : LifetimeScope
    {
        [SerializeField] private RankingView rankingView = default;
        [SerializeField] private BottleView bottleView = default;
        [SerializeField] private CorkView corkView = default;
        [SerializeField] private TimeView timeView = default;
        [SerializeField] private TitleView titleView = default;
        [SerializeField] private UserRecordView userRecordView = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // UseCase
            builder.Register<RankingUseCase>(Lifetime.Scoped);
            builder.Register<StateUseCase>(Lifetime.Scoped);
            builder.Register<TimeUseCase>(Lifetime.Scoped);
            builder.Register<UserRecordUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<StateController>(Lifetime.Scoped);
            builder.Register<BurstState>(Lifetime.Scoped);
            builder.Register<FinishState>(Lifetime.Scoped);
            builder.Register<InputState>(Lifetime.Scoped);
            builder.Register<ResultState>(Lifetime.Scoped);
            builder.Register<SetUpState>(Lifetime.Scoped);
            builder.Register<TitleState>(Lifetime.Scoped);

            // Presenter
            builder.RegisterEntryPoint<StatePresenter>();
            builder.RegisterEntryPoint<TimePresenter>();

            // View
            builder.RegisterInstance<RankingView>(rankingView);
            builder.RegisterInstance<BottleView>(bottleView);
            builder.RegisterInstance<CorkView>(corkView);
            builder.RegisterInstance<TimeView>(timeView);
            builder.RegisterInstance<TitleView>(titleView);
            builder.RegisterInstance<UserRecordView>(userRecordView);
        }
    }
}