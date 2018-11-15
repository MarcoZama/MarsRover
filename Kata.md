Kata develop in c# with netcore and Nunit 3


I assume that the planet is a cartesian graph like this.
It has max length pointed to 10
The initial point of rover is 0,0 and its facing to N
I implement the api for receive the string commands. String is a array of char. 
After this, i use a foreach for scan the string array of command.
I make some switch case for type of command. I have to detect also where the rover is facind after the move and after the turn.
I don't like the return object but i think that is more easy for the complexity of project. But its my idea.
I make Test with various complexity for instance with single command and multiple. 
I'm not sure to have understand correctly the obstacles concept.
Maybe it could be implemented as a randomically object in the graph. :(
