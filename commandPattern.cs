using System;
using System.Collections.Generic;

public interface ICommand
{
 void Execute();
}


//invoker class
public class Switch
{
 private List<ICommand> _commands = new List<ICommand>();

 public void StoreAndExecute(ICommand command)
 {
 _commands.Add(command);
 command.Execute();
 }
}

//reciever class
public class Light
{
 public void TurnOn()
 {
 Console.WriteLine("The light is on");
 }

 public void TurnOff()
 {
 Console.WriteLine("The light is off");
 }
}

//to turn on the light 
public class FlipUpCommand : ICommand
{ 
    //light us reciever class
 private Light _light;

 public FlipUpCommand(Light light)
 {
 _light = light;
 }

 public void Execute()
 {
 _light.TurnOn();
 }
}

//command to turn of the light
public class FlipDownCommand : ICommand
{
 private Light _light;

 public FlipDownCommand(Light light)
 {
 _light = light;
 }

 public void Execute()
 {
 _light.TurnOff();
 }
}

//command pattern
class Program
{
 static void Main(string[] args)
 {
 Console.WriteLine("Enter Commands (ON/OFF) : ");
 string cmd = Console.ReadLine();

 Light lamp = new Light();
 ICommand switchUp = new FlipUpCommand(lamp);
 ICommand switchDown = new FlipDownCommand(lamp);
//client
 Switch s = new Switch();

 if (cmd == "ON")
 {
 s.StoreAndExecute(switchUp);
 }
 else if (cmd == "OFF")
 {
 s.StoreAndExecute(switchDown);
 }
 else
 {
 Console.WriteLine("Command \"ON\" or \"OFF\" is required.");
 }

 Console.ReadKey();
 }
}