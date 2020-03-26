<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestHarness_DWG
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
        Me.btnDimWedge = New System.Windows.Forms.Button()
        Me.btnDimLinAngle = New System.Windows.Forms.Button()
        Me.btnDimParallelCrv = New System.Windows.Forms.Button()
        Me.btnViewScale = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnDimWedge
        '
        Me.btnDimWedge.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDimWedge.Location = New System.Drawing.Point(86, 60)
        Me.btnDimWedge.Name = "btnDimWedge"
        Me.btnDimWedge.Size = New System.Drawing.Size(166, 83)
        Me.btnDimWedge.TabIndex = 0
        Me.btnDimWedge.Text = "Dim Wedge"
        Me.btnDimWedge.UseVisualStyleBackColor = True
        '
        'btnDimLinAngle
        '
        Me.btnDimLinAngle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDimLinAngle.Location = New System.Drawing.Point(86, 185)
        Me.btnDimLinAngle.Name = "btnDimLinAngle"
        Me.btnDimLinAngle.Size = New System.Drawing.Size(166, 76)
        Me.btnDimLinAngle.TabIndex = 1
        Me.btnDimLinAngle.Text = "Dim Linear Angled"
        Me.btnDimLinAngle.UseVisualStyleBackColor = True
        '
        'btnDimParallelCrv
        '
        Me.btnDimParallelCrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDimParallelCrv.Location = New System.Drawing.Point(86, 323)
        Me.btnDimParallelCrv.Name = "btnDimParallelCrv"
        Me.btnDimParallelCrv.Size = New System.Drawing.Size(166, 73)
        Me.btnDimParallelCrv.TabIndex = 2
        Me.btnDimParallelCrv.Text = "Dim Parallel Curves"
        Me.btnDimParallelCrv.UseVisualStyleBackColor = True
        '
        'btnViewScale
        '
        Me.btnViewScale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewScale.Location = New System.Drawing.Point(86, 451)
        Me.btnViewScale.Name = "btnViewScale"
        Me.btnViewScale.Size = New System.Drawing.Size(166, 73)
        Me.btnViewScale.TabIndex = 3
        Me.btnViewScale.Text = "View Scale"
        Me.btnViewScale.UseVisualStyleBackColor = True
        '
        'TestHarness_DWG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 567)
        Me.Controls.Add(Me.btnViewScale)
        Me.Controls.Add(Me.btnDimParallelCrv)
        Me.Controls.Add(Me.btnDimLinAngle)
        Me.Controls.Add(Me.btnDimWedge)
        Me.Name = "TestHarness_DWG"
        Me.Text = "TestHarness_DWG"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnDimWedge As Windows.Forms.Button
    Friend WithEvents btnDimLinAngle As Windows.Forms.Button
    Friend WithEvents btnDimParallelCrv As Windows.Forms.Button
    Friend WithEvents btnViewScale As Windows.Forms.Button
End Class
