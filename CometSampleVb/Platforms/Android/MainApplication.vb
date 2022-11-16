Imports Android.App
Imports Android.Runtime
Imports Microsoft.Maui
Imports Microsoft.Maui.Hosting

<Application>
Public Class MainApplication
	Inherits Microsoft.Maui.MauiApplication

	Public Sub New(handle As IntPtr, ownership As JniHandleOwnership)
		MyBase.New(handle, ownership)
	End Sub

	Protected Overrides Function CreateMauiApp() As MauiApp
		Return App.CreateMauiApp()
	End Function
End Class
