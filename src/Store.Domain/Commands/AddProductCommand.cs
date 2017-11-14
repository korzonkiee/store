namespace Store.Domain.Commands
{
    public class AddProductCommand : Command
    {
        public string Name { get; set; }

        public AddProductCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}