namespace Supermarket.Resources
{
    public class ErrorResource
    {
        public bool Success => false;
        public List<string> Messages { get; private set; }

        public ErrorResource(List<string> messages)
        {
            Messages = messages;
        }

        public ErrorResource(string message)
        {
            Messages.Add(message);

            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Messages.Add(message);
            }
        }
    }
}
