'Source code For KETIV's AVA on Inventor iLogic and Inventor API pro tips and tricks.  All rights
'reserved.Everything in this project/repo Is provided as-Is with no guarantees.  This Is provided for
'learning purposes only.  Copyright 2019 KETIV Technologies, Inc.  All Rights Reserved.

Public Class TestHarness

    Public Property invAppObj As Inventor.Application

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGetChildDoc.Click

        Dim activeDoc As Inventor.Document = invAppObj.ActiveDocument
        If activeDoc.DocumentType = Inventor.DocumentTypeEnum.kAssemblyDocumentObject Then

            For Each childOcc As Inventor.ComponentOccurrence In activeDoc.myCompDefn.ToAssyCompDefn.Occurrences
                Console.WriteLine(childOcc.myDocFileName)
            Next

        Else
            Console.WriteLine("This is a Part file with no children.")
        End If

    End Sub

    Private Sub btnDWGDims_Click(sender As Object, e As EventArgs) Handles btnDWGDims.Click
        Dim activeDoc As Inventor.Document = invAppObj.ActiveDocument

        If activeDoc.DocumentType = Inventor.DocumentTypeEnum.kDrawingDocumentObject Then

            Dim DWGDoc As Inventor.DrawingDocument = CType(activeDoc, Inventor.DrawingDocument)
            Dim oSheet As Inventor.Sheet = DWGDoc.Sheets.Item(1)
            Dim oView As Inventor.DrawingView = oSheet.DrawingViews.Item(1)

            'Find the edges I'm interested in
            Dim originCurves As List(Of Inventor.DrawingCurve) = oView.findCurvesByAttribute("DimSet", "Origin", "Y")
            Dim targetCurves As List(Of Inventor.DrawingCurve) = oView.findCurvesByAttribute("DimSet", "YFace", "Lower")

            For Each curve In originCurves
                curve.DebugFakeHighlight(0, 255, 0, 0.25)

            Next

            For Each curve In targetCurves
                curve.DebugFakeHighlight(0, 0, 255, 0.25)
            Next

            'Check to see if the target curves are at the same height...
            If targetCurves.First.StartPoint.Y.Round(5) = targetCurves.Last.StartPoint.Y.Round(5) Then
                MsgBox("Curves are at the same height")
            Else
                MsgBox("Curves are not at the same height.")
            End If


        End If
    End Sub



End Class