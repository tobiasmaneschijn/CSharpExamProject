using System.Net.Mime;

namespace MyRecipesApp.Controls;

public partial class TextCard : ContentView
{
    // Text property
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(MediaTypeNames.Text),
        typeof(string),
        typeof(TextCard),
        string.Empty,
        BindingMode.TwoWay,
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var control = (TextCard)bindable;
            control.LabelText.Text = newvalue as string;
        });


    public TextCard()
    {
        InitializeComponent();
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}