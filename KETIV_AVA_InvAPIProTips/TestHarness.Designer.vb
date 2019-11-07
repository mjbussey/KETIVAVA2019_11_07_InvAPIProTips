<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestHarness
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnGetChildDoc = New System.Windows.Forms.Button()
        Me.btnDWGDims = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGetChildDoc
        '
        Me.btnGetChildDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetChildDoc.Location = New System.Drawing.Point(105, 66)
        Me.btnGetChildDoc.Name = "btnGetChildDoc"
        Me.btnGetChildDoc.Size = New System.Drawing.Size(241, 35)
        Me.btnGetChildDoc.TabIndex = 0
        Me.btnGetChildDoc.Text = "Get Child Doc Name"
        Me.btnGetChildDoc.UseVisualStyleBackColor = True
        '
        'btnDWGDims
        '
        Me.btnDWGDims.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDWGDims.Location = New System.Drawing.Point(105, 168)
        Me.btnDWGDims.Name = "btnDWGDims"
        Me.btnDWGDims.Size = New System.Drawing.Size(241, 35)
        Me.btnDWGDims.TabIndex = 1
        Me.btnDWGDims.Text = "Drawing Dimensions"
        Me.btnDWGDims.UseVisualStyleBackColor = True
        '
        'TestHarness
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 287)
        Me.Controls.Add(Me.btnDWGDims)
        Me.Controls.Add(Me.btnGetChildDoc)
        Me.Name = "TestHarness"
        Me.Text = "TestHarness"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnGetChildDoc As Windows.Forms.Button
    Friend WithEvents btnDWGDims As Windows.Forms.Button
End Class
