namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GitHub gitHub = new GitHub();
            gitHub.Account = new Account("Maxim","126712super");
            gitHub.GetProgram();
        }
        
    }
}
