Imports Foundation
Imports Microsoft.Maui.Hosting

<Register("AppDelegate")>
Public Class AppDelegate
	Inherits Microsoft.Maui.MauiUIApplicationDelegate

	Protected Overrides Function CreateMauiApp() As MauiApp
		Return App.CreateMauiApp()
	End Function
End Class
