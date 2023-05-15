namespace MyRecipesApp.Logic;

public static class ShellExtensions
{
    public static readonly BindableProperty BindingContextProperty =
        BindableProperty.CreateAttached("BindingContext", typeof(object), typeof(ShellExtensions), null);

    public static object GetBindingContext(BindableObject view)
    {
        return view.GetValue(BindingContextProperty);
    }

    public static void SetBindingContext(BindableObject view, object value)
    {
        view.SetValue(BindingContextProperty, value);
    }

    public static void OnBindingContextChanged(BindableObject view, object oldValue, object newValue)
    {
        if (view is Shell shell && newValue != null)
            foreach (var content in shell.CurrentItem.Items)
                SetBindingContext(content, newValue);
    }
}