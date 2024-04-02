using Microsoft.Maui.Controls;
using MRQAndroid.Controls;

public partial class MainPage : ContentPage
{
    public MainPage()    {

        var circleGraph = new CircleGraph();
        circleGraph.DataProvider = GetChartData;
        Content = new StackLayout { Children = { circleGraph } };
    }

    public List<CircleGraphSection> GetChartData()
    {
        return new List<CircleGraphSection>
    {
        new CircleGraphSection { Name = "Section 1", Value = 25, Color = Colors.Red },
        new CircleGraphSection { Name = "Section 2", Value = 25, Color = Colors.Green },
        new CircleGraphSection { Name = "Section 3", Value = 25, Color = Colors.Blue },
        new CircleGraphSection { Name = "Section 4", Value = 25, Color = Colors.Yellow },
    };
    }
}