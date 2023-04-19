using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

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

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }


    public TextCard()
    {
        InitializeComponent();



    }
}