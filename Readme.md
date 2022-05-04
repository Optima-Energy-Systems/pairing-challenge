# Pairing Challenge

## Instructions

1. Install [Visual Studio 2022](https://visualstudio.microsoft.com/), and [git](https://git-scm.com/download/win) or [GitHub Desktop](https://desktop.github.com/) if required
    - Make sure to include ".Net 6.0 Runtime" from "Individual components"
    - The code will also run with Visual Studio Code 
2. Clone the repository with `git clone git@github.com:Optima-Energy-Systems/pairing-challenge.git` and create a new branch
3. Open `Robot Wars.sln`, build and run

## The spec

### Requirements

A fleet of hand built robots are due to engage in battle for the annual “Robot Wars” competition. Each robot will be placed within a rectangular battle arena and will navigate their way around the arena using a built in computer system.
 
A robot’s location and heading is represented by a combination of x and y co-ordinates and a letter representing one of the four cardinal compass points. The arena is divided up into a grid to simplify navigation. An example position might be 0, 0, N which means the robot is in the bottom left corner and facing North.
 
In order to control a robot, the competition organisers have provided a console for sending a simple string of letters to the on-board navigation system. The possible letters are ‘L’, ‘R’ and ‘M’. ‘L’ and ‘R’ make the robot spin 90 degrees to the left or right respectively without moving from its current spot while ‘M’ means move forward one grid point and maintain the same heading. Assume that the square directly North from (x, y) is (x, y+1).
 
### Input

The first line of input is the upper-right coordinates of the arena, the lower-left coordinates are assumed to be (0, 0).
 
The rest of the input is information pertaining to the robots that have been deployed. Each robot has two lines of input - the first gives the robot’s position and the second is a series of instructions telling the robot how to move within the arena.
 
The position is made up of two integers and a letter separated by spaces, corresponding to the x and y coordinates and the robot’s orientation. Each robot will finish moving sequentially, which means that the second robot won’t start to move until the first one has finished moving.
 
### Output

The output for each robot should be its final coordinates and heading.
 
### Test input

```
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
```
 
### Expected output

```
1 3 N
5 1 E
```

## The Tasks

1. Some unit tests are failing which points to a bug in the code.
    - Debug and figure out the cause of the issues
    - **Please note**: The unit tests are correct - The bug is within the application code
2. A new input command of 'U' needs to be implemented
    - This command will rotate the robot by 180 degrees without moving from its current spot
3. A new feature that will stop robots entering the same location in the arena.
    - If a robot tries to enter the same point as opponent it will be blocked from doing so
    - When a robot is blocked this need to be communicated to the user
