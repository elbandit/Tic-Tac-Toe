Feature: Game Play
	In order to play a game of tic-tac-toe
	As a player 
	I want to know the state of play

Scenario: Starting a game    
	Given that I have started a new game
    Then I should see the following displayed:
      """
	=========================
    Lets Play Tic-Tac-Toe!!!!
    =========================
    When prompted please input the
    coordinates of your move in the
    format row,col e.g. 0,1 for the
	first row and the second column

	X, make your move.


      """

Scenario: Alternate Players
	Given that I have started a new game
	And I have read the introduction message
	When a player types in the coordinates "2,2"
    Then I should see the following displayed:
      """
         |   |   
      -----------
         |   |   
      -----------
         |   | X 
		 	 
	 O, make your move.


      """

Scenario: Displaying the game
	Given that I have started a new game
	And I have read the introduction message
    And the following moves are played:
      | player	| row	| column	|
      | X		| 1		| 1			|
	  | O		| 0		| 1			|	 
	When a player types in the coordinates "2,2"
    Then I should see the following displayed:
      """
         | O |   
      -----------
         | X |   
      -----------
         |   | X 
		 	 
	 O, make your move.


      """