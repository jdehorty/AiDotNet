﻿using AiDotNet.Enums;
using AiDotNet.Models;
using AiDotNet.Normalization;
using AiDotNet.Regression;

namespace AiDotNetTestConsole;

internal class Program
{
    static void Main(string[] args)
    {
        var inputs = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var multInputs = new [] { new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 
            new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }};
        var multOutputs = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var outputs = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var test1 = new[] { new[] { 1.0, 4.0 }, new[] { 2.0, 5.0 }, new[] { 3.0, 2.0 }, new [] { 4.0, 5.0 } };
        var test3 = new[] { new[] { 1.0, 2.0, 3.0, 4.0 }, new[] { 4.0, 5.0, 2.0, 3.0 } };
        var test2 = new[] { 15.0, 20, 10, 15.0 };

        var simpleRegression = new SimpleRegression(inputs, outputs);
        var metrics1 = simpleRegression.Metrics;
        var predictions1 = simpleRegression.Predictions;

        var advancedSimpleRegression = new SimpleRegression(inputs, outputs, new SimpleRegressionOptions()
        {
            TrainingPctSize = 20,
            Normalization = new DecimalNormalization()
        });
        var metrics2 = advancedSimpleRegression.Metrics;
        var predictions2 = advancedSimpleRegression.Predictions;

        var multipleRegression = new MultipleRegression(test3, test2, 
            new MultipleRegressionOptions() { TrainingPctSize = 99, MatrixDecomposition = MatrixDecomposition.Lu, UseIntercept = true });
        var metrics3 = multipleRegression.Metrics;
        var predictions3 = multipleRegression.Predictions;

        Console.WriteLine();
    }
}