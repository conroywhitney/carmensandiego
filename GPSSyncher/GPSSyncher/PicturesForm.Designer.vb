<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PicturesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.previewBox = New System.Windows.Forms.PictureBox
        Me.picturesList = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.addButton = New System.Windows.Forms.Button
        Me.closeButton = New System.Windows.Forms.Button
        Me.deleteButton = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.saveButton = New System.Windows.Forms.Button
        Me.fileNameField = New System.Windows.Forms.TextBox
        CType(Me.previewBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'previewBox
        '
        Me.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.previewBox.Location = New System.Drawing.Point(12, 12)
        Me.previewBox.Name = "previewBox"
        Me.previewBox.Size = New System.Drawing.Size(360, 270)
        Me.previewBox.TabIndex = 0
        Me.previewBox.TabStop = False
        '
        'picturesList
        '
        Me.picturesList.FormattingEnabled = True
        Me.picturesList.Location = New System.Drawing.Point(393, 28)
        Me.picturesList.Name = "picturesList"
        Me.picturesList.Size = New System.Drawing.Size(156, 225)
        Me.picturesList.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(401, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "List of Pictures in Database"
        '
        'addButton
        '
        Me.addButton.Location = New System.Drawing.Point(12, 288)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(115, 23)
        Me.addButton.TabIndex = 3
        Me.addButton.Text = "Load Picture"
        Me.addButton.UseVisualStyleBackColor = True
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(478, 349)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 4
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'deleteButton
        '
        Me.deleteButton.Location = New System.Drawing.Point(422, 259)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(115, 23)
        Me.deleteButton.TabIndex = 5
        Me.deleteButton.Text = "Delete Selected"
        Me.deleteButton.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "MM/dd/yyyy HH:mm:ss"
        Me.DateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(178, 317)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(194, 20)
        Me.DateTimePicker1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 317)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Specify Date and Time of photo:"
        '
        'saveButton
        '
        Me.saveButton.Enabled = False
        Me.saveButton.Location = New System.Drawing.Point(133, 349)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(115, 23)
        Me.saveButton.TabIndex = 8
        Me.saveButton.Text = "Save To Database"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'fileNameField
        '
        Me.fileNameField.Location = New System.Drawing.Point(133, 288)
        Me.fileNameField.Name = "fileNameField"
        Me.fileNameField.ReadOnly = True
        Me.fileNameField.Size = New System.Drawing.Size(239, 20)
        Me.fileNameField.TabIndex = 9
        '
        'PicturesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 384)
        Me.Controls.Add(Me.fileNameField)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picturesList)
        Me.Controls.Add(Me.previewBox)
        Me.Name = "PicturesForm"
        Me.Text = "Pictures Imported"
        CType(Me.previewBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents previewBox As System.Windows.Forms.PictureBox
    Friend WithEvents picturesList As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents addButton As System.Windows.Forms.Button
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents deleteButton As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents saveButton As System.Windows.Forms.Button
    Friend WithEvents fileNameField As System.Windows.Forms.TextBox
End Class
