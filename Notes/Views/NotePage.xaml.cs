namespace Notes.Views;
using Notes.ViewModels;
    
public partial class NotePage : ContentPage
{
    public NotePage(NoteViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }
}