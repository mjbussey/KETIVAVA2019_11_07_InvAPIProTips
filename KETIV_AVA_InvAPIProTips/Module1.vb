'Source code For KETIV's AVA on Inventor iLogic and Inventor API pro tips and tricks.  All rights
'reserved.Everything in this project/repo Is provided as-Is with no guarantees.  This Is provided for
'learning purposes only.  Copyright 2019 KETIV Technologies, Inc.  All Rights Reserved.

Imports System.Runtime.InteropServices

Module Module1

    Sub Main()
        Dim inventorAppObj As Inventor.Application = Marshal.GetActiveObject("Inventor.Application")

        Dim testForm As New TestHarness
        testForm.invAppObj = inventorAppObj
        testForm.ShowDialog()

    End Sub

End Module
