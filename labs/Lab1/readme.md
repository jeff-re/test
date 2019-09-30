# Maze (ITSE 1430)
## Version 1.2

In this lab you will create a simple text maze. The maze will consist of a set of rooms that the user can navigate to. The user will use simple text commands to navigate. The goal of the maze is to find the exit. When the user finds the exit they win.

[Skills Needed](#skills-needed)

[Getting Started](#getting-started)

[Story 1](#story-1)

[Story 2](#story-2)

[Story 3](#story-3)

[Story 4](#story-4)

[Story 5](#story-5)

[Story 6](#story-6)

[Story 7](#story-7)

[General Hints](#general-hints)

[Requirements](#requirements)

## Skills Needed

This lab requires no additional knowledge beyond what you learned in 1401. While you are free to use more advanced concepts that you might know from other languages, care should be taken that you do not overcomplicate this problem. There is nothing fancy needed here. Prefer simple over complex. You get no extra credit for complex solutions and you must still meet the requirements of the lab.

- General
   - Setting up a solution and project
   - Naming conventions
   - Code styling including indentation and commenting
- C#
   - Variables and scope management   
   - Proper use of types
   - Defining and calling functions including appropriate use of parameters and return values
   - Control flow statements such as `if` and `while`

## Getting Started

As this is the first lab some general guidance is in order.

- Do not fight the editor when it comes to styling and errors. The editor is following the default styling for C#. If you do not follow this styling then your code will get mangled (e.g. improperly indented, wrong suggestions being provivded). If the indentation and/or suggestions are wrong then this is generally an indication you are either doing something wrong or you have a error earlier in your code. Fix this before moving on.
- After you have implemented a block of code, such as a function, it is generally a good idea to compile your code to resolve any issues before moving on. Waiting until the end will generally result in wasted time and effort and make it a lot harder to resolve errors as you have to go through more code.
- Files are saved automatically when you compile or debug your code.
- After you have gotten a story working it is a good idea to go ahead and commit and push your changes to Github. This will allow you to revert back should you make mistakes later on.
- If your code is hopelessly broken then you can always revert back to the last set of committed changes in Github by using `Team Explorer \ Changes` and selecting undo. To undo a single file right click the file and select `Undo`. Note that after undoing changes you will still see files you have added. Added files have to be deleted from `Team Explorer`.
- Do not overthink a problem. Create the simplest, correct solution to the problem you can come up with. You get no bonus points for complex, ingenious solutions.
- If you are unsure how to solve a problem then use a whiteboard or paper to logically think through the problem. Check your solution mentally before trying to implement it in code.

To simplify discussion of the labs they are broken into stories. A story is a feature to add to the program. Each story is generally stand alone but they are listed in the order in which you should implement them. Later stories may rely on functionality you add in earlier stories. Stories have acceptance criteria that identify the requirements that should be met for a story. Note that you should ensure a story behaves correctly as the acceptance criteria is only the list of general requirements for the story.

## Story 1 

Create an application to host the program.

*Note: Since this is the first lab the steps for creating a project are given in details. Subsequent labs will skip this.*

- Create a `Console Application (.NET Core)` project. Before creating the project make the following changes.
  - .NET code follows the convention of `{company}.{product}` for projects so call this project `Itse1430.Maze`.
  - Change the solution name to `Lab1`.
  - Create the project.
- When the application starts show basic application information including the application name, your name and class.
- Ensure your file(s) have header information.
- Ensure your code compiles cleanly.

*Note: Early on, if you incorrectly name a solution or project it is generally easier to simply start over than to try to correct it. Simply renaming files is not sufficient.*

### Acceptance Criteria

- Solution and project are created properly.
- Code compiles and runs without errors.

## Story 2

Define the rooms.

The maze consists of a series of 10-20 rooms on a single level (do not implement multi-level mazes). To help define the maze draw the layout that you want on paper first. Define each of the rooms in your maze (including hallways, if any) with a name and the room(s) it connects to. Using paper will help ensure you don't overlap rooms. Each room should have at least one other room connecting to it. Do not create a simple linear maze, at least half the rooms should have multiple exits. Identify the room that the player will start in and the room with the exit.

Each room should be a separate function that handles the logic of that room (e.g. movement, looking, etc). Each room will have a description.

*Note: For this lab you can use any environment you want. You might use a dungeon as your maze or a spaceship or some woods. It is completely up to you.*

### Acceptance Criteria

- All the rooms can be visited.
- None of the rooms overlap with other rooms.
- Navigating between two rooms and back returns the player to the original room.

## Story 3

Implement the starting room.

When the game first begins display a brief summary of why the player is here and the description for the starting room.

### Acceptance Criteria

- Player sees a description of the starting room.

## Story 4 

Implement a command parser.

The player will navigate by typing in commands such as `move`, `look` or `turn around`. Implement a command parser function to handle this.

The command parser should read the entire [line](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8) entered by the player. If the command is valid then it is returned to the caller otherwise an error is displayed and the player is prompted again. The parser follows these rules.

- Case does not matter.
- If an unknown command is entered an error is displayed and the parser prompts again until the player enters a valid command.
- Empty commands (e.g. empty lines) are ignored.
- Valid commands should return a "command code" to the caller so the caller can handle the command.

The first command will be `quit`. When entered the player is prompted for confirmation and, if confirmed, the program terminates. Otherwise the command is ignored.

### Implementation Notes

You can use strings or integrals to define the "commands" of your program. [Enumerations](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/enumeration-types) are generally the best option here but we will not cover them in class. They work just like other languages so you may use them if you like. It would simplify your code and make it more readable.

```csharp
enum Command
{
   Quit = 1,
   MoveForward,
   MoveBackward
}

//They work just like types
static Command GetCommand ()
{
   ...
   return Command.Quit;
}
```

### Parser Implementation

To implement the parser you will need several functions. The following is one such approach that you might use.

The first function you'll need is a parser to convert strings to commands. This is where you will handle spacing and casing rules.

```csharp
static Command ParseCommand ( string input )
{   
}
```

This function is just responsible for figuring out what command the user entered. It is possible that the user entered an invalid command so this function should have some way of conveying that back to the caller.

The next function that will be needed is the function that handles user input and command validation. This function will get the input from the user, call the parsing function to convert it to a command then determine if the command is valid. If it isn't then the function should report the error to the user and prompt again.

```csharp
static Command GetCommand ()
{   
   //Get input from user
   Command command = ParseCommand(input);
   //If valid then return the command otherwise display error and keep prompting
}
```

The last function you will likely need is the function to handle the commands. Some commands can be handled directly by the handler (e.g. `turn`) but most will need to be returned to the room so it can implement the room-specific logic (e.g. `move`). In any case it will rely on the earlier function to get the next command to process.

```csharp
static Command HandleCommand ()
{
   Command command = GetCommand();
   //Handle generic commands like quit and turn

   //Pass the rest back to the room to handle
   return command;
}
```

### Acceptance Criteria

- Invalid commands display an error and player is prompted again.
- Quit displays a confirmation and, if confirmed, the program terminates.
- Empty lines are ignored.
- Case is ignored.

## Story 5

Implement the exit logic for the game.

When the player enters the exit room they get a congratulatory message. The player has won and the program can termine.

Since the user will exit the game when they get to the room it must be a leaf room. There will be no option for the player to continue through the room.

### Acceptance Criteria

- If the room is the exit room then a congratulatory message is shown and the program terminates.

## Story 6

Implement the `move` commands to allow moving between rooms.

This command requires an argument to specify which way to move. 

- `move forward` moves the player one room forward, if any.
- `move backward` moves the player one room back, if any.
- `move left` moves the player one room to the left, if any.
- `move right` moves the player one room to the right, if any.

When the player enters a room display the room's description including any exit doors.

If there is no room in the given direction then the player should get an error as normal.

### Acceptance Criteria

- The room's description is shown when the user enters the room.
- Player can navigate between rooms using all the commands defined in the story.
- If a player tries to use a command that is not appropriate for the current room then a message is shown and the room description is shown again.

## Story 7

Implement the `turn` commands to allow the user to change directions.

- `turn left` turns the player to the left.
- `turn right` turns the playre to the right.
- `turn around` turns the player around.

Players can change the direction (`North`, `Sout`, `East`, `West`) they are facing as they navigate the maze. Track the current direction the player is facing. 

Whenever information is shown to the player such as the room's description also display the current direction they are facing.

Adjust the move commands to take direction into account. For example if the player moves forward, turns left and then moves forward they are now moving to the room to the left of the current room.

When a player enters a new room they should remain facing the same direction they were before (e.g. West if they had turned to the left).

*Note: There are different ways to implement movement with direction commands. Probably the easiest approach is to define all room relationships in terms of direction (e.g. room A is West of room B). When implementing the move command translate the relative direction (`forward`, `backward`) into direction. For example if the player is currently facing `West` and they enter `move forward` then that translates to the current direction of `West`. If they enter `move left` then that translates to `South`.*

### Implementation Notes

The following is one possible approach to solving this problem. Here are the possible combinations of movement when facing each direction.

| Direction | Move | Room |
| - | - | - |
| North | Forward | North |
| North | Right | East |
| North | Around | South |
| North | Left | West |
| East | Forward | East |
| East | Right | South |
| East | Around | West |
| East | Left | North |
| South | Forward | South |
| South | Right | West |
| South | Around | North |
| South | Left | East |
| West | Forward | West |
| West | Right | North |
| West | Around | East |
| West | Left | South |

While you could implement this as a series of `if-else` or `switch` statements there is an easier approach. Imagine that we assign a numeric value to each direction (North = 0, East = 1, South = 2, West = 3). Movement can now be defined in terms of offset from the current direction: (Left = -1, Forward = 0, Right = 1, Around = 2). As an example if the user is facing `East` (1) and they turn `Right` (1) they are going to room `South` (2). There are two boundary cases to handle.

The first boundary case is moving `Right` from `West` would increment the value to `3 + 1 = 4` which is outside the valid range. Using modulus 4 we can ensure the value is always between 0 and 3. In this boundary case `4 % 4 = 0` which correctly indicates `North` (0).

The second boundary case is when moving 'Left' from 'North'. In this case the value wouuld be negative `0 + -1 = -1`. Modulus doesn't work here but we can rely on a property of modulus. If we add `4` to the value before modulus then it would always restrict the value to between `0` and `7`. Then when we modulus we are back to our `0` to `3` value. In this particular boundary case we would end up with `0 + -1 + 4 = 3` which is `West`. 

In summary the following algorithm should return the proper room based upon the previous discussion.

```csharp
return (direction + offset + 4) % 4;
```

Of course this should be wrapped in a function to make it easy to adjust later, if needed. Also the use of enumerations would be very helpful here as well. To convert an enumeration to an integral (for calculation purposes) use a C-style cast.

```csharp
(int)direction;
```

### Acceptance Criteria

- Players see the direction they are facing when they enter a room.
- Players can change direction and see the new direction.
- Entering a new room does not change the direction.
- Moving between rooms properly takes the current direction into account.

## General Hints

### Variables

- USE nouns for variable names. 
- USE singular or plural when representing singular or multiple values, respectively.
- USE the most appropriate type for each variable.
	- `bool` stores true or false values. Do not use integrals for this.
	- `decimal` stores monetary values.
	- `double` stores floating point values.
	- `int` stores integral values.
	- `string` stores textual values.

For now make any variables that are needed across functions global.

```csharp
class Program
{
    private static bool isDelievery;
}
```

### Console

[Console.WriteLine](https://docs.microsoft.com/en-us/dotnet/api/system.console.writeline) can be used to write a line of text with a newline.

[Console.ReadLine](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline) can be used to read an entire line input.

[Console.ReadKey](https://docs.microsoft.com/en-us/dotnet/api/system.console.readkey) can be used to read a single key and, optional, not display it to the user. When using this method note that you have to use the [Key](https://docs.microsoft.com/en-us/dotnet/api/system.consolekeyinfo.key) property of the return value to get the actual key pressed.

Output can be colored for emphasis using the [Console.ForegroundColor](https://docs.microsoft.com/en-us/dotnet/api/system.console.foregroundcolor) and [Console.BackgroundColor](https://docs.microsoft.com/en-us/dotnet/api/system.console.backgroundcolor) values. If changing the color then be sure to reset the colors using [Console.ResetColor](https://docs.microsoft.com/en-us/dotnet/api/system.console.resetcolor).

### Debugging

- ALWAYS use `Start with Debugging (`F5`) to debug your code. Do not run without the debugger.
- NEVER select the option when compiling your code to ignore compiler errors. You will be debugging the wrong code.
- USE breakpoints (`F9`) to have the debugger pause on the line(s) you want to check for logic/runtime errors. You can have any number of breakpoints in your code.
- USE stepping (`F10` or `F11`) to step through your code line by line after hitting a breakpoint to verify it is behaving correctly. Know what should happen before you step so you can confirm the actual behavior.
- USE the `Autos` or `Locals` window to check the values of variables as you step through code.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the lab folder in your Github repository.