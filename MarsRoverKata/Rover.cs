using System;
using System.Collections.Generic;

namespace MarsRoverKata
{
    public class Rover
    {
        protected List<Obstacle> Obstacles;
        protected Position RoverPosition;

        public Rover(Position roverPosition, List<Obstacle> obstacles)
        {
            Obstacles = obstacles;
            RoverPosition = roverPosition;
        }
      
        /// <summary>
        /// Method that send string command to Rover
        /// </summary>
        /// <param name="commands">commands string</param>
        /// <returns>RoverPosition object</returns>
        public Position SendCommandToRover(string commands)
        {
            Position position = new Position();
            foreach(char command in commands) {                       
                position = ExecuteCommand(command);
            }
            return position;
        }

        /// <summary>
        /// this is the executor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private Position ExecuteCommand(char command) 
        {
            switch (command) 
            {
                case 'F':
                    return Movement.StepForward(RoverPosition, Obstacles);
                case 'B':
                    return Movement.StepBackward(RoverPosition, Obstacles);
                case 'L':
                    return Movement.Turn("L", RoverPosition);
                case 'R':
                    return Movement.Turn("R", RoverPosition);
                default:
                    throw new Exception("Sequence error!");

            }
        }


    }
}
