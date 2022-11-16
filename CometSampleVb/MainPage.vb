Imports System.Runtime.CompilerServices
Imports Comet
Imports Comet.Layout
Imports Microsoft.Maui


''' <summary>
''' VBの場合、プロパティ名とメソッド名を同じにできないので、拡張メソッドを再定義する
''' </summary>
Module CometVb
	<Extension>
	Public Function SetFrame(Of T As View)(view As T, Optional width As Single? = Nothing, Optional height As Single? = Nothing) As T
		view.FrameConstraints(New FrameConstraints(width, height))
		Return view
	End Function
	<Extension>
	Public Function SetMargin(Of T As View)(view As T, value As Single)
		view.Margin(New Thickness(value))
		Return view
	End Function
	<Extension>
	Public Function SetColor(Of T As View)(view As T, color As Binding(Of Microsoft.Maui.Graphics.Color))
		view.SetEnvironment(EnvironmentKeys.Colors.Color, color, False)
		Return view
	End Function
End Module


Public Class MainPage
	Inherits View

	<State>
	Private ReadOnly comet As New CometRide()

	<Body>
	Private Function FuncBody() As View
		Return New VStack From {
			New Text(Function() $"({comet.Rides}) rides taken:{comet.CometTrain}").
				SetFrame(width:=300).
				LineBreakMode(Microsoft.Maui.LineBreakMode.CharacterWrap),
			New Button("Ride the Comet! ☄️",
					   Sub()
						   comet.Rides += 1
					   End Sub).
				SetFrame(height:=44).
				Margin(8).
				SetColor(Microsoft.Maui.Graphics.Colors.White)
			}
	End Function
	Public Class CometRide
		Inherits BindingObject

		Public Property Rides As Integer 
		Get
				return GetProperty(Of Integer)()
		End Get
		    Set(value As Integer)
				SetProperty(value)
		    End Set
		End Property
		Public ReadOnly Property CometTrain As String 
			Get
				return "☄️".Repeat(Rides)
			End Get
		End Property
	End Class
End Class
