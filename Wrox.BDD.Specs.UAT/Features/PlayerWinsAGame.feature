Feature: Win A Game
    In order to win a game of Tic-Tac-Toe
    As player 
    I must get 3 of my tokens in a row

Scenario: Diagonal Win
    Given that I have started a new game
	And the following moves are played:
      | player | row | column |
      | X | 1 | 1 |
      | O | 0 | 2 |
	  | X | 0 | 0 |
	  | O | 1 | 2 |   
    When a player types in the coordinates "2,2"
	Then I should see the following displayed:
    """
     X |   | O 
    -----------
       | X | O 
    -----------
       |   | X 
			
	X has won the game!

	 """    