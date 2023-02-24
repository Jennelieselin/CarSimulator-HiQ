using System;

namespace CarSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask user for room size
            Console.WriteLine("Enter room size (in meters, separated by a space):");
            string[] sizeInput = Console.ReadLine().Split();
            int roomWidth = int.Parse(sizeInput[0]);
            int roomHeight = int.Parse(sizeInput[1]);

            // Ask user for starting position and heading
            Console.WriteLine("Enter starting position and heading (x y heading):");
            string[] positionInput = Console.ReadLine().Split();
            int posX = int.Parse(positionInput[0]);
            int posY = int.Parse(positionInput[1]);
            string heading = positionInput[2];

            // Ask user for commands
            Console.WriteLine("Enter commands (F = forward, B = back, L = left, R = right):");
            string commands = Console.ReadLine();

            // Perform simulation
            bool success = true;
            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'F':
                        if (heading == "N" && posY < roomHeight - 1)
                        {
                            posY++;
                        }
                        else if (heading == "W" && posX > 0)
                        {
                            posX--;
                        }
                        else
                        {
                            Console.WriteLine("Error: car hit a wall.");
                            success = false;
                        }
                        break;
                    case 'B':
                        if (heading == "N" && posY > 0)
                        {
                            posY--;
                        }
                        else if (heading == "S" && posY < roomHeight - 1)
                        {
                            posY++;
                        }
                        else if (heading == "E" && posX > 0)
                        {
                            posX--;
                        }
                        else if (heading == "W" && posX < roomWidth - 1)
                        {
                            posX++;
                        }
                        else
                        {
                            Console.WriteLine("Error: car hit a wall.");
                            success = false;
                        }
                        break;
                    case 'L':
                        switch (heading)
                        {
                            case "N":
                                heading = "W";
                                break;

                            case "S":
                                heading = "E";
                                break;
                            case "E":
                                heading = "N";
                                break;
                            case "W":
                                heading = "S";
                                break;
                        }
                        break;
                    case 'R':
                        switch (heading)
                        {
                            case "N":
                                heading = "E";
                                break;
                            case "S":
                                heading = "W";
                                break;
                            case "E":
                                heading = "S";
                                break;
                            case "W":
                                heading = "N";
                                break;
                        }
                        break;
                }

                if (!success)
                {
                    break;
                }
            }
            // Print result
            if (success)
            {
                Console.WriteLine($"End position: {posX} {posY} {heading}");
            }
        }
    }
}


