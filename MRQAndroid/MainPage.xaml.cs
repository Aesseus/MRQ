using Microsoft.Maui.Controls;
using MRQAndroid.Controls;
// ... other necessary using directives

namespace MRQAndroid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Assuming you have a method to create and return a list of CircleGraphSection
            circleGraph.Sections = GetChartData();
        }

        private List<CircleGraphSection> GetChartData()
        {
            // Populate the list with your data
            return new List<CircleGraphSection>
            {
                new CircleGraphSection { Name= "Gas", Value = 20, Color = Colors.Red },
                new CircleGraphSection { Name= "Flights", Value = 10, Color = Colors.Green },
                new CircleGraphSection { Name= "Shopping", Value = 15, Color = Colors.Blue },
                new CircleGraphSection { Name = "Power", Value = 10, Color = Colors.Yellow },
                new CircleGraphSection { Name = "Food", Value = 20, Color = Colors.Orange },
                new CircleGraphSection { Name = "Commute", Value = 25, Color = Colors.Purple }

                // ... your data here
            };
        }
    }
}





//using Microsoft.Maui.Controls;
//using MRQAndroid.Controls;

//public partial class MainPage : ContentPage
//{
//    public MainPage()    {

//        var circleGraph = new CircleGraph();
//        circleGraph.DataProvider = GetChartData;
//        Content = new StackLayout { Children = { circleGraph } };
//    }

//    public List<CircleGraphSection> GetChartData()
//    {
//        return new List<CircleGraphSection>
//    {
//        new CircleGraphSection { Name = "Section 1", Value = 25, Color = Colors.Red },
//        new CircleGraphSection { Name = "Section 2", Value = 25, Color = Colors.Green },
//        new CircleGraphSection { Name = "Section 3", Value = 25, Color = Colors.Blue },
//        new CircleGraphSection { Name = "Section 4", Value = 25, Color = Colors.Yellow },
//    };
//    }
//}