Feature: Game Display
	In order to play the game
	As a player 
	I should be able to input moves and see
	the state of the game on the console screen

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

Scenario: Placing a token in an occupied square 
	Given that I have started a new game
	And I have read the introduction message
	And the following moves are played:
      | player	| row	| column	|
      | X		| 1		| 1			|
	When a player types in the coordinates "1,1"
    Then I should see the following displayed:
      """
	  There is already a token in the square at coordinate 1,1.

         |   |   
      -----------
         | X |   
      -----------
         |   |   
		 	 
	 O, make your move.


      """

Scenario: Placing a token in an invalid square 
	Given that I have started a new game
	And I have read the introduction message
	When a player types in the coordinates "100,100"
    Then I should see the following displayed:
      """
	  There is not a square at coordinate 100,100.

         |   |   
      -----------
         |   |   
      -----------
         |   |   
		 	 
	 X, make your move.


      """

Scenario: Inputting invalid data 
	Given that I have started a new game
	And I have read the introduction message
	When a player types in the coordinates "rrr,fff"
    Then I should see the following displayed:
      """
	  rrr,fff are invalid coordinates for a move, please use the format row,col.

         |   |   
      -----------
         |   |   
      -----------
         |   |   
		 	 
	 X, make your move.


      """