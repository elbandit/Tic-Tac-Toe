using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrox.BDD.Ui.Console.Presentation;
using TechTalk.SpecFlow;

namespace Wrox.BDD.Specs.UAT.StepHelpers
{
    public static class GameStorage
    {
        public static TicTacToeGamePresenter presenter
        {
            get { return ScenarioContext.Current["Presenter"] as TicTacToeGamePresenter; }
            set { ScenarioContext.Current["Presenter"] = value; }
        }

        public static FakeGameView game_view
        {
            get { return ScenarioContext.Current["View"] as FakeGameView; }
            set { ScenarioContext.Current["View"] = value; }
        }
    }
}
