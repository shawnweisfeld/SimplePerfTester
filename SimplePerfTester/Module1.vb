Module Module1

    Sub Main()

        Console.WriteLine("Running Test")
        Dim run = New Long

        While True
            run = run + 1
            GetCpuMipBenchmark(run)
        End While

    End Sub

    Public Sub GetCpuMipBenchmark(run As Long)
        Try
            'Compute the Avg MipScore
            Dim mipScore As Double
            Dim avgScore As Double

            Dim iterations As Integer = 50

            For i As Integer = 1 To iterations
                mipScore = mipScore + GetCpuMipScore()
            Next

            avgScore = Math.Round(mipScore / iterations, 2)

            Console.WriteLine($"Score: {avgScore}")

            IO.File.AppendAllText("score.csv", $"{DateTime.Now:G},{run},{avgScore}{Environment.NewLine}")

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Public Function GetCpuMipScore() As Double
        'Execute Three 1 Million item Tasks, Time the execution And Return the Average them To Get a CPU Benchmark
        Dim mipScore As Double

        Try
            Dim stopWatch As New System.Diagnostics.Stopwatch()

            'Test 1: Mulitply Two Decimals
            '------------------------------------------------------------------
            stopWatch.Reset()
            stopWatch.Start()
            Dim x As Decimal = 1.75569
            Dim y As Decimal = 2.67823
            Dim r As Decimal = 0
            For i As Integer = 1 To 1000000
                r = x * y
            Next
            stopWatch.Stop()
            Dim mathSpan As TimeSpan = stopWatch.Elapsed

            'Compute the Math MIP Score
            Dim mathMip As Double = Math.Round(1 / (mathSpan.Milliseconds / 1000), 2)

            'Test 2: Add 1 Million items to a List
            '------------------------------------------------------------------
            stopWatch.Reset()
            stopWatch.Start()
            Dim testList As New List(Of Integer)
            For i As Integer = 1 To 1000000
                testList.Add(i)
            Next
            stopWatch.Stop()
            Dim listSpan As TimeSpan = stopWatch.Elapsed

            'Compute the "List Add" MIP Score
            Dim listMip As Double = Math.Round(1 / (listSpan.Milliseconds / 1000), 2)

            'Test 3: Create 1 Million objects
            '------------------------------------------------------------------
            stopWatch.Reset()
            stopWatch.Start()
            For i As Integer = 1 To 1000000
                Dim testObj As New TwoStrings("x", "y")
            Next
            stopWatch.Stop()
            Dim createObjSpan As TimeSpan = stopWatch.Elapsed

            'Compute the "List Add" MIP Score
            Dim createObjMip As Double = Math.Round(1 / (createObjSpan.Milliseconds / 1000), 2)

            'Compute the average of the Three Tests
            mipScore = Math.Round((mathMip + listMip + createObjMip) / 3, 2)

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

        Return mipScore

    End Function




End Module
