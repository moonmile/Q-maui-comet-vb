# .NET MAUI + Comet で、VB が動かない問題


- Clancey.Comet を使う

ビルド時に以下の targets ファイルがないとエラーになるので該当箇所に追加する

- Xamarin.MacCatalyst.VB.targets
- Xamarin.iOS.VB.targets


 C:\Program Files\dotnet\packs\Microsoft.iOS.Sdk\16.0.517\tools\msbuild\iOS
  Xamarin.iOS.VB.targets を追加

```xml
<Project DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
	<Import Project="$(MSBuildThisFileDirectory)$(MSBuildThisFileName).Before.targets"
			Condition="Exists('$(MSBuildThisFileDirectory)$(MSBuildThisFileName).Before.targets')"/>

	<PropertyGroup>
		<!-- Version/fx properties -->
		<TargetFrameworkIdentifier Condition="'$(TargetFrameworkIdentifier)' == ''">Xamarin.iOS</TargetFrameworkIdentifier>
		<TargetFrameworkVersion Condition="'$(TargetFrameworkVersion)' == ''">v1.0</TargetFrameworkVersion>

		<!-- Enable nuget package conflict resolution -->
		<!-- This must be set before importing Microsoft.CSharp.targets -->
		<ResolveAssemblyConflicts>true</ResolveAssemblyConflicts>
	</PropertyGroup>
	<Import Project="$(MSBuildBinPath)\Microsoft.CSharp.targets" Condition="'$(UsingAppleNETSdk)' != 'true'" />
	<Import Project="Xamarin.iOS.Common.targets" />

	<Import Project="$(MSBuildThisFileDirectory)$(MSBuildThisFileName).After.targets"
			Condition="Exists('$(MSBuildThisFileDirectory)$(MSBuildThisFileName).After.targets')"/>
</Project>
```

 C:\Program Files\dotnet\packs\Microsoft.MacCatalyst.Sdk\15.4.465\tools\msbuild\MacCatalyst\
  Xamarin.MacCatalyst.VB.targets を追加

```xml
<Project DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
	<Import Project="$(MSBuildThisFileDirectory)$(MSBuildThisFileName).Before.targets"
			Condition="Exists('$(MSBuildThisFileDirectory)$(MSBuildThisFileName).Before.targets')"/>

	<PropertyGroup>
		<!-- Version/fx properties -->
		<TargetFrameworkIdentifier Condition="'$(TargetFrameworkIdentifier)' == ''">Xamarin.MacCatalyst</TargetFrameworkIdentifier>
		<TargetFrameworkVersion Condition="'$(TargetFrameworkVersion)' == ''">v1.0</TargetFrameworkVersion>
	</PropertyGroup>

	<Import Project="$(MSBuildBinPath)\Microsoft.VB.targets" Condition="'$(UsingAppleNETSdk)' != 'true'" />

	<Import Project="Xamarin.MacCatalyst.Common.targets" />

	<Import Project="$(MSBuildThisFileDirectory)$(MSBuildThisFileName).After.targets"
			Condition="Exists('$(MSBuildThisFileDirectory)$(MSBuildThisFileName).After.targets')"/>
</Project>
```
 
## ビルド＆実行すると 

- Andorid でエラーがでる

```
**System.InvalidCastException:** 'Unable to convert instance of type 'Google.Android.Material.TextView.MaterialTextView' to type 'AndroidX.CoordinatorLayout.Widget.CoordinatorLayout'.'
```

- iOS では通常通り動く


