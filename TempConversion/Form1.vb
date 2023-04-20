Public Class Form1
    ' Initialize a queue to store the past conversion results
    Private pastConversions As New Queue(Of String)
    ' Set a constant to define the maximum number of history items
    Private Const historySize As Integer = 5

    ' Event handler for the "Convert" button click
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        Try
            Dim inputTemperature As Double
            Dim convertedTemperature As Double
            Dim resultText As String

            ' Check if the "Fahrenheit to Celsius" radio button is selected
            If rbFtoC.Checked Then
                ' Parse the input temperature from the Fahrenheit textbox
                inputTemperature = Double.Parse(tbFahrenheit.Text)
                ' Perform the conversion from Fahrenheit to Celsius
                convertedTemperature = (inputTemperature - 32) * 5 / 9
                ' Format the result text for display
                resultText = $"{inputTemperature} degrees in Fahrenheit is {Math.Round(convertedTemperature, 2)} degrees in Celsius"
                ' Check if the "Celsius to Fahrenheit" radio button is selected
            ElseIf rbCtoF.Checked Then
                ' Parse the input temperature from the Celsius textbox
                inputTemperature = Double.Parse(tbCelsius.Text)
                ' Perform the conversion from Celsius to Fahrenheit
                convertedTemperature = inputTemperature * 9 / 5 + 32
                ' Format the result text for display
                resultText = $"{inputTemperature} degrees in Celsius is {Math.Round(convertedTemperature, 2)} degrees in Fahrenheit"
            Else
                ' Display an error message if no conversion option is selected
                MessageBox.Show("Please select a conversion option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Add the new conversion result to the queue
            pastConversions.Enqueue(resultText)

            ' Remove the oldest conversion result if the queue size exceeds the history limit
            If pastConversions.Count > historySize Then
                pastConversions.Dequeue()
            End If

            ' Display the conversion history in the label, separated by newlines
            lblConversion.Text = String.Join(Environment.NewLine, pastConversions.Reverse())

        Catch ex As Exception
            ' Display an error message if the input is not valid
            MessageBox.Show("Invalid input. Please enter a valid temperature.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Event handler for the Fahrenheit textbox text change
    Private Sub tbFahrenheit_TextChanged(sender As Object, e As EventArgs) Handles tbFahrenheit.TextChanged

    End Sub

    ' Event handler for the Celsius textbox text change
    Private Sub tbCelcius_TextChanged(sender As Object, e As EventArgs) Handles tbCelsius.TextChanged

    End Sub

    ' Event handler for the "Clear" button click
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' Clear the Fahrenheit and Celsius textboxes
        tbFahrenheit.Clear()
        tbCelsius.Clear()
        ' Clear the conversion history label
        lblConversion.Text = ""
        ' Uncheck both radio buttons
        rbFtoC.Checked = False
        rbCtoF.Checked = False
        ' Clear the past conversions queue
        pastConversions.Clear()
    End Sub

    ' Event handler for the form load event
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the conversion history label to an empty string
        lblConversion.Text = ""
    End Sub
End Class
