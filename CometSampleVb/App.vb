Imports Comet
Imports Microsoft.Maui.Hosting


Public Class App
		Inherits CometApp

	<Body>
	Private Function view() As View
		Return New MainPage()
	End Function


	Public Shared Function CreateMauiApp() As MauiApp
		Dim builder = MauiApp.CreateBuilder()
		builder.UseCometApp(Of App)().ConfigureFonts(
				Sub(fonts)
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold")
				End Sub)
		' -:cnd
#If DEBUG Then
		' builder.EnableHotReload()
#End If
		' +cnd
		Return builder.Build()
	End Function
End Class

