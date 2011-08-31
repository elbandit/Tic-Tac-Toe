Feature: Win A Game
    In order to win a game of Tic-Tac-Toe
    As player 
    I must get 3 of my tokens in a row

Scenario: Diagonal Win Left to Right Token X
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

Scenario: Diagonal Win Left to Right Token O
    Given that I have started a new game
	And the following moves are played:
      | player | row | column |
      | X | 0 | 2 |
      | O | 1 | 1 |
	  | X | 1 | 2 |	  
	  | O | 0 | 0 |
	  | X | 2 | 0 |   
    When a player types in the coordinates "2,2"
	Then I should see the following displayed:
    """
     O |   | X 
    -----------
       | O | X 
    -----------
     X |   | O 
			
	O has won the game!

	 """   

Scenario: Alternative Diagonal Win Right to Left Token X
    Given that I have started a new game
	And the following moves are played:
      | player | row | column |
      | X | 1 | 1 |
      | O | 1 | 2 |
	  | X | 0 | 2 |
	  | O | 2 | 2 |   
    When a player types in the coordinates "2,0"
	Then I should see the following displayed:
    """
       |   | X 
    -----------
       | X | O 
    -----------
     X |   | O 
			
	X has won the game!

	 """    

Scenario: Alternative Diagonal Win Right to Left Token O
    Given that I have started a new game
	And the following moves are played:
      | player | row | column |
      | X | 1 | 2 |
      | O | 1 | 1 |
	  | X | 2 | 2 |
	  | O | 0 | 2 |   
	  | X | 2 | 1 |  
    When a player types in the coordinates "2,0"
	Then I should see the following displayed:
    """
       |   | O 
    -----------
       | O | X 
    -----------
     O | X | X 
			
	O has won the game!

	 """ 
Scenario: Vertical Win
    Given that I have started a new game
	And the following moves are played:
      | player | row | column |
      | X | 1 | 1 |
      | O | 0 | 2 |
	  | X | 0 | 1 |
	  | O | 1 | 2 |   
    When a player types in the coordinates "2,1"
	Then I should see the following displayed:
    """
	X has won the game!

       | X | O 
    -----------
       | X | O 
    -----------
       | X |   
		

	 """  