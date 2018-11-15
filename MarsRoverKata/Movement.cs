using System;
using System.Collections.Generic;

namespace MarsRoverKata
{
    public static class Movement
    {
        /// <summary>
        /// That's the length of planet
        /// </summary>
        public static int MaxPlanetLength => 10;

        /// <summary>
        /// Static step rover
        /// </summary>
        /// <param name="RoverPosition"></param>
        /// <returns></returns>
        public static Position StepForward(Position roverPosition, List<Obstacle> obstacles) 
        {
            switch (roverPosition.FacingDirection) 
            {
                case "N":
                    return SetForwardRoverPositionY(roverPosition, obstacles);
                case "S":
                    return SetForwardRoverPositionY(roverPosition, obstacles);
                case "W":
                    return SetForwardRoverPositionX(roverPosition,obstacles);
                case "E":
                    return SetForwardRoverPositionX(roverPosition, obstacles);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Static step backward
        /// </summary>
        /// <param name="roverPosition"></param>
        /// <returns></returns>    
        public static Position StepBackward(Position roverPosition, List<Obstacle> obstacles)
        {
            switch (roverPosition.FacingDirection)
            {
                case "N":
                    return SetBackwardRoverPositionY(roverPosition, obstacles);
                case "S":
                    return SetBackwardRoverPositionY(roverPosition, obstacles);
                case "W":
                    return SetBackwardRoverPositionX(roverPosition, obstacles);
                case "E":
                    return SetBackwardRoverPositionX(roverPosition, obstacles);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Static Turn rover
        /// </summary>
        /// <param name="turnCommand"></param>
        /// <param name="roverPosition"></param>
        /// <returns></returns>
        public static Position Turn(string turnCommand, Position roverPosition)
        {
            return FindRoverFacingByTurnCommand(turnCommand, roverPosition);
        }

        /// <summary>
        /// Help to understand where rover is facing by tunr command
        /// </summary>
        /// <param name="turnCommand">where it turns</param>
        /// <param name="roverPosition">actual rover position</param>
        /// <returns>new rover position</returns>
        private static Position FindRoverFacingByTurnCommand(string turnCommand, Position roverPosition)
        {
            switch (roverPosition.FacingDirection) 
            {
                case "N":
                    roverPosition.FacingDirection = turnCommand == "L" ? "W" : "E";
                    return roverPosition;
                case "S":
                    roverPosition.FacingDirection =  turnCommand == "L" ? "E" : "W";
                    return roverPosition;
                case "E":
                    roverPosition.FacingDirection =  turnCommand == "L" ? "N" : "S";     
                    return roverPosition;               
                case "W":
                    roverPosition.FacingDirection =  turnCommand == "L" ? "S" : "N";                
                    return roverPosition;
                

            }
            return null;
        }

        /// <summary>
        /// It returns the position after the step forward on axys Y by its facing property
        /// </summary>
        /// <param name="roverPosition"></param>
        /// <returns></returns>
        private static Position SetForwardRoverPositionY(Position roverPosition, List<Obstacle> obstacles)
        {
            var ipotheticX = roverPosition.StartingX;
            var ipotheticY = (roverPosition.StartingY + 1) > MaxPlanetLength ? 0 : roverPosition.StartingY + 1;
            if (AreThereObstacles(ipotheticX, ipotheticY, obstacles))
            {
                throw new Exception("Found an Obstacle!!!");
            }
            roverPosition.StartingX = ipotheticX;
            roverPosition.StartingY = ipotheticY;
            roverPosition.FacingDirection = roverPosition.FacingDirection;
            return roverPosition;
        }

        /// <summary>
        /// It returns the position after the step forward on axys X by its facing property
        /// </summary>
        /// <param name="roverPosition"></param>
        /// <returns></ns>
        private static Position SetForwardRoverPositionX(Position roverPosition, List<Obstacle> obstacles)
        {
            var ipotheticX = (roverPosition.StartingX + 1) > MaxPlanetLength ? 0 : roverPosition.StartingX + 1;
            var ipotheticY = roverPosition.StartingY;
            if (AreThereObstacles(ipotheticX, ipotheticY, obstacles))
            {
                throw new Exception("Found an Obstacle!!!");
            }
            roverPosition.StartingX = (roverPosition.StartingX + 1) > MaxPlanetLength ? 0 : roverPosition.StartingX + 1;
            roverPosition.StartingY = roverPosition.StartingY;
            roverPosition.FacingDirection = roverPosition.FacingDirection;


            return roverPosition;
        }

        /// <summary>
        /// It returns the position after the step backwward on axys X by its facing property
        /// </summary>
        /// <param name="roverPosition"></param>
        /// <returns></ns>
        private static Position SetBackwardRoverPositionY(Position roverPosition, List<Obstacle> obstacles)
        {
            var ipotheticX = roverPosition.StartingX;
            var ipotheticY =(roverPosition.StartingY - 1 < 0) ? MaxPlanetLength : roverPosition.StartingY - 1;
            if (AreThereObstacles(ipotheticX, ipotheticY, obstacles))
            {
                throw new Exception("Found an Obstacle!!!");
            }

            roverPosition.StartingX = ipotheticX;
            roverPosition.StartingY = ipotheticY;
            roverPosition.FacingDirection = roverPosition.FacingDirection;
            return roverPosition;
        }

        /// <summary>
        /// It returns the position after the step backwward on axys X by its facing property
        /// </summary>
        /// <param name="roverPosition"></param>
        /// <returns></ns>
        private static Position SetBackwardRoverPositionX(Position roverPosition, List<Obstacle> obstacles)
        {
            var ipotheticX = (roverPosition.StartingX - 1 < 0) ? MaxPlanetLength : roverPosition.StartingX - 1;
            var ipotheticY = roverPosition.StartingY;
            if (AreThereObstacles(ipotheticX, ipotheticY, obstacles))
            {
                throw new Exception("Found an Obstacle!!!");
            }

            roverPosition.StartingX = ipotheticX;
            roverPosition.StartingY = ipotheticY;
            roverPosition.FacingDirection = roverPosition.FacingDirection;
            return roverPosition;
        }

        /// <summary>
        /// Static method for check if there are obstacles
        /// </summary>
        /// <param name="positionX">X position</param>
        /// <param name="positionY">Y position</param>
        /// <param name="obstacles">list of all obstacles</param>
        /// <returns></returns>
        private static bool AreThereObstacles(int positionX, int positionY, List<Obstacle> obstacles)
        {
            foreach (var obstacle in obstacles)
            {
                if (positionX == obstacle.PositionX && positionY == obstacle.PositionY) 
                { 
                    return true;
                }
            }
            return false;
        }

    }
        
}
