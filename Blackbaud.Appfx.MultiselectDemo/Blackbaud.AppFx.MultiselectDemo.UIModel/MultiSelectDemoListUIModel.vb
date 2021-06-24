Public Class MultiSelectDemoListUIModel

    Private Sub MultiSelectDemoListUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        CheckBoxFilterHelper.MapField(Me, Me.TRANSACTIONTYPEFILTERMODE, Me.TRANSACTIONTYPECODES)
    End Sub

End Class