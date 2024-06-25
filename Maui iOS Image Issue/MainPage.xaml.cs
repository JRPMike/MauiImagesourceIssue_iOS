using SkiaSharp.Extended.Svg;
using System.Diagnostics;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Maui_iOS_Image_Issue {
  public partial class MainPage : ContentPage {
    int count = 0;

    public MainPage() {
      InitializeComponent();
      //ToolbarItems.Add( new ToolbarItem( "TEST", "loading.svg", () => { }, ToolbarItemOrder.Primary ) ); // This works
      try {
        ToolbarItems.Add( new ToolbarItem { IconImageSource = ImageSource.FromFile( "loading.svg" ) } );
      }
      catch ( Exception e ) {
        Debug.Assert( false );
      }
      try {
        var test = LoadSvgIcon( "loading2.svg" );
      }
      catch ( Exception e ) {
        Debug.Assert( false );
      }
    }



    public SKSvg? LoadSvgIcon( string imageName ) {
      var assmebly = GetType().Assembly;
      var resourceNames = assmebly.GetManifestResourceNames();
      var resourceName = resourceNames.FirstOrDefault( r => r.EndsWith( imageName ) );
      //var resourceName = GetIconResourceID( assmebly, imageName );
      using ( Stream? stream = assmebly.GetManifestResourceStream( resourceName ) ) {
        if ( stream == null ) {
          return null;
        }
        SKSvg svg = new SKSvg();
        svg.Load( stream );
        return svg;
      }
    }
    private string GetIconResourceID( Assembly assembly, string imageName ) {
      return $"{assembly.GetName()}.Images.{imageName}";
    }

  }
}
