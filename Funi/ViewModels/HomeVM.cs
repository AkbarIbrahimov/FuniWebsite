using Funi.Models;

namespace Funi.ViewModels
{
    public class HomeVM
    {
        public HomeHero? homeHero { get; set; }
        public List<Category>? category { get; set; }
        public ChooseUs? chooseUs { get; set; }
        public List<ChooseService>? chooseServices { get; set; }
        public Design? design { get; set; }
    }
}
