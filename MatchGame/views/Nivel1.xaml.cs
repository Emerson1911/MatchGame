namespace MatchGame.views;

public partial class Nivel1 : ContentPage
{
	public Nivel1()
	{
		InitializeComponent();
        SetUpGame();
    }
    private TimeOnly time = new();
    private bool isRunning;
    private void SetUpGame()
    {
        List<string> animalEmoji = new List<string>()
        {
            "🐶","🐶",
            "🙈","🙈",
            "🦑","🦑",
            "🐘","🐘",
            "🦓","🦓",
            "🦘","🦘",
            "🐉","🐉",
            "🐬","🐬",
        };
        Random random = new Random();
        foreach (Button view in Grid1.Children)
        {

            int index = random.Next(animalEmoji.Count);
            string nextEmoji = animalEmoji[index];
            view.Text = nextEmoji;
            animalEmoji.RemoveAt(index);

        }
    }

    Button ultimoButtonClicked;
    bool encontradoMatch = false;

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (encontradoMatch == false)
        {
            button.IsVisible = false;
            ultimoButtonClicked = button;
            encontradoMatch = true;
        }
        else if (button.Text == ultimoButtonClicked.Text)
        {
            button.IsVisible = false;
            encontradoMatch = false;
        }
        else
        {
            ultimoButtonClicked.IsVisible = true;
            encontradoMatch = false;
        }
    }

    private async void OnStarStop(object sender, EventArgs e)
    {
        isRunning = !isRunning;
        startsStopButton.Source = isRunning ? "pause" : "play";

        while (isRunning)
        {
            time = time.Add(TimeSpan.FromSeconds(1));
            setTime();
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }

    private void OnReset(object sender, EventArgs e)
    {
        time = new TimeOnly();
        setTime();
    }



    private void setTime()
    {
        Timer.Text = $"{time.Minute}:{time.Second:000}";
    }

    private void btnReset_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Nivel1());
    }
}