



class Program
{
    public static readonly List<Command> CommandHistory = new();

    /// <summary>
    /// Main method, program entry point
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        var input = Console.ReadLine()?.ToLower();

        if (input == "savetheworld")
        {
            new SaveTheWorldCommand();
        }
        else if (input == "nukerussia")
        {
            new NukeRussiaCommand();
        }
        else {
            new NotifyUnknownCommandCommand();
        }
    }

    /// <summary>
    /// Command base class
    /// </summary>
    public abstract class Command
    {
        public Command()
        {
            CommandHistory.Add(this);
            Handle();
        }
        
        // Commands will implement this
        public virtual void Handle() {}
        
        /// <summary>
        /// Undo the command, removing it from the command history
        /// </summary>
        public void Undo()
        {
            if (CommandHistory.Any(cmd => cmd == this))
            {
                CommandHistory.Remove(this);
            }
        }
    }

    /// <summary>
    /// Command to save world
    /// </summary>
    public class SaveTheWorldCommand : Command
    {
        public override void Handle()
        {
            base.Handle();
            Console.WriteLine("I am now saving the world from evil.");
        }
    }
    /// <summary>
    /// Command to nuke russia.
    /// </summary>
    public class NukeRussiaCommand : Command
    {
        public override void Handle()
        {
            base.Handle();
            Console.WriteLine("Sending nukes to Russia.");
        }
    }

    public class NotifyUnknownCommandCommand : Command
    {
        public override void Handle()
        {
            base.Handle();
            Console.WriteLine("Do you need some help? Poor guy... So like, the only two commands are: 'savetheworld' and 'nukerussia' - you'll have to run the program again tho because this is a really user friendly application");
        }
    }
}
