namespace Maui_iOS_Image_Issue {
  public partial class MainPage : ContentPage {
    int count = 0;

    public MainPage() {
      InitializeComponent();
      //ToolbarItems.Add( new ToolbarItem( "TEST", "loading.svg", () => { }, ToolbarItemOrder.Primary ) ); // This works
      ToolbarItems.Add( new ToolbarItem { IconImageSource = ImageSource.FromFile( "loading.svg" ) });
    }
  }
}
