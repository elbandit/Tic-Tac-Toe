using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Wrox.BDD.Specs.UAT.StepHelpers;
using NUnit.Framework;

namespace Wrox.BDD.Specs.UAT.Steps
{
    [Binding]
    public class GamePlaySteps
    {
        [Given(@"that I have started a new game")]
        public void GivenThatIHaveStartedANewGame()
        {
            var fake_game_view = new FakeGameView();

            GameStorage.game_view = fake_game_view;

        }

        [Then(@"I should see the following displayed:")]
        public void ThenIShouldSeeTheFollowingDisplayed(string multilineText)
        {
            var view = GameStorage.game_view;

            Assert.That(view.display(), Is.EqualTo(multilineText));   
        }

        [Given(@"I have read the introduction message")]
        public void GivenIHaveReadTheIntroductionMessage()
        {
            var view = GameStorage.game_view;
            view.clean_display();

        }

        [When(@"a player types in the coordinates ""(.*)""")]
        public void WhenAPlayerTypesInTheCoordinates(string coordinates)
        {
            var game_presenter = GameStorage.presenter;
            game_presenter.update_game_with_move(coordinates);
        }

        [Given(@"the following moves are played:")]
        public void GivenTheFollowingMovesArePlayed(Table table)
        {
            foreach (var row in table.Rows)
            {
                GameStorage.presenter.update_game_with_move(
                   string.Format("{0},{1}", row["row"], row["column"]));
            }

            GameStorage.game_view.clean_display();
        }

    }
}
