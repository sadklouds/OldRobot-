
Robot robot = new Robot();
for (int i = 0; i < robot.Commands.Length; i++)
{
    IRobotCommand? command;
    do
    {
        Console.Write("Enter a command (on , off, north, south, west, east): ");
        string? input = Console.ReadLine().ToLower();
         command = input switch
        {
            "on" => new OnCommand(),
            "off" => new OffCommand(),
            "north" => new NorthCommand(),
            "south" => new SouthCommand(),
            "west" => new WestCommand(),
            "east" => new EeastCommand(),
            _ => null
        };
    } while (command == null);

    robot.Commands[i] = command;
}
robot.Start();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public void Start()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y}] {IsPowered}");
        }
    }
}

public  interface IRobotCommand
{
     void Run(Robot robot);
} 

public class OnCommand : IRobotCommand 
{
   public void Run(Robot robot) { robot.IsPowered = true; }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) { robot.IsPowered = false; }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true) robot.Y += 1;
    }
}
public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true) robot.Y -= 1;
    }
}
public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true) robot.X -= 1;
    }
}
public class EeastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true) robot.X += 1;
    }
}