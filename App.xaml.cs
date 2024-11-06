using glasluisaS5.Utils;

namespace glasluisaS5
{
    public partial class App : Application
    {
        public static PersonRepository personRepo;
        public App(PersonRepository personRepository)
        {
            InitializeComponent();

            MainPage = new Views.Principal();
            personRepo = personRepository;
        }
    }
}