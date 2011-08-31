Feature: Drawing A Game
    In order for a game to end with no winner
    As a player 
    I must place all my tokens 

Scenario: Use all tokens
    Given that I have started a new game    
	And the following moves are played:
      | player	| row	| column	|
      | X		| 1		| 1			|
      | O		| 0		| 2			|
	  | X		| 1		| 2			|
	  | O		| 1		| 0			|
	  | X		| 0		| 0			|
	  | O		| 2		| 2			|
	  | X		| 0		| 1			|
	  | O		| 2		| 1			|	  
    When a player types in the coordinates "2,0"
    Then I should see the following displayed:
    """	
     X | X | O 
    -----------
     O | X | X 
    -----------
     X | O | O 

	The game has ended in a draw!

	"""    
