'Source code For KETIV's AVA on Inventor iLogic and Inventor API pro tips and tricks.  All rights
'reserved.Everything in this project/repo Is provided as-Is with no guarantees.  This Is provided for
'learning purposes only.  Copyright 2019 KETIV Technologies, Inc.  All Rights Reserved.


Imports System.Runtime.CompilerServices
Imports Inventor

Public Module InvExtensions

    ''' <summary>
    ''' Returns the "generic" component definition of the generic Inventor document if it has a component definition.
    ''' Will return "Nothing" if it is not a Part or Assembly document.
    ''' </summary>
    ''' <param name="aDocument"></param>
    ''' <returns></returns>
    <Extension> Public Function myCompDefn(aDocument As Inventor.Document) As Inventor.ComponentDefinition
        Select Case aDocument.DocumentType
            Case Inventor.DocumentTypeEnum.kPartDocumentObject
                Return CType(aDocument, Inventor.PartDocument).ComponentDefinition
            Case Inventor.DocumentTypeEnum.kAssemblyDocumentObject
                Return CType(aDocument, Inventor.AssemblyDocument).ComponentDefinition
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Returns the PartComponentDefintion if the ComponentDefinition object is a part
    ''' </summary>
    ''' <param name="unknownDefn"></param>
    ''' <returns></returns>
    <Extension> Public Function ToPartCompDefn(ByVal unknownDefn As ComponentDefinition) As PartComponentDefinition
        If unknownDefn.Type = ObjectTypeEnum.kPartComponentDefinitionObject Then
            Return CType(unknownDefn, PartComponentDefinition)
        Else
            Return Nothing
        End If

    End Function


    ''' <summary>
    ''' Returns the AssemblyComponentDefintion if the ComponentDefinition object is an assembly
    ''' </summary>
    ''' <param name="unknownDefn"></param>
    ''' <returns></returns>
    <Extension> Public Function ToAssyCompDefn(ByVal unknownDefn As ComponentDefinition) As AssemblyComponentDefinition
        If unknownDefn.Type = ObjectTypeEnum.kAssemblyComponentDefinitionObject Then
            Return CType(unknownDefn, AssemblyComponentDefinition)
        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' Returns the filename of the document the occurence is based on
    ''' </summary>
    ''' <param name="aOccurence"></param>
    ''' <returns></returns>
    <Extension> Public Function myDocFileName(aOccurence As Inventor.ComponentOccurrence) As String
        Select Case aOccurence.DefinitionDocumentType
            Case DocumentTypeEnum.kPartDocumentObject
                Return CType(aOccurence.Definition.Document, PartDocument).FullFileName
            Case DocumentTypeEnum.kAssemblyDocumentObject
                Return CType(aOccurence.Definition.Document, AssemblyDocument).FullFileName
            Case Else
                Return ""
        End Select
    End Function

    ''' <summary>
    ''' Finds the drawing curves in the view that are created from faces that have the given attributes
    ''' </summary>
    ''' <param name="aView"></param>
    ''' <param name="AttributeSetName"></param>
    ''' <param name="AttributeName"></param>
    ''' <param name="AttributeValue"></param>
    ''' <returns></returns>
    <Extension> Public Function findCurvesByAttribute(aView As Inventor.DrawingView, AttributeSetName As String,
                                                     AttributeName As String, AttributeValue As String) As List(Of DrawingCurve)
        Dim returnCurves As New List(Of DrawingCurve)

        For Each viewOCC As ComponentOccurrence In
            CType(aView.ReferencedDocumentDescriptor.ReferencedDocument, Inventor.AssemblyDocument).ComponentDefinition.Occurrences.AllLeafOccurrences

            'Fist see if there are faces that has the attibute
            If aView.DrawingCurves(viewOCC).Count > 0 And viewOCC.Definition.Type = ObjectTypeEnum.kPartComponentDefinitionObject Then

                Dim oCollection As Inventor.ObjectCollection = CType(viewOCC.Definition.Document,
                                    Inventor.PartDocument).AttributeManager.FindObjects(AttributeSetName,
                                                                                        AttributeName,
                                                                                        AttributeValue)

                'If we found anything with the attributes, get the face, the edges, and the view drawing curves they create
                For Each oCObject In oCollection
                    'Check that the object is a face.  If it is, get edges and the edge proxies
                    If CType(oCObject, Inventor.Face).Type = ObjectTypeEnum.kFaceObject Then
                        Dim oFace = CType(oCObject, Inventor.Face)

                        For Each oEdge As Inventor.Edge In oFace.Edges
                            Dim oEdgeProxy As Inventor.EdgeProxy = Nothing

                            viewOCC.CreateGeometryProxy(oEdge, oEdgeProxy)

                            'Check if the edge proxy creates a drawing curve in the view


                            For Each candidateCurve As DrawingCurve In aView.DrawingCurves(oEdgeProxy)

                                returnCurves.Add(candidateCurve)


                            Next
                        Next

                    End If

                Next

            End If

        Next

        Return returnCurves
    End Function


    ''' <summary>
    ''' Will change the curve's color to Red and lineweight to 0.25cm, but only when in debug mode in visual studio.
    ''' <para>Used to help debug drawing automation code.  This only works when the DEBUG variable is set in a Visual Studio.</para>
    ''' </summary>
    <Extension> Public Sub DebugFakeHighlight(ByVal aDrawingCurve As DrawingCurve)

        DebugFakeHighlight(aDrawingCurve, 255, 0, 0, 0.25)

    End Sub

    ''' <summary>
    ''' Will change the curve's color and lineweight simultaneously, but only when in debug mode in visual studio.
    ''' <para>Used to help debug drawing automation code.  This only works when the DEBUG variable is set in a Visual Studio.</para>
    ''' </summary>
    ''' <param name="aDrawingCurve"></param>
    ''' <param name="Red">Sets the R value (0 to 255)</param>
    ''' <param name="Green">Sets the G value (0 to 255)</param>
    ''' <param name="Blue">Sets the B value (0 to 255)</param>
    ''' <param name="lineWeight">Set the lineweight (in cm)</param>
    <Extension> Public Sub DebugFakeHighlight(ByVal aDrawingCurve As DrawingCurve, red As Byte, green As Byte, blue As Byte, lineWeight As Double)

#If DEBUG Then
        aDrawingCurve.colorMe(red, green, blue)
        aDrawingCurve.LineWeight = lineWeight

#End If

    End Sub


    ''' <summary>
    ''' Use this extension to chage the color (RGB) or a drawing curve in a drawing view
    ''' </summary>
    ''' <param name="aDrawingCurve"></param>
    ''' <param name="Red">Sets the R value (0 to 255)</param>
    ''' <param name="Green">Sets the G value (0 to 255)</param>
    ''' <param name="Blue">Sets the B value (0 to 255)</param>
    <Extension> Public Sub colorMe(ByVal aDrawingCurve As DrawingCurve, Red As Byte, Green As Byte, Blue As Byte)

        aDrawingCurve.Color = CType(aDrawingCurve.Application, Inventor.Application).TransientObjects.CreateColor(Red, Green, Blue)
    End Sub

    ''' <summary>
    ''' Rounds the double to the nearest 3rd decimal place.  Used quite often for comparing CAD object placement values where rounding errors can 
    ''' prevent equivalence/greater than/less than problems.
    ''' </summary>
    <Extension> Public Function Round(ByVal aNumber As Double) As Double
        Return Math.Round(aNumber, 3)
    End Function

    ''' <summary>
    ''' Rounds the double to the nearset "digits" decimpal place
    ''' </summary>
    ''' <param name="aNumber">The value being extended</param>
    ''' <param name="digits">The number of decimal places to round to</param>
    ''' <returns></returns>
    <Extension> Public Function Round(ByVal aNumber As Double, digits As Integer) As Double
        Return Math.Round(aNumber, digits)
    End Function

    ''' <summary>
    ''' Returns the ceiling value
    ''' </summary>
    ''' <param name="aNumber"></param>
    ''' <returns></returns>
    <Extension> Public Function Ceiling(ByVal aNumber As Double) As Double
        Return Math.Ceiling(aNumber)
    End Function

    ''' <summary>
    ''' Returns the floor value
    ''' </summary>
    ''' <param name="aNumber"></param>
    ''' <returns></returns>
    <Extension> Public Function Floor(ByVal aNumber As Double) As Double
        Return Math.Floor(aNumber)
    End Function


    ''' <summary>
    ''' Returns the ceiling to the number of "digit" decimal places, use with caution...
    ''' </summary>
    ''' <param name="aNumber"></param>
    ''' <param name="digits"></param>
    ''' <returns></returns>
    <Extension> Public Function Ceiling(ByVal aNumber As Double, digits As Integer) As Double
        Return Math.Ceiling(aNumber * 10 ^ digits) / (10 ^ digits)
    End Function

    ''' <summary>
    ''' Returns the floor to the number of "digit" decimal places, use with caution...
    ''' </summary>
    ''' <param name="aNumber"></param>
    ''' <param name="digits"></param>
    ''' <returns></returns>
    <Extension> Public Function Floor(ByVal aNumber As Double, digits As Integer) As Double
        Return Math.Floor(aNumber * 10 ^ digits) / (10 ^ digits)
    End Function


End Module
