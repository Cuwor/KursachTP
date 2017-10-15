namespace Kursach
{
    internal class Architect
    {
        private string _name;

        protected string Name
        {
            get => _name;
            set
            {
                if (Name != "")
                    _name = value;
            }
        }
    }
}