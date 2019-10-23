# Hangman

The / home page will have a button for one player or two player mode.

- One player mode
There will be a list of words written to the back end that the computer will randomly pick one. When the player clicks "Begin" the word will be picked and a /hangman route will be displayed.

- Two player mode
Two player mode will have a /Form page where one player types a word to a list. They click "Begin" and the /hangman route will be displayed. 

- Rules
It will contain a spot with underscores for as many characters are in the string. A space will not be an underscore, but just a space. And punctuation will remain punctuation. There should be a picture of a post with a rope. The route will contain a form and submit button that will redirectToAction /hangman route and will update based on the submitted guess. The model will check to see if the string contains the character. If so, that character will display in all the indeces it is in the string. else, the image will be updated to display a head. All guessed letters will display on this page as well and remain so the user knows what not to guess. If the user happens to guess a character already guessed, they will be prompted to reguess and no penalty will be given to them. Or maybe they should be penalized?