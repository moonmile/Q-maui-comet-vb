Imports Microsoft.Maui.Hosting
Imports Microsoft.UI.Xaml

Namespace CometSampleVb.WinUI
	Partial Public Class App
		Inherits Microsoft.Maui.MauiWinUIApplication
		Public Sub New()
			' InitializeComponent()
		End Sub

		Protected Overrides Function CreateMauiApp() As MauiApp
			Return Global.CometSampleVb.App.CreateMauiApp()
		End Function
	End Class
End Namespace

