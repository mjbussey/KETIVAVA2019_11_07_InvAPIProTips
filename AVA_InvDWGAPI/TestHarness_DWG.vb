Imports Inventor

Public Class TestHarness_DWG
    Public Property invAppObj As Inventor.Application


    Private Sub TestHarness_DWG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnDimWedge_Click(sender As Object, e As EventArgs) Handles btnDimWedge.Click
        'Only get this if the document is a drawing document
        Dim activeDWG As DrawingDocument = If(invAppObj.ActiveDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject,
                                            CType(invAppObj.ActiveDocument, DrawingDocument), Nothing)
        If activeDWG IsNot Nothing Then
            Dim view1 As DrawingView = activeDWG.ActiveSheet.DrawingViews.Item(1)
            Dim sheet1 As Sheet = view1.Parent
            Dim OTG As TransientGeometry = CType(view1.Parent.Application, Application).TransientGeometry

            Dim circleCurve As DrawingCurve = view1.findCurvesByAttribute("KETIV", "WedgeDim", "CircularCurve").First
            circleCurve.DebugFakeHighlight

            Dim flatCurve As DrawingCurve = view1.findCurvesByAttribute("KETIV", "WedgeDim", "XZFlat").First
            flatCurve.DebugFakeHighlight

            Dim circIntent As GeometryIntent = view1.Parent.CreateGeometryIntent(circleCurve)

            'Dim circIntent As GeometryIntent = view1.Parent.CreateGeometryIntent(circleCurve, PointIntentEnum.kCircularBottomPointIntent)


            Dim flatIntent As GeometryIntent = view1.Parent.CreateGeometryIntent(flatCurve)

            Dim placementPoint As Inventor.Point2d = OTG.CreatePoint2d(view1.xMin - 2, view1.Position.Y)

            Dim wedgeDim As LinearGeneralDimension =
                sheet1.DrawingDimensions.GeneralDimensions.AddLinear(placementPoint, circIntent, flatIntent)

        End If

    End Sub

    Private Sub btnDimLinAngle_Click(sender As Object, e As EventArgs) Handles btnDimLinAngle.Click

        'Only get this if the document is a drawing document
        Dim activeDWG As DrawingDocument = If(invAppObj.ActiveDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject,
                                            CType(invAppObj.ActiveDocument, DrawingDocument), Nothing)
        If activeDWG IsNot Nothing Then
            Dim view1 As DrawingView = activeDWG.ActiveSheet.DrawingViews.Item(1)
            Dim sheet1 As Sheet = view1.Parent
            Dim OTG As TransientGeometry = CType(view1.Parent.Application, Application).TransientGeometry

            Dim topCurve As DrawingCurve = view1.findCurvesByAttribute("KETIV", "AngleLinearDim", "Top").First
            topCurve.DebugFakeHighlight

            Dim bottomCurve As DrawingCurve = view1.findCurvesByAttribute("KETIV", "AngleLinearDim", "Bottom").First
            bottomCurve.DebugFakeHighlight



            Dim topIntent As GeometryIntent = view1.Parent.CreateGeometryIntent(topCurve)
            Dim bottomIntent As GeometryIntent = view1.Parent.CreateGeometryIntent(bottomCurve)

            'Dim topIntent As GeometryIntent = view1.Parent.CreateGeometryIntent(topCurve, topCurve.YHighPoint)
            'Dim bottomIntent As GeometryIntent = view1.Parent.CreateGeometryIntent(bottomCurve, bottomCurve.YLowPoint)

            Dim placementPoint As Inventor.Point2d = OTG.CreatePoint2d(view1.xMax + 2, view1.Position.Y)

            Dim linAngleDim As LinearGeneralDimension =
                sheet1.DrawingDimensions.GeneralDimensions.AddLinear(placementPoint, topIntent, bottomIntent)

            'Dim linAngleDim As LinearGeneralDimension =
            '    sheet1.DrawingDimensions.GeneralDimensions.AddLinear(placementPoint, topIntent, bottomIntent, DimensionTypeEnum.kVerticalDimensionType)


        End If

    End Sub

    Private Sub btnDimParallelCrv_Click(sender As Object, e As EventArgs) Handles btnDimParallelCrv.Click

        'Only get this if the document is a drawing document
        Dim activeDWG As DrawingDocument = If(invAppObj.ActiveDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject,
                                            CType(invAppObj.ActiveDocument, DrawingDocument), Nothing)
        If activeDWG IsNot Nothing Then
            Dim view1 As DrawingView = activeDWG.ActiveSheet.DrawingViews.Item(1)
            Dim sheet1 As Sheet = view1.Parent
            Dim OTG As TransientGeometry = CType(view1.Parent.Application, Application).TransientGeometry

            Dim insideCurve As DrawingCurve = view1.findCurvesByAttribute("KETIV", "CutDim", "Inside").First
            insideCurve.DebugFakeHighlight

            Dim outsideCurve As DrawingCurve = view1.findCurvesByAttribute("KETIV", "CutDim", "Outside").First
            outsideCurve.DebugFakeHighlight

            Dim topIntent As GeometryIntent = view1.Parent.CreateGeometryIntent(insideCurve)
            Dim bottomIntent As GeometryIntent = view1.Parent.CreateGeometryIntent(outsideCurve)

            'Dim topIntent As GeometryIntent = view1.Parent.CreateGeometryIntent(insideCurve, insideCurve.YLowPoint)
            'Dim bottomIntent As GeometryIntent = view1.Parent.CreateGeometryIntent(outsideCurve, outsideCurve.YLowPoint)

            Dim placementPoint As Inventor.Point2d = OTG.CreatePoint2d(view1.xMin - 2, view1.Position.Y)

            Dim linAngleDim As LinearGeneralDimension =
                sheet1.DrawingDimensions.GeneralDimensions.AddLinear(placementPoint, topIntent, bottomIntent)

            'Dim linAngleDim As LinearGeneralDimension =
            '    sheet1.DrawingDimensions.GeneralDimensions.AddLinear(placementPoint, topIntent, bottomIntent, DimensionTypeEnum.kVerticalDimensionType)


        End If

    End Sub

    Private Sub btnViewScale_Click(sender As Object, e As EventArgs) Handles btnViewScale.Click

        'Only get this if the document is a drawing document
        Dim activeDWG As DrawingDocument = If(invAppObj.ActiveDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject,
                                            CType(invAppObj.ActiveDocument, DrawingDocument), Nothing)
        If activeDWG IsNot Nothing Then
            Dim view1 As DrawingView = activeDWG.ActiveSheet.DrawingViews.Item(1)

            view1.rescaleView(28, 28)

        End If


    End Sub

    Private Sub btnAssySelect_Click(sender As Object, e As EventArgs) Handles btnAssySelect.Click

        'Only get this if the document is a drawing document
        Dim activeDWG As DrawingDocument = If(invAppObj.ActiveDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject,
                                            CType(invAppObj.ActiveDocument, DrawingDocument), Nothing)
        If activeDWG IsNot Nothing Then
            Dim view1 As DrawingView = activeDWG.ActiveSheet.DrawingViews.Item(1)

            Dim refDoc As AssemblyDocument = CType(view1.ReferencedDocumentDescriptor.ReferencedDocument, AssemblyDocument)

            For Each leafOcc As ComponentOccurrence In CType(refDoc.ComponentDefinition, AssemblyComponentDefinition).Occurrences.AllLeafOccurrences
                If leafOcc.DefinitionDocumentType = DocumentTypeEnum.kPartDocumentObject Then
                    If CType(CType(leafOcc.Definition, PartComponentDefinition).Document, PartDocument).
                        AttributeManager.FindAttributes("KETIV", "CompType", "CheeseWedge").Count > 0 Then

                        Dim drawingCurves = view1.DrawingCurves(leafOcc)

                        For Each dCurve As DrawingCurve In drawingCurves
                            dCurve.DebugFakeHighlight
                        Next


                    End If
                End If
            Next

        End If


    End Sub
End Class